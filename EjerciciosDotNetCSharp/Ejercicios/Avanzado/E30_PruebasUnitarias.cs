namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 30 - Pruebas unitarias (principios).
/// Principio: una prueba unitaria verifica automáticamente que una unidad de
/// código hace lo esperado, siguiendo el patrón AAA (Arrange, Act, Assert). En
/// proyectos reales se usa xUnit / NUnit / MSTest; aquí implementamos un mini
/// verificador para mostrar la IDEA sin dependencias externas.
/// </summary>
public class E30_PruebasUnitarias : IEjercicio
{
    public string Titulo => "Pruebas unitarias (patrón AAA)";

    public void Ejecutar()
    {
        Console.WriteLine("Ejecutando pruebas sobre la función EsPrimo()...\n");

        int pasadas = 0, fallidas = 0;

        // Cada prueba: Arrange (preparar) -> Act (ejecutar) -> Assert (verificar).
        Verificar("2 es primo", esperado: true, obtenido: EsPrimo(2), ref pasadas, ref fallidas);
        Verificar("7 es primo", esperado: true, obtenido: EsPrimo(7), ref pasadas, ref fallidas);
        Verificar("9 no es primo", esperado: false, obtenido: EsPrimo(9), ref pasadas, ref fallidas);
        Verificar("1 no es primo", esperado: false, obtenido: EsPrimo(1), ref pasadas, ref fallidas);
        Verificar("negativo no es primo", esperado: false, obtenido: EsPrimo(-5), ref pasadas, ref fallidas);

        Console.WriteLine($"\nResultado: {pasadas} pasadas, {fallidas} fallidas.");
        Console.WriteLine("\nCon xUnit esto sería: [Fact] public void EsPrimo_De7_DevuelveTrue()" +
                          " => Assert.True(EsPrimo(7));");
    }

    // Unidad bajo prueba: una función pura, fácil de testear.
    private static bool EsPrimo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    // Mini "assert": compara esperado vs obtenido e informa.
    private static void Verificar(string nombre, bool esperado, bool obtenido,
                                  ref int pasadas, ref int fallidas)
    {
        bool ok = esperado == obtenido;
        if (ok) pasadas++; else fallidas++;
        Console.WriteLine($"  [{(ok ? "PASA" : "FALLA")}] {nombre} " +
                          $"(esperado {esperado}, obtenido {obtenido})");
    }
}
