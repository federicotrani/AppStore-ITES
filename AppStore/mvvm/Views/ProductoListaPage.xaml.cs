using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class ProductoListaPage : ContentPage
{    
    public ProductoListaPage(ProductoListaViewModel _viewModel)
	{
        BindingContext = _viewModel;
        InitializeComponent();
	}
}