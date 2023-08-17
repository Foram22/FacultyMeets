using System.Reflection.Metadata;
using FacultyMeets.ViewModels;
using Firebase.Auth;
namespace FacultyMeets;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page
        await Navigation.PushAsync(new LoginPage());
    }

}
