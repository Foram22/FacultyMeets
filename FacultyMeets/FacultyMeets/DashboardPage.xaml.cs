using FacultyMeets.ModelClasses;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

namespace FacultyMeets;

public partial class DashboardPage : ContentView
{
    FirebaseClient firebaseClient;
    User userData;

    public DashboardPage(User user)
	{
		InitializeComponent();
        // Initialize FirebaseClient with your Firebase URL
        firebaseClient = new FirebaseClient("https://facultymeets-default-rtdb.firebaseio.com/");

        userData = user;
        LoadAppointmentsAsync();
    }

    async void LoadAppointmentsAsync()
    {
        var appointmentData = await GetAppointmentAsync();
        AppointmentListView.ItemsSource = appointmentData;
    }

    async Task<List<Appointment>> GetAppointmentAsync()
    {
        var appointments = await firebaseClient.Child("users").Child(userData.Id).Child("appointments").OnceAsync<Appointment>();

        var list = new List<Appointment>();
        foreach (var item in appointments)
        {
            var appointment = item.Object;
            appointment.AppointmentEndTime = item.Object.AppointmentEndTime;
            appointment.AppointmentStartTime = item.Object.AppointmentStartTime;
            appointment.Name = await GetNameFromDb(appointment);
            list.Add(appointment);
        }
        return list;
    }

    private async Task<string> GetNameFromDb(Appointment appointment)
    {
        User userModel;

        if (userData.Role == "Faculty" || userData.Role == "faculty")
        {
            var users = await firebaseClient.Child("users").Child(appointment.StudentId).OnceSingleAsync<User>();
            userModel = new User
            {
                Name = users.Name,
                Email = users.Email,
                Password = users.Password,
                Id = users.Id,
                Role = users.Role
            };
        }
        else
        {
            var users = await firebaseClient.Child("users").Child(appointment.FacultyId).OnceSingleAsync<User>();
            userModel = new User
            {
                Name = users.Name,
                Email = users.Email,
                Password = users.Password,
                Id = users.Id,
                Role = users.Role
            };
        }

        
        return userModel.Name;
    }
}
