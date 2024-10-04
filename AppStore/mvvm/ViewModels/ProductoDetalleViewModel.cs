using CommunityToolkit.Mvvm.Input;

namespace AppStore.mvvm.ViewModels;

public partial class ProductoDetalleViewModel : BaseViewModel
{
    public ProductoDetalleViewModel()
    {
        Title = Constants.AppName;
    }

    [RelayCommand] private async Task Cancelar()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task Grabar()
    {
        await Application.Current.MainPage.DisplayAlert("Carrito", "Producto agregado al registro", "Aceptar");
    }
}
