using System;
using System.ComponentModel;
using Firebase.Auth.Providers;
using Firebase.Database;
using Firebase.Database.Query;

namespace FacultyMeets.ModelClasses
{
	internal class RegisterViewModel: INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyBDIXe41Utd8_fkROzcijCmQ3CdWjZxWhI";

        private INavigation _navigation;
        public string name;
        public string email;
        public string role;
        public string password;
        public int id;


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

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(INavigation navigation)
        {
            RegisterUser = new Command(RegisterUserTappedAsync);
            this._navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                string databaseUrl = "https://facultymeets-default-rtdb.firebaseio.com/";

                // Initialize Firebase Realtime Database client
                var firebaseClient = new FirebaseClient(databaseUrl);
                var user = await firebaseClient.Child("users").PostAsync(new User
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    Role = "Student"
                });
                await _navigation.PushAsync(new RolePage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}

