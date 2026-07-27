using System;
using System.IO;

class Program
{
    static int validas = 0;
    static int invalidas = 0;

    static int visa = 0;
    static int mastercard = 0;
    static int amex = 0;
    static int discover = 0;
    static int desconocidas = 0;

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("=== VALIDADOR DE TARJETAS ===");
            Console.WriteLine("1. Validar una tarjeta");
            Console.WriteLine("2. Validar desde archivo");
            Console.WriteLine("3. Generar número válido");
            Console.WriteLine("4. Estadísticas");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            switch (opcion)
            {
                case 1:

                    Console.Write("Ingrese el número de tarjeta: ");
                    string numero = Console.ReadLine();

                    string marca = IdentificarMarca(numero);
                    bool valida = ValidarTarjeta(numero);

                    ActualizarEstadisticas(marca, valida);

                    Console.WriteLine();
                    Console.WriteLine("Número: " + numero);
                    Console.WriteLine("Marca : " + marca);

                    if (valida)
                        Console.WriteLine("Estado: ✅ VÁLIDA");
                    else
                        Console.WriteLine("Estado: ❌ INVÁLIDA");

                    break;

                case 2:

                    Console.Write("Ruta del archivo: ");
                    string ruta = Console.ReadLine();

                    ValidarDesdeArchivo(ruta);

                    break;

                case 3:

                    string tarjeta = GenerarNumeroValido();

                    Console.WriteLine("Número generado:");
                    Console.WriteLine(tarjeta);
                    Console.WriteLine("Marca: " + IdentificarMarca(tarjeta));

                    break;

                case 4:

                    MostrarEstadisticas();

                    break;

                case 5:

                    Console.WriteLine("Saliendo...");
                    break;

                default:

                    Console.WriteLine("Opción incorrecta");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Presione ENTER...");
            Console.ReadLine();

        } while (opcion != 5);
    }

    
    static void ActualizarEstadisticas(string marca, bool valida)
    {
        if (valida)
            validas++;
        else
            invalidas++;

        switch (marca)
        {
            case "Visa":
                visa++;
                break;

            case "Mastercard":
                mastercard++;
                break;

            case "American Express":
                amex++;
                break;

            case "Discover":
                discover++;
                break;

            default:
                desconocidas++;
                break;
        }
    }    static bool ValidarTarjeta(string numero)
    {
        int suma = 0;
        bool duplicar = false;

        for (int i = numero.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(numero[i]))
                return false;

            int digito = numero[i] - '0';

            if (duplicar)
            {
                digito *= 2;

                if (digito > 9)
                    digito -= 9;
            }

            suma += digito;
            duplicar = !duplicar;
        }

        return suma % 10 == 0;
    }

    static string IdentificarMarca(string numero)

    {
        if (numero.StartsWith("4") &&
            (numero.Length == 13 || numero.Length == 16))
        {
            return "Visa";
        }

        if ((numero.StartsWith("51") ||
             numero.StartsWith("52") ||
             numero.StartsWith("53") ||
             numero.StartsWith("54") ||
             numero.StartsWith("55")) &&
             numero.Length == 16)
        {
            return "Mastercard";
        }

        if ((numero.StartsWith("34") ||
             numero.StartsWith("37")) &&
             numero.Length == 15)
        {
            return "American Express";
        }

        if ((numero.StartsWith("6011") ||
             numero.StartsWith("65")) &&
             numero.Length >= 16 &&
             numero.Length <= 19)
        {
            return "Discover";
        }

        return "Desconocida";
    }

    static void ValidarDesdeArchivo(string ruta)

    {
        try
        {
            string[] tarjetas = File.ReadAllLines(ruta);

            foreach (string linea in tarjetas)
            {
                string numero = linea.Trim();

                string marca = IdentificarMarca(numero);
                bool valida = ValidarTarjeta(numero);

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Número: " + numero);
                Console.WriteLine("Marca : " + marca);

                if (valida)
                    Console.WriteLine("Estado: ✅ VÁLIDA");
                else
                    Console.WriteLine("Estado: ❌ INVÁLIDA");

                ActualizarEstadisticas(marca, valida);
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Todas las tarjetas fueron procesadas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo:");
            Console.WriteLine(ex.Message);
        }
    }

    static string GenerarNumeroValido()

    {
        Random random = new Random();

        string numero = "4";

        while (numero.Length < 15)
        {
            numero += random.Next(0, 10);
        }

        for (int ultimo = 0; ultimo <= 9; ultimo++)
        {
            string tarjetaCompleta = numero + ultimo;

            if (ValidarTarjeta(tarjetaCompleta))
            {
                return tarjetaCompleta;
            }
        }

        return "";
    }

    static void MostrarEstadisticas()
    
    {
        Console.WriteLine();
        Console.WriteLine("===============================");
        Console.WriteLine("      ESTADÍSTICAS");
        Console.WriteLine("===============================");

        Console.WriteLine("Tarjetas válidas   : " + validas);
        Console.WriteLine("Tarjetas inválidas : " + invalidas);

        Console.WriteLine();

        Console.WriteLine("Desglose por marca:");
        Console.WriteLine("Visa               : " + visa);
        Console.WriteLine("Mastercard         : " + mastercard);
        Console.WriteLine("American Express   : " + amex);
        Console.WriteLine("Discover           : " + discover);
        Console.WriteLine("Desconocidas       : " + desconocidas);

        Console.WriteLine("===============================");
    }
}
    
    
