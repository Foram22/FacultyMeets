namespace FacultyMeets;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        // Perform registration logic here
        string fullName = FullNameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        // Validate input and create a new user account
        // You can use authentication services like Firebase Authentication or ASP.NET Identity

        // Navigate to the home page after successful registration
        Navigation.PushAsync(new HomePage());
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page
        await Navigation.PushAsync(new LoginPage());
    }

}
