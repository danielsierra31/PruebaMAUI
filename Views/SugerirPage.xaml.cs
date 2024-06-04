namespace PruebaMAUI.Views;

public partial class SugerirPage : ContentPage
{
	public SugerirPage()
	{
		InitializeComponent();
	}
    private async void OnOpenLinkClicked(object sender, EventArgs e)
    {
        var uri = new Uri("http://127.0.0.1:5000"); // Reemplaza con tu enlace
        await Launcher.Default.OpenAsync(uri);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inicioo());
    }
}