using System;

class Program
{
    static void Main()
    {
        int[] numeros = new int[5];

        
        Console.WriteLine("Ingrese 5 números enteros:");
        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        
        Console.WriteLine("\nArreglo original:");
        foreach (int num in numeros)
        {
            Console.Write(num + " ");
        }

        
        Array.Reverse(numeros);

        
        Console.WriteLine("\nArreglo invertido:");
        foreach (int num in numeros)
        {
            Console.Write(num + " ");
        }
    }
}
