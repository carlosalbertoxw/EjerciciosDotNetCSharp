namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 10 - Interfaces.
/// Principio: una interfaz define un CONTRATO (que metodos deben existir) sin
/// decir COMO se implementan. Distintas clases pueden cumplir el mismo contrato,
/// lo que favorece el bajo acoplamiento.
/// </summary>
public class E10_Interfaces : IEjercicio
{
    public string Titulo => "Interfaces (contratos)";

    public void Ejecutar()
    {
        // Cualquier clase que implemente IFiguraGeometrica sirve aqui.
        var figuras = new List<IFiguraGeometrica>
        {
            new Circulo(3),
            new Rectangulo(4, 5),
        };

        foreach (IFiguraGeometrica figura in figuras)
            Console.WriteLine($"{figura.Nombre,-12} -> area = {figura.CalcularArea():F2}");
    }
}

/// <summary>Contrato: toda figura debe tener un nombre y saber calcular su area.</summary>
public interface IFiguraGeometrica
{
    string Nombre { get; }
    double CalcularArea();
}

public class Circulo : IFiguraGeometrica
{
    private readonly double _radio;

    public Circulo(double radio) => _radio = radio;

    public string Nombre => "Circulo";

    public double CalcularArea() => Math.PI * _radio * _radio;
}

public class Rectangulo : IFiguraGeometrica
{
    private readonly double _ancho;
    private readonly double _alto;

    public Rectangulo(double ancho, double alto)
    {
        _ancho = ancho;
        _alto = alto;
    }

    public string Nombre => "Rectangulo";

    public double CalcularArea() => _ancho * _alto;
}
