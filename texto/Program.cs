using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "Nombres.txt";

        Console.WriteLine("escribe los 5 nombres");
        using (StreamWriter Writer =new StreamWriter(filePath))
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"nombre {i + 1}: ");
                string nombre = Console.ReadLine();
                Writer.WriteLine(nombre);
            }
        }

        Console.WriteLine("\nLos nombres guardados son: ");
        using (StreamReader Reader = new StreamReader(filePath))
        {
            string line;
            while ((line = Reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }



    }

}