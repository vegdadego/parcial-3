using System; 
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    //variable para el archivo json
    static string Inventario = "inventario.json";

    class Producto
    {
        // Propiedades de el producto
        public string codigo {get; set;}
        public string nombre {get; set;}
        public int cantidad {get; set;}
        public decimal precio {get; set;}

    }

    static void Main ()
    {
        List<Producto> inventario = new List<Producto>();
        // en caso de que ya exista el archivo se carga y se lee para tener datos
        if (File.Exists(Inventario))
        {
            string json = File.ReadAllText(Inventario);
            inventario = JsonConvert.DeserializeObject<List<Producto>>(json) ?? new List<Producto>();
        }
        // CASOS para el uso del codigo 
        while (true)
        {
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar inventario");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese una opcion: ");

            string opcion = Console.ReadLine();
            // para agregar los datos del producto 
            if (opcion == "1")
            {
                Producto nuevoProducto = new Producto();
                Console.Write("Ingrese el codigo del producto: ");
                nuevoProducto.codigo = Console.ReadLine();
                Console.Write("Ingrese el nombre del producto: ");
                nuevoProducto.nombre = Console.ReadLine();
                Console.Write("ingrese la cantidad en stock:");
                nuevoProducto.cantidad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el precio del producto: ");
                nuevoProducto.precio = decimal.Parse(Console.ReadLine());

                inventario.Add(nuevoProducto);
                // esto es para guardar los datos en el json
                File.WriteAllText(Inventario, JsonConvert.SerializeObject(inventario, Formatting.Indented));
                
            }
            else if (opcion == "2")
            {
                Console.WriteLine("Inventario:");
                foreach (var producto in inventario)
                {
                    Console.WriteLine($"Codigo: {producto.codigo}, Nombre: {producto.nombre}, Cantidad: {producto.cantidad}, Precio:{producto.precio:C}");

                }
                Console.WriteLine();
            }
            else if (opcion == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("la opcion no es valida por favor volver a intentar");
                
            }

        }
    }
}
