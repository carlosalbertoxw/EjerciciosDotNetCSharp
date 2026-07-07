namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 16 - Structs vs clases (valor vs referencia).
/// Principio: un 'struct' se copia por VALOR (cada variable tiene su propia
/// copia); una 'class' se pasa por REFERENCIA (varias variables apuntan al
/// mismo objeto). Entender esto evita bugs sutiles.
/// </summary>
public class E16_StructsVsClasses : IEjercicio
{
    public string Titulo => "Structs vs clases (valor vs referencia)";

    public void Ejecutar()
    {
        // STRUCT: al asignar b = a se COPIA. Modificar b no afecta a a.
        Console.WriteLine("== struct (tipo por valor) ==");
        var pa = new PuntoStruct { X = 1, Y = 1 };
        var pb = pa;              // copia independiente
        pb.X = 99;
        Console.WriteLine($"pa = ({pa.X},{pa.Y})   <- no cambió");
        Console.WriteLine($"pb = ({pb.X},{pb.Y})   <- cambió solo la copia");

        // CLASS: al asignar b = a ambos apuntan al MISMO objeto.
        Console.WriteLine("\n== class (tipo por referencia) ==");
        var ca = new PuntoClass { X = 1, Y = 1 };
        var cb = ca;             // misma referencia
        cb.X = 99;
        Console.WriteLine($"ca = ({ca.X},{ca.Y})   <- también cambió!");
        Console.WriteLine($"cb = ({cb.X},{cb.Y})");

        // record struct: struct con las comodidades de un record (por valor).
        Console.WriteLine("\n== record struct (igualdad por valor) ==");
        var m1 = new Moneda(100, "COP");
        var m2 = new Moneda(100, "COP");
        Console.WriteLine($"m1 == m2 -> {m1 == m2}  (compara los datos, no la referencia)");

        Console.WriteLine("\nRegla práctica: usa struct para datos pequeños e " +
                          "inmutables (coordenadas, dinero); class para casi todo lo demás.");
    }

    private struct PuntoStruct { public int X; public int Y; }

    private class PuntoClass { public int X; public int Y; }

    private readonly record struct Moneda(decimal Monto, string Divisa);
}
