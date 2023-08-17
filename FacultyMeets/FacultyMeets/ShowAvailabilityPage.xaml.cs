using FacultyMeets.ModelClasses;
using Firebase.Database;
using Firebase.Database.Query;

namespace FacultyMeets;

public partial class ShowAvailabilityPage : ContentPage
{
    FirebaseClient firebaseClient;
    string facultyId;

    public ShowAvailabilityPage(string id)
	{
		InitializeComponent();

        facultyId = id;
        // Initialize FirebaseClient with your Firebase URL
        firebaseClient = new FirebaseClient("https://facultymeets-default-rtdb.firebaseio.com/");

        LoadFacultyAvailability(facultyId); // 
    }

    async void LoadFacultyAvailability(string facultyId)
    {
        var availabilityData = await GetFacultyAvailabilityAsync(facultyId);
        AvailabilityListView.ItemsSource = availabilityData;
    }

    async Task<List<Availability>> GetFacultyAvailabilityAsync(string facultyId)
    {
        var availabilityData = await firebaseClient.Child("faculty").Child(facultyId).Child("availabilities")
            .OnceAsync<Availability>();

        var availabilityList = new List<Availability>();
        foreach (var item in availabilityData)
        {
            var availability = item.Object;
            //availability.EndTime = item.Object.EndTime;
            availabilityList.Add(availability);
        }
        return availabilityList;
    }
}
