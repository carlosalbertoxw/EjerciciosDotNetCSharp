namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 30 - Pruebas unitarias (principios).
/// Principio: una prueba unitaria verifica automáticamente que una unidad de
/// código hace lo esperado, siguiendo el patrón AAA (Arrange, Act, Assert). Aquí
/// implementamos un mini verificador para mostrar la IDEA. Las pruebas reales con
/// xUnit de esta misma función están en EjerciciosDotNetCSharp.Tests/.
/// </summary>
public class E30_PruebasUnitarias : IEjercicio
{
    public string Titulo => "Pruebas unitarias (patrón AAA)";

    public void Ejecutar()
    {
        Console.WriteLine("Ejecutando pruebas sobre la función EsPrimo()...\n");

        int pasadas = 0, fallidas = 0;

        // Una prueba escrita con sus tres pasos a la vista:
        int numero = 7;                         // Arrange: preparar los datos
        bool obtenido = EsPrimo(numero);        // Act: ejecutar la unidad
        Verificar("7 es primo", esperado: true, obtenido, ref pasadas, ref fallidas);   // Assert

        // Las demás, de forma abreviada:
        Verificar("2 es primo", esperado: true, EsPrimo(2), ref pasadas, ref fallidas);
        Verificar("9 no es primo", esperado: false, EsPrimo(9), ref pasadas, ref fallidas);
        Verificar("1 no es primo", esperado: false, EsPrimo(1), ref pasadas, ref fallidas);
        Verificar("negativo no es primo", esperado: false, EsPrimo(-5), ref pasadas, ref fallidas);

        Console.WriteLine($"\nResultado: {pasadas} pasadas, {fallidas} fallidas.");
        Console.WriteLine("\nPara ver las mismas pruebas con xUnit: dotnet test");
    }

    // Unidad bajo prueba: una función pura, fácil de testear.
    public static bool EsPrimo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= n / i; i++)
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
