using System;
using System.Linq; // Necesario para usar .Where()

class Program
{
    static void Main()
    {
        int[] numeros = new int[10];

       
        Console.WriteLine("Ingresa 10 números:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

       
        Console.Write("Ingrese el número que desea eliminar: ");
        int numeroAEliminar = int.Parse(Console.ReadLine());

        int[] nuevoArreglo = numeros.Where(n => n != numeroAEliminar).ToArray();

        
        if (nuevoArreglo.Length == numeros.Length)
        {
            Console.WriteLine("El número no está en la lista.");
        }
        else
        {
           
            Console.WriteLine("Nuevo arreglo sin el número eliminado:");
            foreach (int num in nuevoArreglo)
            {
                Console.Write(num + " ");
            }
        }
    }
}
