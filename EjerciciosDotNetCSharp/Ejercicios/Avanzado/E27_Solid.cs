namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 27 - Principios SOLID.
/// Principio: cinco reglas de diseño para código mantenible y flexible:
///  S - Responsabilidad única   O - Abierto/cerrado
///  L - Sustitución de Liskov    I - Segregación de interfaces
///  D - Inversión de dependencias
/// Aquí demostramos O (abierto/cerrado) con un ejemplo ejecutable.
/// </summary>
public class E27_Solid : IEjercicio
{
    public string Titulo => "Principios SOLID";

    public void Ejecutar()
    {
        Console.WriteLine("S - Responsabilidad Única: cada clase tiene un solo motivo para cambiar.");
        Console.WriteLine("O - Abierto/Cerrado: abierto a extensión, cerrado a modificación.");
        Console.WriteLine("L - Liskov: una subclase debe poder sustituir a su base sin romper nada.");
        Console.WriteLine("I - Segregación de Interfaces: muchas interfaces pequeñas > una enorme.");
        Console.WriteLine("D - Inversión de Dependencias: depende de abstracciones, no de detalles.");

        // Demostración de O: para agregar una figura nueva NO tocamos el
        // calculador; solo creamos otra clase que implemente IArea.
        Console.WriteLine("\n== Abierto/Cerrado en acción ==");
        IArea[] figuras =
        {
            new Cuadrado(4),
            new TrianguloRect(3, 6),
            // Agregar aquí un Circulo NO requiere cambiar SumarAreas().
        };

        Console.WriteLine($"Área total: {SumarAreas(figuras):F2}");
        Console.WriteLine("\nPara añadir una figura nueva basta con crear otra clase " +
                          "que implemente IArea: el código existente queda intacto.");
    }

    // Cerrado a modificación: no cambia aunque agreguemos figuras.
    private static double SumarAreas(IEnumerable<IArea> figuras)
        => figuras.Sum(f => f.Area());

    private interface IArea { double Area(); }

    private record Cuadrado(double Lado) : IArea
    {
        public double Area() => Lado * Lado;
    }

    private record TrianguloRect(double Base, double Altura) : IArea
    {
        public double Area() => Base * Altura / 2;
    }
}
