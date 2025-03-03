using System;
using System.Collections.Generic;

namespace MyCSharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Universidad Estatal Amazonica");

            // Diccionario con las palabras iniciales
            Dictionary<string, string> diccionario = new Dictionary<string, string>
            {
                { "Time", "tiempo" },
                { "Person", "persona" },
                { "Year", "año" },
                { "Way", "camino/forma" },
                { "Day", "día" },
                { "Thing", "cosa" },
                { "Man", "hombre" },
                { "World", "mundo" },
                { "Life", "vida" },
                { "Hand", "mano" },
                { "Part", "parte" },
                { "Child", "niño/a" },
                { "Eye", "ojo" },
                { "Woman", "mujer" },
                { "Place", "lugar" },
                { "Work", "trabajo" },
                { "Week", "semana" },
                { "Case", "caso" },
                { "Point", "punto/tema" },
                { "Government", "gobierno" },
                { "Company", "empresa/compañía" }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("=======================================================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Ingresar más palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    // Traducir una frase
                    Console.Write("El hombre y la mujer están trabajando en el mundo: ");
                    string frase = Console.ReadLine();
                    string[] palabras = frase.Split(' ');
                    List<string> fraseTraducida = new List<string>();

                    foreach (var palabra in palabras)
                    {
                        string palabraTraducida;
                        // Si la palabra está en el diccionario, la traducimos
                        if (diccionario.TryGetValue(palabra, out palabraTraducida))
                        {
                            fraseTraducida.Add(palabraTraducida);
                        }
                        else
                        {
                            fraseTraducida.Add(palabra); // Si no está, la dejamos igual
                        }
                    }

                    Console.WriteLine("El man y la woman están trabajando en el mundo: " + string.Join(" ", fraseTraducida));
                }
                else if (opcion == 2)
                {
                    // Ingresar más palabras al diccionario
                    Console.Write("Ingrese la palabra en inglés: ");
                    string palabraIngles = Console.ReadLine();
                    Console.Write("Ingrese su traducción en español: ");
                    string palabraEspanol = Console.ReadLine();

                    if (!diccionario.ContainsKey(palabraIngles))
                    {
                        diccionario.Add(palabraIngles, palabraEspanol);
                        Console.WriteLine("Palabra agregada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("La palabra ya existe en el diccionario.");
                    }
                }
                else if (opcion == 0)
                {
                    // Salir
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida, por favor elija otra opción.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
