using System;

class Program
{
    static void Main()
    {
        int[,] matriz = new int[3, 3]; // Crear una matriz 3x3

        // pedir al usuario que ingrese los valores de la matriz
        Console.WriteLine("Ingrese los valores de la matriz 3x3:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Elemento [{i+1},{j+1}]: ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }

        //pedi al usuario un número para multiplicar cada fila
        int[] factores = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese el número por el que desea multiplicar la fila {i+1}: ");
            factores[i] = int.Parse(Console.ReadLine());
        }

        // Multiplica cada fila por el número ingresado
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matriz[i, j] *= factores[i]; // Multiplica el valor de la fila
            }
        }

        // Mostrar la nueva matriz
        Console.WriteLine("\nMatriz después de la multiplicación:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
