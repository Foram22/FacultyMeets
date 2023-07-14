namespace FacultyMeets;

public partial class HomePage : ContentPage
{
    string rb_text = "";
    public HomePage()
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

    private void OnContinueClicked(object sender, EventArgs e)
    {
        // Perform appropriate navigation or logic based on the selected user (faculty or student)
        if (rb_text == "Faculty")
        {
            //DependencyService.Get<IToastService>().ShowToast(selectedUser);
            Console.WriteLine($"Selected option: {rb_text}");
        }
        else if (rb_text == "Student")
        {
            //DependencyService.Get<IToastService>().ShowToast(selectedUser);
            Console.WriteLine($"Selected option: {rb_text}");
        }
    }
}
