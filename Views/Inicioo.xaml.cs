using Firebase.Database;
using Microsoft.Maui.Storage;
using PruebaMAUI.Model;
using PruebaMAUI.ViewModel;
using System.Xml.Linq;

namespace PruebaMAUI.Views;

public partial class Inicioo : ContentPage
{
    public Inicioo()
    {
        InitializeComponent();
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var appointment = button?.CommandParameter as Appointment;
        if (appointment != null)
        {
            var viewModel = BindingContext as AppointmentsViewModel;
            viewModel?.DeleteAppointment(appointment);
        }
    }
    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddAppointmentPage());
    }
}