using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class ProductoDetallePage : ContentPage
{
	private ProductoDetalleViewModel viewModel;
	public ProductoDetallePage()
	{
		InitializeComponent();
		BindingContext = viewModel = new ProductoDetalleViewModel();
	}
}