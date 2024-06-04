using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using PruebaMAUI.Model;
using PruebaMAUI.Views;

namespace PruebaMAUI.ViewModel
{
    public class AppointmentsViewModel
    {
        public ObservableCollection<Grouping<string, Appointment>> Appointments { get; set; }

        public AppointmentsViewModel()
        {
            var appointments = LoadAppointments();
            var groupedAppointments = appointments
                .GroupBy(a => GetSectionTitle(a.Date))
                .Select(g => new Grouping<string, Appointment>(g.Key, g));

            Appointments = new ObservableCollection<Grouping<string, Appointment>>(groupedAppointments);

            MessagingCenter.Subscribe<AddAppointmentPage, Appointment>(this, "AddAppointment", (sender, appointment) =>
            {
                AddAppointment(appointment);
            });
        }

        public void AddAppointment(Appointment appointment)
        {
            var groupKey = GetSectionTitle(appointment.Date);
            var group = Appointments.FirstOrDefault(g => g.Key == groupKey);

            if (group == null)
            {
                group = new Grouping<string, Appointment>(groupKey, new List<Appointment>());
                Appointments.Add(group);
            }

            group.Add(appointment);
            SaveAppointments();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            var group = Appointments.FirstOrDefault(g => g.Contains(appointment));
            if (group != null)
            {
                group.Remove(appointment);
                if (group.Count == 0)
                {
                    Appointments.Remove(group);
                }
                SaveAppointments();
            }
        }

        public string GetSectionTitle(DateTime date)
        {
            var today = DateTime.Now.Date;
            var tomorrow = today.AddDays(1);
            var dayAfterTomorrow = today.AddDays(2);

            if (date.Date == today)
            {
                return "Hoy";
            }
            else if (date.Date == tomorrow)
            {
                return "Mañana";
            }
            else if (date.Date == dayAfterTomorrow)
            {
                return "Pasado Mañana";
            }
            else if (date.Date > dayAfterTomorrow)
            {
                return $"Próximamente ({date:dd MMM yyyy})";
            }
            else
            {
                return date.ToString("d MMM");
            }
        }

        private List<Appointment> LoadAppointments()
        {
            var appointmentsJson = Preferences.Get("appointments", string.Empty);
            if (string.IsNullOrEmpty(appointmentsJson))
            {
                return new List<Appointment>
            {
                new Appointment { Date = DateTime.Now, Description = "Meeting with Bob" },
                new Appointment { Date = DateTime.Now.AddDays(1), Description = "Dentist Appointment" },
                new Appointment { Date = DateTime.Now.AddDays(2), Description = "Lunch with Alice" },
                new Appointment { Date = DateTime.Now.AddDays(4), Description = "Project Deadline" }
            };
            }

            return JsonSerializer.Deserialize<List<Appointment>>(appointmentsJson);
        }

        public void SaveAppointments()
        {
            var appointmentsJson = JsonSerializer.Serialize(Appointments.SelectMany(g => g));
            Preferences.Set("appointments", appointmentsJson);
        }
    }

}
