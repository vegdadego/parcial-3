using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Ingrese la cantidad de números a ordenar: ");
        int n = int.Parse(Console.ReadLine());

        int[] numeros = new int[n];

        
        Console.WriteLine("\nIngrese los números:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (numeros[j] > numeros[j + 1])
                {
                    
                    int temp = numeros[j];
                    numeros[j] = numeros[j + 1];
                    numeros[j + 1] = temp;
                }
            }
        }

        
        Console.WriteLine("\nNúmeros ordenados de menor a mayor:");
        foreach (int num in numeros)
        {
            Console.Write(num + " ");
        }
    }
}
