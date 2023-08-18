using FacultyMeets.ViewModels;

namespace FacultyMeets;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
    }
}
