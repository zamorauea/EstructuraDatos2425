using System;

// Clase que representa a un Vehiculo 
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public decimal Precio { get; set; }
}
class Program
{
    static List<Vehiculo> vehiculos = new List<Vehiculo>();

    static void Main(string[] args)
    {
        // Agregar un vehículo
        Vehiculo vehiculo1 = new Vehiculo
        {
            Placa = "PYSO21",
            Marca = "Chevrolet",
            Modelo = "Luv Dmax",
            Año = 2002,
            Precio = 20000m
        };
        vehiculos.Add(vehiculo1);

        // Mostrar todos los vehículos
        foreach (var vehiculo in vehiculos)
        {
            Console.WriteLine($"Placa: {vehiculo.Placa}, Marca: {vehiculo.Marca}, Modelo: {vehiculo.Modelo}, Año: {vehiculo.Año}, Precio: {vehiculo.Precio:C}");
        }
    }
}