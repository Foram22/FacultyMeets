using Xamarin.Essentials;
using Newtonsoft.Json;
using Android.Content;

namespace FacultyMeets;

public partial class MainHomePage : ContentPage
{
    public List<string> Items { get; set; }
    User user;

    public MainHomePage()
	{
        InitializeComponent();

        // Initialize and populate the list for the horizontal list view
        Items = new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5",
                // Add more items as needed
            };

        // Set the binding context to the list
        BindingContext = this;
    }

    public void GetUserData() {
        string jsonStr = Xamarin.Essentials.Preferences.Get("user", "");
        user = JsonConvert.DeserializeObject<User>(jsonStr);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        user = new User();
        GetUserData();
        // Clear existing toolbar items
        ToolbarItems.Clear();

        // Always add Home and Profile items
        ToolbarItems.Add(new ToolbarItem
        {
            Text = "Home",
            Command = new Command(NavigateHome) // Define this command to navigate to the home page
        });

        ToolbarItems.Add(new ToolbarItem
        {
            Text = "Profile",
            Command = new Command(NavigateProfile) // Define this command to navigate to the profile page
        });

        // Conditionally add other items based on user type
        if (user.Role == "faculty" || user.Role == "Faculty")
        {
            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Availability",
                Command = new Command(NavigateAvailability) // Assuming you've defined this command
            });
            
        }
        else
        {
            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Faculty",
                Command = new Command(NavigateFaculty) // Assuming you've defined this command
            });
        }

        NavigateHome();
    }


    void NavigateHome()
    {
        // Navigate to the Home page or perform related logic.
        LoadDesign(new DashboardPage());
    }

    void NavigateProfile()
    {
        // Navigate to the Profile page or perform related logic.
        LoadDesign(new ProfilePage(user));
    }

    void NavigateAvailability()
    {
        LoadDesign(new AvailabilityPage());
    }

    void NavigateFaculty()
    {
        LoadDesign(new FacultyPage());
    }

    private void LoadDesign(View designView)
    {
        ContentGrid.Children.Clear(); // Clear previous content
        ContentGrid.Children.Add(designView);
    }

}
