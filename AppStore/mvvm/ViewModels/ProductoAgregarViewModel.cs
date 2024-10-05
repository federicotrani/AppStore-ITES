using AppStore.mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppStore.mvvm.ViewModels;

public partial class ProductoAgregarViewModel : BaseViewModel
{
    [ObservableProperty] private string nombre;
    [ObservableProperty] private string descripcion;
    [ObservableProperty] private int stock;
    [ObservableProperty] private float precio;
    [ObservableProperty] List<Valor> listaCategorias;
    [ObservableProperty] private Valor categoriaSeleccionada;

    public ProductoAgregarViewModel()
    {
        Title = Constants.AppName;
        listaCategorias = GetCategoriasValues();
    }


    [RelayCommand]
    private async Task Cancelar()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task GrabarProducto()
    {
        

        var registro = new Producto
        {
            Nombre = this.Nombre,
            Descripcion = this.Descripcion,
            Stock = this.Stock,
            Precio = Convert.ToDecimal(this.Precio),
            Categoria = this.CategoriaSeleccionada.Key,
            RutaImagen = "producto.png"
        };
        

        try
        {
            await ApiService.AgregarProducto(registro);

            await Application.Current.MainPage.DisplayAlert("Exito", "Se nuevo Producto.", "Aceptar");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
        }
      
        await Application.Current.MainPage.Navigation.PopAsync();


    }

    private List<Valor> GetCategoriasValues()
    {
        // TODO: reemplazar por lista de valores de la base de datos
        var categoriasValues = new List<Valor>()
        {
            new Valor { Key = 1, Value = "Alimentos" },
            new Valor { Key = 2, Value = "Bebidas" },
            new Valor { Key = 3, Value = "Limpieza" },
            new Valor { Key = 4, Value = "Higiene" },
            new Valor { Key = 5, Value = "Varios" }
        };

        return categoriasValues;
    }
}
