namespace AppStore.mvvm.Models;

public class Producto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int Stock { get; set; }
    public string RutaImagen { get; set; }
    public decimal Precio { get; set; }
    public int Categoria { get; set; }

}
