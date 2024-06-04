using PruebaMAUI.Model;

namespace PruebaMAUI.Views;

public partial class AddAppointmentPage : ContentPage
{
	public AddAppointmentPage()
	{
		InitializeComponent();
	}
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var description = DescriptionEntry.Text;
        var date = DatePicker.Date;
        var time = TimePicker.Time;
        var appointmentDate = date.Add(time);

        var newAppointment = new Appointment
        {
            Date = appointmentDate,
            Description = description
        };
        MessagingCenter.Send(this, "AddAppointment", newAppointment);
        await Navigation.PopAsync();
    }
}