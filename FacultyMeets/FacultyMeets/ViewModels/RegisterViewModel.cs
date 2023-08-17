using System.ComponentModel;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

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

        public string Id
        {
            get => id;
            set {
                id = value;
                RaisePropertyChanged("Id");
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
        public Command LoginUser { get; }



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
            LoginUser = new Command(LoginUserAsync);
        }



        private async void LoginUserAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var firebaseUser = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);

                if (firebaseUser != null)
                {
                    var userId = firebaseUser.User.LocalId;

                    var firebaseClient = new FirebaseClient("https://facultymeets-default-rtdb.firebaseio.com/");
                    var users = await firebaseClient.Child("users").Child(userId).OnceSingleAsync<User>();
                    User userModel = new User
                    {
                        Name = users.Name,
                        Email = users.Email,
                        Password = users.Password,
                        Id = users.Id,
                        Role = users.Role
                    };

                    Xamarin.Essentials.Preferences.Set("user", JsonConvert.SerializeObject(userModel));
                    await _navigation.PushAsync(new MainHomePage());
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }


        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var firebaseUser = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);

                // Initialize Firebase Realtime Database client
                var firebaseClient = new FirebaseClient(databaseUrl);
                var childRef = firebaseClient.Child("users");

                if (firebaseUser != null && firebaseUser.User.LocalId != null)
                {
                    var user = childRef.Child(firebaseUser.User.LocalId).PutAsync(new User
                    {
                        Name = Name,
                        Email = Email,
                        Password = Password,
                        Role = "Student"
                    });

                    Preferences.Set("currentUser", firebaseUser.User.LocalId);

                    await _navigation.PushAsync(new RolePage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Error while registering the user role. \nPlease try again later.", "OK");
                }
                
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

                        if (role == "Faculty" || role == "faculty")
                        {
                            await firebaseClient.Child("faculty").Child(id).PutAsync(userData);
                        }

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

