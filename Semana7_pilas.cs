using System;
using System.Collections.Generic;

public static class PilasCE2
{
    public static void Run()
    {
        // Número de discos
        int numDiscos = 3;

        // Inicializamos las torres
        Stack<int> torre1 = new Stack<int>();
        Stack<int> torre2 = new Stack<int>();
        Stack<int> torre3 = new Stack<int>();

        // Inicializamos la Torre 1 con discos de tamaño 1 a numDiscos
        InicializarTorre(torre1, numDiscos);

        // Imprimimos el estado inicial de las torres
        ImprimirEstado(torre1, torre2, torre3);

        // Llamamos a la función recursiva para mover los discos
        ResolverTorres(numDiscos, torre1, torre3, torre2);

        // Imprimimos el estado final de las torres
        ImprimirEstado(torre1, torre2, torre3);
    }

    // Función para inicializar una torre con discos de 1 a numDiscos
    public static void InicializarTorre(Stack<int> torre, int numDiscos)
    {
        for (int i = numDiscos; i >= 1; i--)
        {
            torre.Push(i);
        }
    }

    // Función recursiva para resolver las Torres de Hanoi
    public static void ResolverTorres(int numDiscos, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (numDiscos == 1)
        {
            MoverDisco(origen, destino);
        }
        else
        {
            // Mover n-1 discos de origen a auxiliar usando destino como torre auxiliar
            ResolverTorres(numDiscos - 1, origen, auxiliar, destino);

            // Mover el disco restante de origen a destino
            MoverDisco(origen, destino);

            // Mover los n-1 discos de auxiliar a destino usando origen como torre auxiliar
            ResolverTorres(numDiscos - 1, auxiliar, destino, origen);
        }
    }

    // Función para mover un disco de una torre a otra
    public static void MoverDisco(Stack<int> origen, Stack<int> destino)
    {
        if (origen.Count > 0)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Moviendo disco {disco} de {GetNombreTorre(origen)} a {GetNombreTorre(destino)}");
        }
    }

    // Función para obtener el nombre de una torre basado en la pila
    public static string GetNombreTorre(Stack<int> torre)
    {
        if (torre == PilasCE2.torre1) return "Torre 1";
        if (torre == PilasCE2.torre2) return "Torre 2";
        if (torre == PilasCE2.torre3) return "Torre 3";
        return "Desconocida";
    }

    // Función para imprimir el estado de todas las torres
    public static void ImprimirEstado(Stack<int> torre1, Stack<int> torre2, Stack<int> torre3)
    {
        Console.WriteLine("\nEstado actual de las torres:");
        ImprimirPila(torre1, "Torre 1");
        ImprimirPila(torre2, "Torre 2");
        ImprimirPila(torre3, "Torre 3");
    }

    // Función para imprimir una pila
    public static void ImprimirPila(Stack<int> pila, string nombrePila)
    {
        Console.WriteLine($"{nombrePila}: ");
        if (pila.Count == 0)
        {
            Console.WriteLine("Vacía");
        }
        else
        {
            foreach (var disco in pila)
            {
                Console.WriteLine(disco);
            }
        }
        Console.WriteLine();
    }
    
    // Definimos las torres para poder obtener sus nombres correctamente en GetNombreTorre
    public static Stack<int> torre1 = new Stack<int>();
    public static Stack<int> torre2 = new Stack<int>();
    public static Stack<int> torre3 = new Stack<int>();
}
