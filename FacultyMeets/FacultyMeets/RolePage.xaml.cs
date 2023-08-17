using FacultyMeets.ViewModels;
using Firebase.Database;
using Firebase.Database.Query;

namespace FacultyMeets;

public partial class RolePage : ContentPage
{
    public string webApiKey = "AIzaSyBDIXe41Utd8_fkROzcijCmQ3CdWjZxWhI";
    public string databaseUrl = "https://facultymeets-default-rtdb.firebaseio.com/";

    string rb_text = "";
    string userId = "";


    public RolePage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
    }

    private void OnCheckedChange(object sender, CheckedChangedEventArgs e)
    {
        // Handle radio button checked event
        var radioButton = (RadioButton)sender;
        rb_text = radioButton.Content.ToString();

        var viewModel = BindingContext as RegisterViewModel;
        viewModel.SelectedRole = rb_text;
        Console.WriteLine($"Selected option: {rb_text}");
    }
}