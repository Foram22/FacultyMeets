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

        // Set the data
        var user = new User();
        user.Email = email;
        user.Name = fullName;
        user.Password = password;

        // Navigate to the home page after successful registration
        var homePage = new HomePage();
        homePage.Data = user;
        Navigation.PushAsync(new HomePage());
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page
        await Navigation.PushAsync(new LoginPage());
    }

}
