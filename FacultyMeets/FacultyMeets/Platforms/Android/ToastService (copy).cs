using Android.Widget;
using FacultyMeets;
using Xamarin;

[assembly: Dependency(typeof(IToastService))]
namespace YourNamespace.Droid
{
    public class ToastService : IToastService
    {
        public void ShowToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}
