using PruebaMAUI.Views;

namespace PruebaMAUI;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        NavigationPage.SetTitleIconImageSource(this, "logo_icono_bg");
	}
    private async void Login_Clicked(object sender, EventArgs e)
    {
        Loginn.Text = string.Empty;
        Loginn.BackgroundColor = Color.FromRgba(0, 0, 255, 0.5);
        Loginn.IsEnabled = false;
        Iniciando.IsRunning = true;
        if (User.Text == null && Password.Text == null)
        {
            incorrecto.IsVisible = true;
            incorrecto.Text = "Campos sin llenar";
        }
        else if (User.Text == "dilanplus" && Password.Text == "12345")
        {
            await Navigation.PushAsync(new SugerirPage());
        }
        else
        {
            incorrecto.IsVisible = true;
            incorrecto.Text = "Usuario y/o Contraseña Incorrectos";
        }
        Loginn.Text = "Login";
        Iniciando.IsRunning = false;
        Loginn.IsEnabled = true;
        Loginn.BackgroundColor = Color.FromArgb("#512BD4");
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (Password.IsPassword == true)
        {
            Password.IsPassword = false;
            Mostrar.Source = "ocultarojo.png";
        }else
        if(Password.IsPassword == false)
        {
            Mostrar.Source = "ojo.png";
            Password.IsPassword = true;
        }
    }
}