namespace FacultyMeets;

public partial class RolePage : ContentPage
{
    string rb_text = "";
    public RolePage()
    {
        InitializeComponent();
    }

    private void OnCheckedChange(object sender, CheckedChangedEventArgs e)
    {
        // Handle radio button checked event
        var radioButton = (RadioButton)sender;
        rb_text = radioButton.Content.ToString();
        Console.WriteLine($"Selected option: {rb_text}");
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        if (rb_text != null && rb_text.Length > 0)
        {
            // Perform appropriate navigation or logic based on the selected user (faculty or student)
            if (rb_text == "Faculty")
            {
                Console.WriteLine($"Selected option: {rb_text}");
                Data.Role = rb_text;

            }
            else if (rb_text == "Student")
            {
                //DependencyService.Get<IToastService>().ShowToast(selectedUser);
                Console.WriteLine($"Selected option: {rb_text}");
                Data.Role = rb_text;
            }

            // Navigate to the home page after successful registration
            var mainHomePage = new MainHomePage();
            //mainHomePage.Data = Data;
            await Navigation.PushAsync(mainHomePage);
        }

    }
}