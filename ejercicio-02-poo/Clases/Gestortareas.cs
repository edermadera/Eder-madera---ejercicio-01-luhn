using System;
using System.Text.Json;

public class GestorTareas
{ 
    private List<Tarea> tareas = new List<Tarea>();

    public void Agregar(Tarea tarea)    
    {
    tareas.Add(tarea);
    }

         public void Completar(int id)
    {
    Tarea tarea = tareas.Find(t => t.Id == id);

        if (tarea != null)
        {
        tarea.Completada = true;
        }
    }

    public List<Tarea> ListarPorCategoria(string categoria)
    {
    return tareas.Where(t => t.Categoria == categoria).ToList();
    }

    public List<Tarea> ListarPorPrioridad(Prioridad prioridad)
    {
    return tareas.Where(t => t.Prioridad == prioridad).ToList();
    }
    public List<Tarea> ObtenerVencidas()
    {
    List<Tarea> vencidas = new List<Tarea>();

        foreach (Tarea tarea in tareas)
        {
            if (tarea is TareaConVencimiento)
             {
            TareaConVencimiento tv = (TareaConVencimiento)tarea;

            if (tv.FechaVencimiento < DateTime.Now)
            {
                vencidas.Add(tv);
            }
            }
        }   

    return vencidas;
    }
    
           public void Eliminar(int id)
    {
    Tarea tarea = tareas.Find(t => t.Id == id);

        if (tarea != null)
        {
        tareas.Remove(tarea);
        }
    }
            public void GuardarEnJSON(string archivo)   
    {
        try
        {
            string json = JsonSerializer.Serialize(tareas);

            File.WriteAllText(archivo, json);
        }
        catch
        {
            Console.WriteLine("Error al guardar el archivo.");
        }
    }

        public List<Tarea> CargarDeJSON(string archivo)
    {
        try
        {
            if (File.Exists(archivo))
            {   
                string json = File.ReadAllText(archivo);

                tareas = JsonSerializer.Deserialize<List<Tarea>>(json);

                if (tareas == null)
                {
                    tareas = new List<Tarea>();
                }
            }
        }
        catch
        {
            tareas = new List<Tarea>();

            Console.WriteLine("No se pudo cargar el archivo.");
        }

    return tareas;
    }
}
