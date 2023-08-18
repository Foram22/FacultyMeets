using FacultyMeets.ModelClasses;
using Firebase.Database;

namespace FacultyMeets;

public partial class FacultyPage : ContentView
{
	FirebaseClient client;
	List<Faculty> facultyList;
    List<Faculty> filteredFaculties; // To store filtered results

    public FacultyPage()
	{
		InitializeComponent();

		client = new FirebaseClient("https://facultymeets-default-rtdb.firebaseio.com/");

		facultyList = new List<Faculty>();
        filteredFaculties = new List<Faculty>();
        FacultyListView.ItemsSource = facultyList;

        LoadFacultyData();
    }

    async void LoadFacultyData()
    {
        var facultyData = await client.Child("faculty").OnceAsync<Faculty>();
        facultyList.Clear();

        foreach (var faculty in facultyData)
        {
            facultyList.Add(faculty.Object);
        }

        // Refresh the UI
        FacultyListView.ItemsSource = null;
        FacultyListView.ItemsSource = facultyList;
    }

    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        ApplySearchFilter();
    }

    void ApplySearchFilter()
    {
        var query = SearchBar.Text.ToLower();
        filteredFaculties.Clear();

        // Filter faculties based on the search query
        foreach (var faculty in facultyList)
        {
            if (faculty.Name.ToLower().Contains(query))
            {
                filteredFaculties.Add(faculty);
            }
        }

        FacultyListView.ItemsSource = null;
        FacultyListView.ItemsSource = filteredFaculties;
    }

    async void OnFacultySelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Faculty selectedFaculty)
        {
            await Navigation.PushAsync(new ShowAvailabilityPage(selectedFaculty.Id));
        }
    }
}
