using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "ventas.csv";

       
        Console.Write("¿Cuántos productos desea registrar? ");
        int cantidadProductos = int.Parse(Console.ReadLine());

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Producto,Cantidad,PrecioUnitario"); 

            for (int i = 0; i < cantidadProductos; i++)
            {
                Console.Write("Nombre del producto: ");
                string producto = Console.ReadLine();

                Console.Write("Cantidad vendida: ");
                int cantidad = int.Parse(Console.ReadLine());

                Console.Write("Precio unitario: ");
                double precio = double.Parse(Console.ReadLine());

                // Guarda la información en el archivo
                writer.WriteLine($"{producto},{cantidad},{precio}");
            }
        }

        Console.WriteLine("\nRegistro de ventas guardado en 'ventas.csv'.");

        
        double totalVentas = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string linea;
            bool primeraLinea = true;

            while ((linea = reader.ReadLine()) != null)
            {
                // Salta la primera línea (encabezado)
                if (primeraLinea)
                {
                    primeraLinea = false;
                    continue;
                }

                // Separa los valores por coma
                string[] datos = linea.Split(',');
                string producto = datos[0];
                int cantidad = int.Parse(datos[1]);
                double precioUnitario = double.Parse(datos[2]);

                // Calcula el total de ese producto y sumarlo al total general
                double totalProducto = cantidad * precioUnitario;
                totalVentas += totalProducto;
            }
        }

        // Mostrar el total de ventas
        Console.WriteLine($"\nTotal de ventas del día: ${totalVentas:F2}");
    }
}
