using FacultyMeets.ModelClasses;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace FacultyMeets;

public partial class ShowAvailabilityPage : ContentPage
{
    FirebaseClient firebaseClient;
    string facultyId;
    User userData;

    public ShowAvailabilityPage(string id)
	{
		InitializeComponent();

        facultyId = id;
        // Initialize FirebaseClient with your Firebase URL
        firebaseClient = new FirebaseClient("https://facultymeets-default-rtdb.firebaseio.com/");


        string jsonStr = Xamarin.Essentials.Preferences.Get("user", "");
        userData = JsonConvert.DeserializeObject<User>(jsonStr);

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

    async void OnAvailabilitySelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (userData.Role == "Student" || userData.Role == "student") {
            if (e.SelectedItem is Availability selectedAvailability)
            {
                var appointment = new Appointment {
                    FacultyId = facultyId, AppointmentStartTime = selectedAvailability.StartTime, StudentId = userData.Id, AppointmentEndTime = selectedAvailability.EndTime
                };

                bool confirmed = await DisplayAlert("Confirm Booking",
                          $"Do you want to book an appointment from {selectedAvailability.StartTime} to {selectedAvailability.EndTime}?",
                          "Yes",
                          "No");

                if (confirmed)
                {
                    await BookAppointmentAsync(appointment);
                }
                
                //await Navigation.PushAsync(new ShowAvailabilityPage(selectedAvailability.Id));
            }
        }
        
    }

    async Task BookAppointmentAsync(Appointment appointment)
    {
        await firebaseClient.Child("users").Child(userData.Id).Child("appointments").PostAsync(appointment);
        await firebaseClient.Child("users").Child(facultyId).Child("appointments").PostAsync(appointment);
        await firebaseClient.Child("faculty").Child(facultyId).Child("appointments").PostAsync(appointment);

        await Navigation.PopAsync();
    }
}
