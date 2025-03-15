using System;
using System.Collections.Generic;

public class Nodo
{
    public string Titulo { get; set; }
    public Nodo Izquierdo { get; set; }
    public Nodo Derecho { get; set; }

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierdo = null;
        Derecho = null;
    }
}

public class ArbolBinarioBusqueda
{
    private Nodo raiz;

    // Método para insertar un título en el árbol
    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        // Si el árbol está vacío, creamos un nuevo nodo
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        // Si el título es menor al valor actual, lo insertamos en el subárbol izquierdo
        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        }
        // Si el título es mayor, lo insertamos en el subárbol derecho
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo;
    }

    // Método para buscar un título en el árbol (búsqueda iterativa)
    public bool Buscar(string titulo)
    {
        Nodo actual = raiz;
        while (actual != null)
        {
            if (titulo == actual.Titulo)
            {
                return true; // Título encontrado
            }
            else if (string.Compare(titulo, actual.Titulo) < 0)
            {
                actual = actual.Izquierdo; // Ir al subárbol izquierdo
            }
            else
            {
                actual = actual.Derecho; // Ir al subárbol derecho
            }
        }
        return false; // Título no encontrado
    }
}

public class Program
{
    public static void Main()
    {
        // Encabezado principal
        Console.WriteLine("====================================");
        Console.WriteLine("     UNIVERSIDAD ESTATAL AMAZÓNICA  ");
        Console.WriteLine("====================================\n");

        // Creación del catálogo de revistas usando un árbol binario de búsqueda
        ArbolBinarioBusqueda catalogo = new ArbolBinarioBusqueda();

        // Se ingresan 10 títulos al catálogo
        string[] titulos = {
            "Revista de Ciencia",
            "Revista de Tecnología",
            "Revista de Arte",
            "Revista de Historia",
            "Revista de Salud",
            "Revista de Naturaleza",
            "Revista de Deportes",
            "Revista de Política",
            "Revista de Economía",
            "Revista de Filosofía"
        };

        foreach (var titulo in titulos)
        {
            catalogo.Insertar(titulo);
        }

        // Menú para interactuar con el catálogo
        Console.WriteLine("\nCatálogo de Revistas");
        Console.WriteLine("1. Buscar un título");
        Console.WriteLine("2. Salir");
        Console.Write("\nSeleccione una opción: ");
        string opcion = Console.ReadLine();

        if (opcion == "1")
        {
            Console.Write("\nIngrese el título a buscar: ");
            string tituloBusqueda = Console.ReadLine();

            // Se busca el título en el catálogo
            bool encontrado = catalogo.Buscar(tituloBusqueda);

            if (encontrado)
            {
                Console.WriteLine("\nEl título fue encontrado.");
            }
            else
            {
                Console.WriteLine("\nEl título no fue encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\nSaliendo del programa.");
        }
    }
}
