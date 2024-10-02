using AppStore.mvvm.Models;
using AppStore.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace AppStore.mvvm.ViewModels;

public partial class ProductoListaViewModel : BaseViewModel
{    

    [ObservableProperty] private ObservableCollection<Producto> _productos;
    [ObservableProperty] private Producto _productoSeleccionado;
    [ObservableProperty] private bool isRefreshing;

    public ProductoListaViewModel()
    {
        Title = "Lista de Productos";
        
        Task.Run(async () => { await GetProductos(); }).Wait();
    }

    [RelayCommand]
    private async Task GetProductos()
    {
        IsBusy = IsRefreshing = true;

        var productos = await ApiService.GetProductos();

        if (productos != null)
        {
            Productos = new ObservableCollection<Producto>(productos);
        }        

        IsBusy = IsRefreshing = false;
    }

    [RelayCommand]
    private async Task GoToDetalle()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductoDetallePage());
    }
}
