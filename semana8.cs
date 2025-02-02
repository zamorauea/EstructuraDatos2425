
public class Asistente
{
    // Propiedad que representa el ID del asistente
    public int Id { get; set; }

    // Propiedad que representa el nombre del asistente
    public string Nombre { get; set; }

    // Constructor que inicializa un nuevo asistente con su ID y nombre
    public Asistente(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}

public class Congreso
{
    // Cola que representa a los asistentes esperando para ser asignados a un asiento
    public Queue<Asistente> colaIngreso = new Queue<Asistente>();

    // Lista que almacena a los asistentes a medida que se les asigna un asiento
    public List<Asistente> asientosAsignados = new List<Asistente>();

    // Capacidad máxima de asientos disponibles en el congreso
    public const int MAX_ASIENTOS = 100;

    // Método para registrar un asistente en la cola
    public void RegistrarAsistente(string nombre)
    {
        // Verifica si hay espacio disponible en el auditorio
        if (colaIngreso.Count + asientosAsignados.Count < MAX_ASIENTOS)
        {
            // Crea un nuevo asistente con un ID único y el nombre proporcionado
            Asistente nuevoAsistente = new Asistente(colaIngreso.Count + 1, nombre);
            // Agrega el asistente a la cola de espera
            colaIngreso.Enqueue(nuevoAsistente);
            Console.WriteLine($"Asistente {nombre} registrado en la cola.");
        }
        else
        {
            // Informa que no hay más asientos disponibles
            Console.WriteLine("No hay más asientos disponibles.");
        }
    }

    // Método asincrónico que asigna asientos simultáneamente con dos tareas paralelas
    public async Task AsignarAsientosAsync()
    {
        // Simula dos personas asignando asientos simultáneamente
        Task tarea1 = Task.Run(() => AsignarAsientos());
        Task tarea2 = Task.Run(() => AsignarAsientos());
        
        // Espera a que ambas tareas terminen
        await Task.WhenAll(tarea1, tarea2);
    }

    // Objeto para sincronizar el acceso a los recursos compartidos entre hilos
    private readonly object lockObject = new object();

    // Método privado que asigna los asientos a los asistentes en la cola
    private void AsignarAsientos()
    {
        // Bloquea el acceso a los recursos compartidos mientras se asignan los asientos
        lock (lockObject)
        {
            // Asigna asientos mientras haya asistentes en la cola y espacio disponible
            while (colaIngreso.Count > 0 && asientosAsignados.Count < MAX_ASIENTOS)
            {
                // Toma al siguiente asistente de la cola
                Asistente asistente = colaIngreso.Dequeue();
                // Asigna el asiento al asistente
                asientosAsignados.Add(asistente);
                // Muestra en consola que el asiento ha sido asignado
                Console.WriteLine($"Asiento asignado a {asistente.Nombre} (ID: {asistente.Id}).");
            }
        }
    }

    // Método para mostrar el reporte de los asistentes asignados a los asientos
    public void MostrarReporte()
    {
        // Muestra un encabezado del reporte
        Console.WriteLine("\n---- Reporte de Asignación de Asientos ----");
        // Recorre la lista de asistentes asignados
        foreach (var asistente in asientosAsignados)
        {
            // Muestra el ID y nombre del asistente asignado
            Console.WriteLine($"Asiento {asistente.Id}: {asistente.Nombre}");
        }
    }
}

// Clase estática Cola que gestiona la simulación del congreso
public static class Cola
{
    // Método estático que gestiona el flujo de registro y asignación de asientos
    public static void Run()
    {
        // Crea una instancia de la clase Congreso para gestionar la asignación de asientos
        Congreso congreso = new Congreso();

        // Simulación de llegada de asistentes
        Console.WriteLine("Registrando asistentes...");
        // Intenta agregar más asistentes de los que hay asientos disponibles
        for (int i = 1; i <= 120; i++) // Intentando agregar más de 100 asistentes
        {
            congreso.RegistrarAsistente("Asistente" + i);
        }

        // Asignación de asientos, simulando que dos personas lo hagan simultáneamente
        Console.WriteLine("Asignando asientos...");
        congreso.AsignarAsientosAsync().Wait();

        // Muestra el reporte final con los asistentes asignados
        congreso.MostrarReporte();
    }
}
