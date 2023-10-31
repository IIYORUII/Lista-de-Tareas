using System;
using System.Collections.Generic;
using System.IO;

namespace ListaDeTareas
{
    class Program
    {
        static List<string> tareas = new List<string>();
        static string filePath = "tareas.txt";

        static void Main(string[] args)
        {
            CargarTareas();
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("▲▲▲▲▲▲▲BIENVENIDO AL GESTOR DE TAREAS!▼▼▼▼▼▼▼");                
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Marcar tarea como completada");
                Console.WriteLine("3. Ver lista de tareas");
                Console.WriteLine("4. Salir y guardar");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        MostrarTareas();
                        MarcarTareaComoCompletada();
                        break;
                    case "3":
                        MostrarTareas();
                        break;
                    case "4":
                        GuardarTareas();
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void AgregarTarea()
        {
            Console.Write("Ingrese la nueva tarea: ");
            string nuevaTarea = Console.ReadLine();
            tareas.Add(nuevaTarea);
            Console.WriteLine("Tarea agregada con éxito.");
        }

        static void MostrarTareas()
        {
            Console.WriteLine("Lista de tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

        static void MarcarTareaComoCompletada()
        {
            Console.Write("Ingrese el número de la tarea completada: ");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                if (indice > 0 && indice <= tareas.Count)
                {
                    tareas.RemoveAt(indice - 1);
                    Console.WriteLine("Tarea marcada como completada y eliminada de la lista.");
                }
                else
                {
                    Console.WriteLine("Índice fuera de rango. Intente nuevamente.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Intente nuevamente.");
            }
        }

        static void CargarTareas()
        {
            if (File.Exists(filePath))
            {
                tareas = new List<string>(File.ReadAllLines(filePath));
            }
        }

        static void GuardarTareas()
        {
            File.WriteAllLines(filePath, tareas);
            Console.WriteLine("Tareas guardadas en el archivo.");
        }
    }
}
