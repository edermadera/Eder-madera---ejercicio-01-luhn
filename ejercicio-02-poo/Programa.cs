
class Program
{
    static GestorTareas gestor = new GestorTareas();

    static void Main()
    {
        gestor.CargarDeJSON(@"Datos/tareas.json");

        int opcion;

        do
        {            Console.Clear();

            Console.WriteLine("=== GESTOR DE TAREAS ===");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Listar todas");
            Console.WriteLine("3. Listar por categoría");
            Console.WriteLine("4. Listar por prioridad");
            Console.WriteLine("5. Marcar como completada");
            Console.WriteLine("6. Mostrar tareas vencidas");
            Console.WriteLine("7. Eliminar tarea");
            Console.WriteLine("8. Exportar a JSON");
            Console.WriteLine("9. Salir");

            Console.Write("\nSelecciona una opción: ");
            try
            {
            opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nDebe ingresar un número válido.");
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();
                opcion = 0;
                continue;
            }

            switch (opcion)
            {
                case 1:

                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();

                    Console.Write("Descripción: ");
                    string descripcion = Console.ReadLine();

                    Console.WriteLine("\nPrioridad");
                    Console.WriteLine("1. Baja");
                    Console.WriteLine("2. Media");
                    Console.WriteLine("3. Alta");
                    Console.WriteLine("4. Critica");

                    Console.Write("Seleccione: ");
                    int opcionPrioridad = Convert.ToInt32(Console.ReadLine());

                    Prioridad prioridad = Prioridad.Baja;

                    switch (opcionPrioridad)
                    {
                        case 1:
                            prioridad = Prioridad.Baja;
                            break;

                        case 2:
                            prioridad = Prioridad.Media;
                            break;

                        case 3:
                            prioridad = Prioridad.Alta;
                            break;

                        case 4:
                            prioridad = Prioridad.Critica;
                            break;
                    }

                    Console.Write("Categoría: ");
                    string categoria = Console.ReadLine();

                    Console.Write("¿Tiene fecha de vencimiento? (S/N): ");
                    string respuesta = Console.ReadLine();

                    if (respuesta.ToUpper() == "S")
                    {
                        Console.Write("Fecha (yyyy-MM-dd): ");
                        DateTime fecha = DateTime.Parse(Console.ReadLine());

                        TareaConVencimiento tarea = new TareaConVencimiento();

                        tarea.Titulo = titulo;
                        tarea.Descripcion = descripcion;
                        tarea.Prioridad = prioridad;
                        tarea.Categoria = categoria;
                        tarea.FechaVencimiento = fecha;

                        gestor.Agregar(tarea);
                    }
                    else
                    {
                        Tarea tarea = new Tarea();

                        tarea.Titulo = titulo;
                        tarea.Descripcion = descripcion;
                        tarea.Prioridad = prioridad;
                        tarea.Categoria = categoria;

                        gestor.Agregar(tarea);
                    }

                    Console.WriteLine("\nTarea agregada correctamente.");
                    break;

                case 2:

                    List<Tarea> lista = gestor.ObtenerTodas();

                    if (lista.Count == 0)
                    {
                        Console.WriteLine("\nNo hay tareas registradas.");
                    }
                    else
                    {
                        Console.WriteLine();

                        foreach (Tarea tarea in lista)
                        {
                            tarea.MostrarInfo();
                            Console.WriteLine();
                        }
                    }

                    break;

                case 3:

                    Console.Write("Ingrese la categoría: ");
                    string categoriaBuscar = Console.ReadLine();

                    List<Tarea> listaCategoria = gestor.ListarPorCategoria(categoriaBuscar);

                    if (listaCategoria.Count == 0)
                    {
                        Console.WriteLine("\nNo hay tareas en esa categoría.");
                    }
                    else
                    {
                        Console.WriteLine();

                        foreach (Tarea tarea in listaCategoria)
                        {
                             tarea.MostrarInfo();
                             Console.WriteLine();
                        }
                    }

                    break;

                    
                case 4:

                    Console.WriteLine("Prioridades");
                    Console.WriteLine("1. Baja");
                    Console.WriteLine("2. Media");
                    Console.WriteLine("3. Alta");
                    Console.WriteLine("4. Critica");

                    Console.Write("Seleccione: ");
                    int op = Convert.ToInt32(Console.ReadLine());

                    Prioridad prioridadBuscar = Prioridad.Baja;

                    switch (op)
                    {
                    case 1:
                        prioridadBuscar = Prioridad.Baja;
                    break;

                    case 2:
                        prioridadBuscar = Prioridad.Media;
                    break;

                    case 3:
                        prioridadBuscar = Prioridad.Alta;
                    break;

                    case 4:
                        prioridadBuscar = Prioridad.Critica;
                    break;
                     }

                    List<Tarea> listaPrioridad = gestor.ListarPorPrioridad(prioridadBuscar);

                    if (listaPrioridad.Count == 0)
                    {
                         Console.WriteLine("\nNo hay tareas con esa prioridad.");
                    }
                    else
                    {
                        Console.WriteLine();

                        foreach (Tarea tarea in listaPrioridad)
                        {
                        tarea.MostrarInfo();
                        Console.WriteLine();
                        }
                    }

                    break;
                    
                case 5:

                    Console.Write("Ingrese el ID de la tarea: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    gestor.Completar(id);

                    Console.WriteLine("\nLa tarea fue marcada como completada.");

                 break;

                case 6:

                    List<Tarea> vencidas = gestor.ObtenerVencidas();

                    if (vencidas.Count == 0)
                    {
                        Console.WriteLine("\nNo hay tareas vencidas.");
                    }
                    else
                    {
                        Console.WriteLine("\nTAREAS VENCIDAS");
                        Console.WriteLine("========================");

                        foreach (Tarea tarea in vencidas)
                        {
                            tarea.MostrarInfo();
                            Console.WriteLine();
                        }
                    }

                    break;

                case 7:

                    Console.Write("Ingrese el ID de la tarea a eliminar: ");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());

                    gestor.Eliminar(idEliminar);

                    Console.WriteLine("\nTarea eliminada correctamente.");

                    break;

                case 8:

                    gestor.GuardarEnJSON(@"Datos/tareas.json");

                    Console.WriteLine("\nLas tareas fueron exportadas a Datos/tareas.json");

                    break;

                case 9:

                    gestor.GuardarEnJSON(@"Datos/tareas.json");

                    Console.WriteLine("\nTareas guardadas correctamente.");
                    Console.WriteLine("Hasta luego.");

                    break;

                default:
                    Console.WriteLine("\nOpción inválida.");
                    break;
            }

            if (opcion != 9)
            {
                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadLine();
            }
        } while (opcion != 9);
    }
    
}
