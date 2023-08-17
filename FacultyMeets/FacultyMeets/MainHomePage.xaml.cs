using Microsoft.Maui.Controls;

namespace FacultyMeets;

public partial class MainHomePage : ContentPage
{
    public List<string> Items { get; set; }

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

    private void OnHomeClicked(object sender, EventArgs e)
    {
        // Handle the Settings menu item click
        // Implement navigation to the settings page or any other action
    }

    private void OnNotificationClicked(object sender, EventArgs e)
    {
        // Handle the About menu item click
        // Implement navigation to the about page or any other action
    }

    private void OnHistoryClicked(object sender, EventArgs e)
    {
        // Handle the Settings menu item click
        // Implement navigation to the settings page or any other action
    }

    private void OnSettingClicked(object sender, EventArgs e)
    {
        // Handle the About menu item click
        // Implement navigation to the about page or any other action
    }

    private void OnProfileClicked(object sender, EventArgs e)
    {
        // Handle the About menu item click
        // Implement navigation to the about page or any other action
    }

    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        // Handle the About menu item click
        // Implement navigation to the about page or any other action
    }
}
