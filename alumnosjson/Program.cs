using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Estudiante
{
    public string Nombre { get; set; }
    public List<double> Calificaciones { get; set; }
    public double Promedio { get; set; }

    public bool Aprobado()
    {
        return Promedio >= 70;
    }
}

class Program
{
    static string archivoJson = "estudiantes.json";

    static void Main()
    {
        List<Estudiante> estudiantes = new List<Estudiante>();

        Console.Write("¿Cuántos estudiantes desea ingresar? ");
        int cantidad = int.Parse(Console.ReadLine());

        for (int i = 0; i < cantidad; i++)
        {
            Estudiante estudiante = new Estudiante();
            Console.Write($"Ingrese el nombre del estudiante {i + 1}: ");
            estudiante.Nombre = Console.ReadLine();

            estudiante.Calificaciones = new List<double>();
            for (int j = 1; j <= 3; j++)
            {
                Console.Write($"Ingrese la calificación del parcial {j}: ");
                estudiante.Calificaciones.Add(double.Parse(Console.ReadLine()));
            }

            estudiante.Promedio = CalcularPromedio(estudiante.Calificaciones);
            estudiantes.Add(estudiante);
        }

        // Guardar en JSON
        File.WriteAllText(archivoJson, JsonConvert.SerializeObject(estudiantes, Formatting.Indented));
        Console.WriteLine("\nDatos guardados correctamente en estudiantes.json.\n");

        // Leer y mostrar resultados
        string jsonLeido = File.ReadAllText(archivoJson);
        List<Estudiante> estudiantesGuardados = JsonConvert.DeserializeObject<List<Estudiante>>(jsonLeido);

        Console.WriteLine("\nResultados:");
        foreach (var est in estudiantesGuardados)
        {
            Console.WriteLine($"Nombre: {est.Nombre}, Promedio: {est.Promedio}, Estado: {(est.Aprobado() ? "Aprobado" : "Reprobado")}");
        }
    }

    static double CalcularPromedio(List<double> calificaciones)
    {
        double suma = 0;
        foreach (var calificacion in calificaciones)
        {
            suma += calificacion;
        }
        return suma / calificaciones.Count;
    }
}