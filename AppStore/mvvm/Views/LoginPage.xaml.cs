using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class LoginPage : ContentPage
{
	private LoginViewModel viewModel;
    public LoginPage()
	{
		BindingContext = viewModel = new LoginViewModel();
        InitializeComponent();
	}
}