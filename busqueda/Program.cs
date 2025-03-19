using System;

class Program
{
    static void Main()
    {
        string[] nombres = new string[5];

        
        Console.WriteLine("Ingrese 5 nombres:");
        for (int i = 0; i < nombres.Length; i++)
        {
            Console.Write($"Nombre {i + 1}: ");
            nombres[i] = Console.ReadLine();
        }

        
        Console.Write("\nIngrese el nombre que desea buscar: ");
        string nombreBuscar = Console.ReadLine();

        
        int posicion = Array.IndexOf(nombres, nombreBuscar);

    
        if (posicion != -1)
        {
            Console.WriteLine($"El nombre '{nombreBuscar}' se encuentra en la posición {posicion}.");
        }
        else
        {
            Console.WriteLine($"El nombre '{nombreBuscar}' no está en el arreglo.");
        }
    }
}
