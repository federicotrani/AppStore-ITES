using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class ProductoModificarPage : ContentPage
{
	private ProductoModificarViewModel viewModel;
    public ProductoModificarPage()
	{
		InitializeComponent();
		BindingContext = viewModel = new ProductoModificarViewModel();
    }
}