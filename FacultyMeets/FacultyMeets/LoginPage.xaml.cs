using FacultyMeets.ViewModels;

namespace FacultyMeets;

public partial class LoginPage : ContentPage
{

    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Open another page
        await Navigation.PushAsync(new RegisterPage());
    }
}
