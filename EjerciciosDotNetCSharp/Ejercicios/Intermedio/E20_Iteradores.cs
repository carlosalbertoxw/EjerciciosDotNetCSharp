namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 20 - Iteradores y evaluación perezosa (yield).
/// Principio: 'yield return' produce una secuencia elemento por elemento, SOLO
/// cuando se consume (lazy). Permite trabajar con secuencias infinitas o muy
/// grandes sin materializarlas en memoria de golpe.
/// </summary>
public class E20_Iteradores : IEjercicio
{
    public string Titulo => "Iteradores y evaluación perezosa (yield)";

    public void Ejecutar()
    {
        // Aunque Fibonacci() sería infinito, Take(10) solo pide 10 elementos.
        Console.WriteLine("Primeros 10 Fibonacci (secuencia infinita + Take):");
        foreach (long f in Fibonacci().Take(10))
            Console.Write($"{f} ");
        Console.WriteLine();

        // Un iterador propio que filtra valores.
        int[] datos = { 4, 7, 10, 3, 12, 5, 8 };
        Console.WriteLine("\nMayores que 6 (con yield):");
        foreach (int n in MayoresQue(datos, 6))
            Console.Write($"{n} ");
        Console.WriteLine();

        // Demostración de "pereza": el mensaje se imprime al consumir, no antes.
        Console.WriteLine("\nDemostración de evaluación perezosa:");
        var secuencia = ConLog();          // aquí NO se ejecuta nada todavía
        Console.WriteLine("  (aún no se ha producido ningún elemento)");
        Console.WriteLine($"  Primer elemento: {secuencia.First()}");
    }

    // Secuencia infinita: el llamador decide cuántos toma.
    private static IEnumerable<long> Fibonacci()
    {
        long a = 0, b = 1;
        while (true)
        {
            yield return a;
            (a, b) = (b, a + b);
        }
    }

    private static IEnumerable<int> MayoresQue(IEnumerable<int> fuente, int limite)
    {
        foreach (int x in fuente)
            if (x > limite)
                yield return x;
    }

    private static IEnumerable<int> ConLog()
    {
        Console.WriteLine("  -> produciendo 1");
        yield return 1;
        Console.WriteLine("  -> produciendo 2");
        yield return 2;
    }
}
