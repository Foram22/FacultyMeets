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

        // Validate input to login into the user account
        if (email == null || email.Length <= 0)
        {

        }
        else if (password == null || password.Length <= 0)
        {

        }
        else
        {
            var user = new User();

            user.Email = email;
            user.Password = password;

            await Navigation.PushAsync(new MainHomePage());
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Open another page
        await Navigation.PushAsync(new RegisterPage());
    }
}
