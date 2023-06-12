﻿using tarea;
internal class Program
{
    private static void Main(string[] args)
    {
        static int ValidaIngreso()
        {
            int dato = 0;
            do
            {
                System.Console.WriteLine("Ingrese el numero de la id de la tarea que se realizo");
            } while (!int.TryParse(System.Console.ReadLine(), out dato));
            return dato;
        }
        string[] descripciones = {
    "Lavar ropa",
    "Cocinar",
    "Limpiar",
    "Ordenar",
    "Barrer",
    "Regar",
    "Planchar",
    "Pasear",
    "Cuidar",
    "Comprar",
    "Bañar",
    "Cortar",
    "Secar",
    "Fregar",
    "Cocer",
    "Tender",
    "Sobar",
    "Ordenar",
    "Doblar",
    "Podar"
};


        int cantTareas = 5;
        List<Tarea> pendientes = new List<Tarea>();
        List<Tarea> realizadas = new List<Tarea>();
        for (int i = 0; i < cantTareas; i++)
        {
            Random random = new Random();
            int numDescripcion = random.Next(0, 20);
            var tareanueva = new Tarea(i, descripciones[numDescripcion]);
            pendientes.Add(tareanueva);
        }
        void MostrarTareas(List<Tarea> lista)
        {
            int cantTareas = lista.Count;
            for (int i = 0; i < cantTareas; i++)
            {
                System.Console.WriteLine("La tarea numero " + lista[i].Id);
                System.Console.WriteLine("La descripcion de la tarea es:" + lista[i].Descripcion);
                System.Console.WriteLine("La duracion de la tarea es:" + lista[i].Duracion);
            }
        }
        System.Console.WriteLine("--------Tareas Pendientes--------");
        MostrarTareas(pendientes);
        System.Console.WriteLine("Se realizo alguna tarea?");
        string mover = System.Console.ReadLine();
        while (mover == "si")
        {
            int idBusca = ValidaIngreso();
            var tareaCopiada = pendientes.Find(t => t.Id == idBusca);
            realizadas.Add(tareaCopiada);
            pendientes.Remove(tareaCopiada);
            System.Console.WriteLine("--------Tareas Pendientes--------");
            MostrarTareas(pendientes);
            System.Console.WriteLine("--------Tareas Realizadas--------");
            MostrarTareas(realizadas);
            System.Console.WriteLine("Se realizo alguna otra tarea?");
            mover = System.Console.ReadLine();
        }
        System.Console.WriteLine("Desea Buscar alguna tarea por descripcion");
        mover = System.Console.ReadLine();
        if (string.Equals(mover, "si"))
        {
            buscartareas(pendientes);
        }
        void buscartareas(List<Tarea> lista)
        {
            System.Console.WriteLine("Ingrese la descripción de la tarea que busca:");
            string descrip = System.Console.ReadLine();
            var tareaBuscada = lista.Find(t => t.Descripcion == descrip);

            if (tareaBuscada != null)
            {
                System.Console.WriteLine("Tarea encontrada:");
                System.Console.WriteLine("ID: " + tareaBuscada.Id);
                System.Console.WriteLine("Descripción: " + tareaBuscada.Descripcion);
                System.Console.WriteLine("Duración: " + tareaBuscada.Duracion);
            }
            else
            {
                System.Console.WriteLine("No se encontró ninguna tarea con la descripción especificada.");
            }
        }
        int sumar(List<Tarea> lista)
        {
            int suma = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                suma += lista[i].Duracion;
            }
            return suma;
        }
        int suma = sumar(realizadas);
        var archivo = new StreamWriter("horastrabajadas.txt");
        archivo.WriteLine("Cantidad de Tareas realizadas:" + suma);
        archivo.Close();
    }

}