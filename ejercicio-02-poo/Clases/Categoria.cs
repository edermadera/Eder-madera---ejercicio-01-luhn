public class ejercicio_02poo
{
    public string Nombre { get; set; }

    public string Color { get; set; }

    public string Descripcion { get; set; }

    public Categoria()
    {

    }

    public Categoria(string nombre, string color, string descripcion)
    {
        Nombre = nombre;
        Color = color;
        Descripcion = descripcion;
    }
}
