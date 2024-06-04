namespace PruebaMAUI;
using PruebaMAUI.Views;
using Firebase.Database;
using Firebase.Database.Query;
public partial class MainPage : ContentPage
{
	public MainPage()
	{
        InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetHasBackButton(this, false);
    }
}

