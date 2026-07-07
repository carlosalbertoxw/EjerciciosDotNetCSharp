using System.Diagnostics;

namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 24 - Paralelismo (usar varios núcleos).
/// Principio: cuando el trabajo es intensivo en CPU e independiente, se puede
/// repartir entre varios hilos para terminar antes. C# ofrece Parallel.For y
/// PLINQ (AsParallel). CancellationToken permite cancelar de forma cooperativa.
/// </summary>
public class E24_Paralelismo : IEjercicio
{
    public string Titulo => "Paralelismo (Parallel.For, PLINQ)";

    public void Ejecutar()
    {
        int[] numeros = Enumerable.Range(1, 20).ToArray();

        // Secuencial vs paralelo para una tarea "pesada" simulada.
        var reloj = Stopwatch.StartNew();
        long sumaSecuencial = numeros.Sum(TrabajoPesado);
        Console.WriteLine($"Secuencial: suma={sumaSecuencial} en {reloj.ElapsedMilliseconds} ms");

        // PLINQ: .AsParallel() reparte el cálculo entre núcleos.
        reloj.Restart();
        long sumaParalela = numeros.AsParallel().Sum(TrabajoPesado);
        Console.WriteLine($"PLINQ     : suma={sumaParalela} en {reloj.ElapsedMilliseconds} ms");

        // Parallel.ForEach: ejecuta un cuerpo por elemento en paralelo.
        Console.WriteLine("\nParallel.ForEach (el orden de salida NO es determinista):");
        Parallel.ForEach(new[] { "rojo", "verde", "azul", "amarillo" }, color =>
            Console.WriteLine($"  procesando {color} en hilo {Environment.CurrentManagedThreadId}"));

        // Cancelación cooperativa con CancellationToken.
        Console.WriteLine("\nCancelación cooperativa:");
        using var cts = new CancellationTokenSource();
        try
        {
            ContarHasta(1_000_000, cancelarEn: 5, cts);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  Operación cancelada correctamente.");
        }
    }

    // Simula cálculo costoso (no usar Thread.Sleep en trabajo real de CPU).
    private static long TrabajoPesado(int n)
    {
        long acc = 0;
        for (int i = 0; i < 200_000; i++) acc += (n + i) % 7;
        return acc;
    }

    private static void ContarHasta(int limite, int cancelarEn, CancellationTokenSource cts)
    {
        for (int i = 1; i <= limite; i++)
        {
            if (i == cancelarEn) cts.Cancel();
            cts.Token.ThrowIfCancellationRequested();
            Console.WriteLine($"  contando {i}");
        }
    }
}
