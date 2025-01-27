using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista 1
        List<int> lista1 = new List<int>();
        // Lista 2
        List<int> lista2 = new List<int>();

        // Ciclo para cargar la primera lista
        Console.WriteLine("Ingrese la cantidad de elementos para la primera lista:");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los elementos para la primera lista:");
        for (int i = 0; i < n1; i++)
        {
            lista1.Add(int.Parse(Console.ReadLine()));
        }

        // Ciclo para cargar la segunda lista
        Console.WriteLine("Ingrese la cantidad de elementos para la segunda lista:");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los elementos para la segunda lista:");
        for (int i = 0; i < n2; i++)
        {
            lista2.Add(int.Parse(Console.ReadLine()));
        }

        // Verificación de si las listas son iguales en tamaño y contenido
        if (lista1.Count == lista2.Count)
        {
            bool iguales = true;
            for (int i = 0; i < lista1.Count; i++)
            {
                if (lista1[i] != lista2[i])
                {
                    iguales = false;
                    break;
                }
            }

            if (iguales)
            {
                Console.WriteLine("Las listas son iguales en tamaño y en contenido.");
            }
            else
            {
                Console.WriteLine("Las listas son iguales en tamaño pero no en contenido.");
            }
        }
        else
        {
            Console.WriteLine("Las listas no tienen el mismo tamaño ni contenido.");
        }
    }
}
