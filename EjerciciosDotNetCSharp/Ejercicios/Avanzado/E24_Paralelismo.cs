using System.Diagnostics;

namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 24 - Paralelismo (usar varios núcleos).
/// Principio: cuando el trabajo es intensivo en CPU e independiente, se puede
/// repartir entre varios hilos para terminar antes. C# ofrece Parallel.For y
/// PLINQ (AsParallel). CancellationToken permite cancelar de forma cooperativa.
/// Repartir también tiene un costo, así que solo compensa si el trabajo es grande.
/// </summary>
public class E24_Paralelismo : IEjercicio
{
    public string Titulo => "Paralelismo (Parallel.For, PLINQ)";

    public void Ejecutar()
    {
        int[] numeros = Enumerable.Range(1, 20).ToArray();

        // Con poco trabajo, repartirlo entre hilos puede costar más que hacerlo.
        Console.WriteLine("Trabajo PEQUEÑO (el reparto no siempre compensa):");
        Comparar(numeros, iteraciones: 1_000);

        // Con mucho trabajo, los varios núcleos sí se notan.
        Console.WriteLine($"\nTrabajo GRANDE ({Environment.ProcessorCount} núcleos disponibles):");
        Comparar(numeros, iteraciones: 5_000_000);

        // Parallel.ForEach: ejecuta un cuerpo por elemento en paralelo.
        Console.WriteLine("\nParallel.ForEach (el orden de salida NO es determinista):");
        Parallel.ForEach(new[] { "rojo", "verde", "azul", "amarillo" }, color =>
            Console.WriteLine($"  procesando {color} en hilo {Environment.CurrentManagedThreadId}"));

        // Cancelación cooperativa: quien inicia la operación decide cuándo cancelar
        // y el método solo recibe el token para comprobarlo.
        Console.WriteLine("\nCancelación cooperativa (se cancela a los 100 ms):");
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromMilliseconds(100));
        try
        {
            ContarHasta(1_000_000, cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  Operación cancelada correctamente.");
        }
    }

    private static void Comparar(int[] numeros, int iteraciones)
    {
        var reloj = Stopwatch.StartNew();
        long sumaSecuencial = numeros.Sum(n => TrabajoPesado(n, iteraciones));
        Console.WriteLine($"  Secuencial: suma={sumaSecuencial} en {reloj.ElapsedMilliseconds} ms");

        // PLINQ: .AsParallel() reparte el cálculo entre núcleos.
        reloj.Restart();
        long sumaParalela = numeros.AsParallel().Sum(n => TrabajoPesado(n, iteraciones));
        Console.WriteLine($"  PLINQ     : suma={sumaParalela} en {reloj.ElapsedMilliseconds} ms");
    }

    // Simula cálculo costoso (no usar Thread.Sleep en trabajo real de CPU).
    private static long TrabajoPesado(int n, int iteraciones)
    {
        long acc = 0;
        for (int i = 0; i < iteraciones; i++) acc += (n + i) % 7;
        return acc;
    }

    private static void ContarHasta(int limite, CancellationToken token)
    {
        for (int i = 1; i <= limite; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"  contando {i}");
            Thread.Sleep(30);   // simula trabajo para dar tiempo a la cancelación
        }
    }
}
