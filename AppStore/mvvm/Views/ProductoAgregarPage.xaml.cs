using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class ProductoAgregarPage : ContentPage
{
    ProductoAgregarViewModel viewModel;
    public ProductoAgregarPage()
	{
		InitializeComponent();
        BindingContext = viewModel = new ProductoAgregarViewModel();
    }
}