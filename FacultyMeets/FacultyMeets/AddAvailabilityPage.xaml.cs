using FacultyMeets.ModelClasses;
using Firebase.Database;
using Firebase.Database.Query;

namespace FacultyMeets;

public partial class AddAvailabilityPage : ContentView
{

    FirebaseClient firebaseClient;
    User userData;

    public AddAvailabilityPage(User user)
	{
        InitializeComponent();
        userData = user;
        firebaseClient = new FirebaseClient("https://facultymeets-default-rtdb.firebaseio.com/");
    }

    async void OnAddAvailabilityClicked(object sender, EventArgs e)
    {
        DateTime startDateTime = StartDatePicker.Date.Add(StartTimePicker.Time);
        DateTime endDateTime = EndDatePicker.Date.Add(EndTimePicker.Time);

        var availability = new Availability
        {
            // Use the actual faculty ID
            StartTime = startDateTime,
            EndTime = endDateTime
        };

        await AddAvailabilityAsync(availability);

        // Optionally, navigate back to the faculty's availability list
        //await Navigation.PushAsync(new ShowAvailabilityPage(userData.Id));
    }

    async Task AddAvailabilityAsync(Availability availability)
    {
        await firebaseClient.Child("users").Child(userData.Id).Child("availabilities").PostAsync(availability);
        var result = firebaseClient.Child("faculty").Child(userData.Id).Child("availabilities").PostAsync(availability);
        if (result != null)
        {
            await Navigation.PushAsync(new ShowAvailabilityPage(userData.Id));
        }
    }

}
