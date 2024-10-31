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
    
    [ObservableProperty] private string rutaImagen;
    [ObservableProperty] private FileResult imagen;

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

        // validar datos
        if(string.IsNullOrEmpty(this.Nombre) || string.IsNullOrEmpty(this.Descripcion) || this.Stock <= 0 || this.Precio <= 0 || this.CategoriaSeleccionada == null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Datos incompletos. Verifique!", "Aceptar");
            return;
        }


        var registro = new Producto
        {
            Nombre = this.Nombre,
            Descripcion = this.Descripcion,
            Stock = this.Stock,
            Precio = Convert.ToDecimal(this.Precio),
            Categoria = this.CategoriaSeleccionada.Key,
            RutaImagen = this.RutaImagen,
            Imagen = this.Imagen
        };
        

        try
        {
            await ApiService.AgregarProductoConImagen(registro);

            await Application.Current.MainPage.DisplayAlert("Exito", "Se nuevo Producto.", "Aceptar");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
        }
      
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task FotoGaleria()
    {
        try
        {
            // tomar foto y guardar en variable 
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult foto = await MediaPicker.PickPhotoAsync();

                if (foto != null)
                {
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);
                    using Stream source = await foto.OpenReadAsync();
                    using FileStream fileStream = File.OpenWrite(localFilePath);
                    await source.CopyToAsync(fileStream);

                    RutaImagen = localFilePath;
                    Imagen = foto;
                }

            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Error al obtener foto", "Aceptar");
        }
    }

    [RelayCommand]
    private async Task TomarFoto()
    {
        try
        {
            // tomar foto y guardar en variable 
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult foto = await MediaPicker.CapturePhotoAsync();

                if (foto != null)
                {
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);
                    using Stream source = await foto.OpenReadAsync();
                    using FileStream fileStream = File.OpenWrite(localFilePath);
                    await source.CopyToAsync(fileStream);

                    RutaImagen = localFilePath;
                    Imagen = foto;
                }

            }
        }catch(Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Error al tomar foto", "Aceptar");
        }
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
            new Valor { Key = 5, Value = "Panificados" },
            new Valor { Key = 6, Value = "Varios" }
        };

        return categoriasValues;
    }
}
