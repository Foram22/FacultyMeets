using System.ComponentModel;
using Firebase.Database;
using Firebase.Database.Query;

namespace FacultyMeets.ViewModels
{
	internal class RegisterViewModel: INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyBDIXe41Utd8_fkROzcijCmQ3CdWjZxWhI";
        public string databaseUrl = "https://facultymeets-default-rtdb.firebaseio.com/";

        private INavigation _navigation;
        public string name;
        public string email;
        public string role;
        public string password;
        public string id;
        public string selectedRole;
        public User userData;


        public string SelectedRole
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                RaisePropertyChanged("SelectedRole");
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Role
        {
            get => role;
            set
            {
                role = value;
                RaisePropertyChanged("Role");
            }
        }



        public Command RegisterUser { get; }
        public Command SetUserRole { get; }



        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;



        public RegisterViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
            SetUserRole = new Command<string>(SetUserRoleAsync);   
        }

        


        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                // Initialize Firebase Realtime Database client
                var firebaseClient = new FirebaseClient(databaseUrl);
                var childRef = firebaseClient.Child("users");
                var user = await childRef.PostAsync(new User
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    Role = "Student"
                });

                Preferences.Set("currentUser", user.Key);
                await _navigation.PushAsync(new RolePage());
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }



        private async void SetUserRoleAsync(string role)
        {
            try
            {
                var firebaseClient = new FirebaseClient(databaseUrl);
                var id = Preferences.Get("currentUser", "");

                if (id != null)
                {
                    var childRef = await firebaseClient.Child("users").Child(id).OnceSingleAsync<User>();

                    if (childRef != null && role != null)
                    {
                        childRef.Role = role;
                        await firebaseClient.Child("users").Child(id).PutAsync(userData);

                        await _navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Error while updateing the user role. \nPlease try again later.", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Error while updating the user role. \nPlease try again later.", "Ok");
                }

            }
            catch (FirebaseException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}

