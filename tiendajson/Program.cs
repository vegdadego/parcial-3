using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    static string Inventario = "inventario.json";

    class Producto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }

    static void Main()
    {
        // creo la lista para ir agregando mis productos
        List<Producto> inventario = new List<Producto>();
        if (File.Exists(Inventario))
        {
            string json = File.ReadAllText(Inventario);
            inventario = JsonConvert.DeserializeObject<List<Producto>>(json) ?? new List<Producto>();
        }
        
        while (true)
        {
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar inventario");
            Console.WriteLine("3. Buscar por código o nombre");
            Console.WriteLine("4. Comprar producto");
            Console.WriteLine("5. Salir");

            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine();
            
            if (opcion == "1")
            {
                Producto nuevoProducto = new Producto();
                Console.Write("Ingrese el código del producto: ");
                nuevoProducto.codigo = Console.ReadLine();
                Console.Write("Ingrese el nombre del producto: ");
                nuevoProducto.nombre = Console.ReadLine();
                Console.Write("Ingrese la cantidad en stock: ");
                nuevoProducto.cantidad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el precio del producto: ");
                nuevoProducto.precio = decimal.Parse(Console.ReadLine());

                inventario.Add(nuevoProducto);
                File.WriteAllText(Inventario, JsonConvert.SerializeObject(inventario, Formatting.Indented));
            }
            // en el caso 2 se imprime los datos de los productos en el inventario
            else if (opcion == "2")
            {
                Console.WriteLine("Inventario:");
                foreach (var producto in inventario)
                {
                    Console.WriteLine($"Código: {producto.codigo}, Nombre: {producto.nombre}, Cantidad: {producto.cantidad}, Precio: {producto.precio:C}");
                }
                Console.WriteLine();
            }
            // el tercer caso busca por nombre  o por nombre uso el find para buscar el codigo y asi mismo con el nombre eh imprimo los datos del producto a encontrar
            else if (opcion == "3")
            {
                Console.Write("Ingrese el código o nombre del producto: ");
                string entradaBusqueda = Console.ReadLine().ToLower();
                Producto productoEncontrado = inventario.Find(p => p.codigo.ToLower() == entradaBusqueda || p.nombre.ToLower() == entradaBusqueda);
                
                if (productoEncontrado != null)
                {
                    Console.WriteLine($"Producto encontrado: Código: {productoEncontrado.codigo}, Nombre: {productoEncontrado.nombre}, Cantidad: {productoEncontrado.cantidad}, Precio: {productoEncontrado.precio:C}");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
                // en el cuarto caso se repite el proceso de el caso anterios y si el producto es encontrado se procede a solicitar la cantidad a comprar luego se suma el precio unitario del producto
                //y luego se le pide al usuario
            }
            else if (opcion == "4")
            {
                Console.Write("Ingrese el código o nombre del producto a comprar: ");
                string entradaCompra = Console.ReadLine().ToLower();
                Producto productoCompra = inventario.Find(p => p.codigo.ToLower() == entradaCompra || p.nombre.ToLower() == entradaCompra);
                
            

                if (productoCompra != null)
                {
                    Console.Write("Ingrese la cantidad a comprar: ");
                    int cantidadCompra = int.Parse(Console.ReadLine());
                    
                    if (cantidadCompra > 0 && cantidadCompra <= productoCompra.cantidad)
                    {
                        decimal totalPagar = cantidadCompra * productoCompra.precio;
                        Console.WriteLine($"Total a pagar: {totalPagar:C}");
                        Console.Write("Ingrese el monto con el que va a pagar: ");
                        decimal pago = decimal.Parse(Console.ReadLine());
                        
                        if (pago >= totalPagar)
                        // 
                        {
                            productoCompra.cantidad -= cantidadCompra;
                            // para que se actualize el stock y se le reste al inventario la compra del usuario
                            File.WriteAllText(Inventario, JsonConvert.SerializeObject(inventario, Formatting.Indented));
                            Console.WriteLine("Compra realizada con éxito.");
                            if (pago > totalPagar)
                            {
                                Console.WriteLine($"Su cambio es: {(pago - totalPagar):C}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Monto insuficiente. Compra cancelada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cantidad no válida o insuficiente en inventario.");
                    }
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }
            else if (opcion == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("opcion no es valida");
            }
        }
    }
}
