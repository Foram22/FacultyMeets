namespace FacultyMeets;

public partial class ProfilePage : ContentView
{
	public User userData { get; set; }
	public ProfilePage(User user)
	{
		InitializeComponent();
		userData = user;
		BindingContext = userData;
	}

	private async void OnLogoutPressed(object sender, EventArgs e)
	{
		Xamarin.Essentials.Preferences.Clear();

		await Navigation.PushAsync(new LoginPage());
		Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
	}
}
