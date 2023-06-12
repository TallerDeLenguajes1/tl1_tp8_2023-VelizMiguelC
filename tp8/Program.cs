﻿internal class Program
{
    private static void Main(string[] args)
    {
        // Solicitar al usuario que ingrese el path de la carpeta
        Console.WriteLine("Ingrese el path de la carpeta:");
        string carpetaPath = Console.ReadLine();

        // Verificar si el directorio existe
        if (Directory.Exists(carpetaPath))
        {
            // Obtener la lista de archivos en la carpeta
            string[] archivos = Directory.GetFiles(carpetaPath);

            // Crear el archivo CSV "index.csv"
            string csvFilePath = Path.Combine(carpetaPath, "index.csv");
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                // Escribir las cabeceras en el archivo CSV
                writer.WriteLine("Índice,Nombre,Extensión");

                // Recorrer los archivos y escribirlos en el archivo CSV
                for (int i = 0; i < archivos.Length; i++)
                {
                    string nombreArchivo = Path.GetFileName(archivos[i]);
                    string extensionArchivo = Path.GetExtension(archivos[i]);
                    writer.WriteLine($"{i + 1},{nombreArchivo},{extensionArchivo}");
                }
            }

            Console.WriteLine("Se ha creado el archivo CSV \"index.csv\" con el listado de archivos.");
        }
        else
        {
            Console.WriteLine("El directorio ingresado no existe.");
        }
    }

}