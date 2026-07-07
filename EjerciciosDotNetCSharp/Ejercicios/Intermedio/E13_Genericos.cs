namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 13 - Genéricos.
/// Principio: escribir clases y métodos que funcionan con CUALQUIER tipo sin
/// perder la seguridad de tipos ni recurrir a 'object'. El tipo se decide al
/// usarlos (T). Las restricciones (where) limitan qué tipos se aceptan.
/// </summary>
public class E13_Genericos : IEjercicio
{
    public string Titulo => "Genéricos (clases y métodos <T>)";

    public void Ejecutar()
    {
        // Una misma clase Caja<T> sirve para int, string, lo que sea.
        var cajaNumero = new Caja<int>(42);
        var cajaTexto = new Caja<string>("hola");
        Console.WriteLine($"Caja<int>    contiene: {cajaNumero.Contenido}");
        Console.WriteLine($"Caja<string> contiene: {cajaTexto.Contenido}");

        // Método genérico: intercambia dos valores del mismo tipo.
        int x = 1, y = 2;
        Intercambiar(ref x, ref y);
        Console.WriteLine($"\nTras Intercambiar -> x={x}, y={y}");

        // Método genérico con restricción: solo tipos comparables.
        Console.WriteLine($"\nMayor(7, 3)         = {Mayor(7, 3)}");
        Console.WriteLine($"Mayor(\"pera\",\"uva\") = {Mayor("pera", "uva")}");
    }

    // Intercambia por referencia sin importar el tipo T.
    private static void Intercambiar<T>(ref T a, ref T b) => (a, b) = (b, a);

    // 'where T : IComparable<T>' obliga a que T sepa compararse consigo mismo.
    private static T Mayor<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) >= 0 ? a : b;

    /// <summary>Contenedor genérico simple.</summary>
    private class Caja<T>
    {
        public T Contenido { get; }
        public Caja(T contenido) => Contenido = contenido;
    }
}
