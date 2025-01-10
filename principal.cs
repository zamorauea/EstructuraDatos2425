using System;
using System.Collections.Generic;

// Clase Paciente
class Paciente
{
    public int IdPaciente { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Telefono { get; set; }

    public Paciente(int id, string nombre, int edad, string telefono)
    {
        IdPaciente = id;
        Nombre = nombre;
        Edad = edad;
        Telefono = telefono;
    }

    public override string ToString()
    {
        return $"ID: {IdPaciente}, Nombre: {Nombre}, Edad: {Edad}, Teléfono: {Telefono}";
    }
}

// Clase Turno
class Turno
{
    public int IdTurno { get; set; }
    public int IdPaciente { get; set; }
    public string Fecha { get; set; }
    public string Hora { get; set; }

    public Turno(int idTurno, int idPaciente, string fecha, string hora)
    {
        IdTurno = idTurno;
        IdPaciente = idPaciente;
        Fecha = fecha;
        Hora = hora;
    }

    public override string ToString()
    {
        return $"ID Turno: {IdTurno}, ID Paciente: {IdPaciente}, Fecha: {Fecha}, Hora: {Hora}";
    }
}

// Clase Agenda
class Agenda
{
    private List<Paciente> pacientes = new List<Paciente>();
    private List<Turno> turnos = new List<Turno>();

    public void AgregarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
    }

    public void AgregarTurno(Turno turno)
    {
        turnos.Add(turno);
    }

    public void ConsultarPacientes()
    {
        Console.WriteLine("Pacientes:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente);
        }
    }

    public void ConsultarTurnos()
    {
        Console.WriteLine("Turnos:");
        foreach (var turno in turnos)
        {
            Console.WriteLine(turno);
        }
    }

    public void BuscarTurnosPorPaciente(int idPaciente)
    {
        Console.WriteLine($"Turnos del paciente con ID {idPaciente}:");
        foreach (var turno in turnos)
        {
            if (turno.IdPaciente == idPaciente)
            {
                Console.WriteLine(turno);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Agenda agenda = new Agenda();

        // Agregar pacientes
        agenda.AgregarPaciente(new Paciente(1, "Ronnal Montoya", 50, "555-1234"));
        agenda.AgregarPaciente(new Paciente(2, "Viviana Zamora", 28, "555-5678"));
        agenda.AgregarPaciente(new Paciente(3, "Christian Calva", 40, "555-4589"));

        // Agregar turnos
        agenda.AgregarTurno(new Turno(1, 1, "2025-01-06", "09:00"));
        agenda.AgregarTurno(new Turno(2, 2, "2025-01-07", "10:00"));
        agenda.AgregarTurno(new Turno(3, 3, "2025-01-08", "11:00"));

        // Reportes
        agenda.ConsultarPacientes();
        Console.WriteLine();

        agenda.ConsultarTurnos();
        Console.WriteLine();

        agenda.BuscarTurnosPorPaciente(1);
    }
}

/*
Análisis de las estructuras utilizadas:

1. List<T>:
   Ventajas:
   - Fácil de usar y administrar.
   - Tamaño dinámico, lo que permite agregar y eliminar elementos de manera eficiente.
   - Soporta LINQ para consultas y manipulaciones complejas.

   Desventajas:
   - Operaciones de búsqueda pueden ser lentas si no está ordenado.
   - Ocupa más memoria que un array simple.

2. Clases y objetos:
   Ventajas:
   - Organizan los datos de manera modular y clara.
   - Facilitan la extensibilidad y reutilización del código.

   Desventajas:
   - Mayor complejidad inicial para problemas pequeños.

El uso de listas y POO permite un diseño claro, modular y escalable para la gestión de turnos y pacientes.
*/

