using System;
class Program
{
   static void Main()
   {
       // Declaración de un arreglo de enteros con 5 elementos
       int[] numeros = new int[10];
          int suma = 0;
       
       Console.WriteLine("Ingrese 10 números enteros: ");
         for (int i = 0; i < 10; i++)
         {
              Console.Write("Número {0}: ", i + 1);
              numeros[i] = int.Parse(Console.ReadLine());
              suma += numeros[i];
         }

         double promedio = (double)suma / numeros.Length;

         Console.WriteLine("la suma total de los valores es: " + suma);
         Console.WriteLine("El promedio de los valores es: " + promedio);
   }
}