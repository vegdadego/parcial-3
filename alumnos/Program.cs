using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "notas.txt";

        // solicitar la cantidad de alumnos
        Console.WriteLine("¿Cuántos alumnos va a ingresar?");
        int cantidad = int.Parse(Console.ReadLine());

        // escribir la información en el archivo
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Ingrese el nombre del alumno {i + 1}:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Primera calificación:");
                double calificacion1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Segunda calificación:");
                double calificacion2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Tercera calificación:");
                double calificacion3 = double.Parse(Console.ReadLine());

                // Guardamos la información en el archivo
                writer.WriteLine($"{nombre},{calificacion1},{calificacion2},{calificacion3}");
            }
        }

       //Leer el archivo y calcular los promedios
        Console.WriteLine("Promedios de los estudiantes ");
        using (StreamReader reader = new StreamReader(filePath))
        {
            string linea;
            while ((linea = reader.ReadLine()) != null)
            {
                string[] datos = linea.Split(',');
                string nombre = datos[0];
                double calificacion1 = double.Parse(datos[1]);
                double calificacion2 = double.Parse(datos[2]);
                double calificacion3 = double.Parse(datos[3]);

                double promedio = (calificacion1 + calificacion2 + calificacion3) / 3;

                Console.WriteLine($"{nombre}: Promedio = {promedio:F2}");
            }
        }
    }
}
