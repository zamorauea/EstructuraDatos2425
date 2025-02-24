using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Universidad Estatala Amazonia!");
        }
    }

public class ProgramaVacunacion
{
    public static void Main()
    {
        // Crear un conjunto ficticio de 500 ciudadanos
        HashSet<string> ciudadanos = GenerarCiudadanos(500);

        // Crear conjuntos de ciudadanos vacunados con Pfizer y AstraZeneca
        HashSet<string> vacunadosPfizer = GenerarCiudadanos(75, "Pfizer");
        HashSet<string> vacunadosAstraZeneca = GenerarCiudadanos(75, "AstraZeneca");

        // Ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos vacunados solo con Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos vacunados solo con AstraZeneca
        HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // Mostrar resultados
        Console.WriteLine("Ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("Ciudadanos vacunados solo con Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos vacunados solo con AstraZeneca: " + soloAstraZeneca.Count);

        // Generar reporte
        GenerarReporte(noVacunados, soloPfizer, soloAstraZeneca);
    }

    public static HashSet<string> GenerarCiudadanos(int cantidad, string vacuna = null)
    {
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= cantidad; i++)
        {
            ciudadanos.Add($"Ciudadano {i} ({vacuna ?? "No Vacunado"})");
        }
        return ciudadanos;
    }

    public static void GenerarReporte(HashSet<string> noVacunados, HashSet<string> soloPfizer, 
                                       HashSet<string> soloAstraZeneca)
    {
        using (StreamWriter writer = new StreamWriter("reporte_vacunacion.txt"))
        {
            writer.WriteLine("Reporte de Vacunación COVID-19");
            writer.WriteLine("====================================");
            writer.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
            writer.WriteLine($"Ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
            writer.WriteLine($"Ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count}");
        }

        Console.WriteLine("Reporte generado en: reporte_vacunacion.txt");
    }
}
