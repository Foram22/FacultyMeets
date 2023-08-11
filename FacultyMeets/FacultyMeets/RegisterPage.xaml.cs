using System.Reflection.Metadata;
using FacultyMeets.ModelClasses;
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

    //private async void OnRegisterClicked(object sender, EventArgs e)
    //{
    //    // Perform registration logic here
    //    string fullName = FullNameEntry.Text;
    //    string email = EmailEntry.Text;
    //    string password = PasswordEntry.Text;

    //    // Validate input and create a new user account
    //    if (fullName == null || fullName.Length <= 0)
    //    {
            
    //    }
    //    else if (email == null || email.Length <= 0)
    //    {
            
    //    }
    //    else if (password == null || password.Length <= 0)
    //    {
            
    //    }
    //    else {
    //        var user = new User();

    //        user.Name = fullName;
    //        user.Email = email;
    //        user.Password = password;

    //        try
    //        {
    //            var auth = FirebaseAuth.Instance;
    //            var result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);

    //            // Navigate to the home page after successful registration
    //            var rolePage = new RolePage();
    //            rolePage.Data = user;
    //            Navigation.PushAsync(new RolePage());


    //        }
    //        catch (Exception ex)
    //        {
    //            await DisplayAlert("Error", $"Sign-in failed: {ex.Message}", "OK");
    //        }
    //    }
    //}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page
        await Navigation.PushAsync(new LoginPage());
    }

}
