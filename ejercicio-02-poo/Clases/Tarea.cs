 public class Tarea : IExportable
    {
    
        private static int contador = 1;

        
        public int Id { get; private set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad Prioridad { get; set; }

        public string Categoria { get; set; }

        public bool Completada { get; set; }

        public DateTime FechaCreacion { get; set; }

       
        public Tarea()
        {
            Id = contador++;
            FechaCreacion = DateTime.Now;
            Completada = false;

            Titulo = "";
            Descripcion = "";
            Categoria = "";
            Prioridad = Prioridad.Media;
        }

       
        public virtual void MostrarInfo()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Categoría: {Categoria}");
            Console.WriteLine($"Prioridad: {Prioridad}");
            Console.WriteLine($"Completada: {(Completada ? "Sí" : "No")}");
            Console.WriteLine($"Fecha creación: {FechaCreacion}");
        }

    g Exportar()
        {
            return $"{Id}|{Titulo}|{Prioridad}|{Completada}";
        }
    }
}
