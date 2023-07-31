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
        if (fullName == null || fullName.Length <= 0)
        {
            
        }
        else if (email == null || email.Length <= 0)
        {
            
        }
        else if (password == null || password.Length <= 0)
        {
            
        }
        else {
            var user = new User();

            user.Name = fullName;
            user.Email = email;
            user.Password = password;

            // Navigate to the home page after successful registration
            var homePage = new HomePage();
            homePage.Data = user;
            Navigation.PushAsync(new HomePage());
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page
        await Navigation.PushAsync(new LoginPage());
    }

}
