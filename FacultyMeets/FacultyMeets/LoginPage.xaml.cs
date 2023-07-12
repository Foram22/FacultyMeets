namespace FacultyMeets;

public partial class LoginPage : ContentPage
{

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Perform login logic here
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Open another page
        await Navigation.PushAsync(new RegisterPage());
    }
}
