using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "texto.txt";

        //pedir al usuario que escriba un texto
        Console.WriteLine("Escribe un texto:");
        string texto = Console.ReadLine();

        // guardar el texto en el archivo
        File.WriteAllText(filePath, texto);
        Console.WriteLine("Texto guardado en 'texto.txt'.");

        // leer el archivo y contar palabras
        string contenido = File.ReadAllText(filePath);
        string[] palabras = contenido.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //' ' → Espacio en blanco (para separar palabras comunes).'\n' → Salto de línea (cuando el usuario presiona ENTER).'\r' → Retorno de carro (en algunos sistemas operativos como Windows).'\t' → Tabulación (para separar palabras si hay TABs en el texto).
        int cantidadPalabras = palabras.Length;

        // el resultado
        Console.WriteLine($"El texto contiene {cantidadPalabras} palabras.");
    }
}
