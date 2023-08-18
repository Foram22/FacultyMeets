namespace FacultyMeets;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Wait for 3 seconds
        await Task.Delay(3000);

        // Open another page
        await Navigation.PushAsync(new LoginPage());
        //Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
    }
}


