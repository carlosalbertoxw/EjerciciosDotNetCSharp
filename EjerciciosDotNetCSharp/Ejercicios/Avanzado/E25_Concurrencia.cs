using System.Collections.Concurrent;

namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 25 - Concurrencia segura.
/// Principio: cuando varios hilos tocan el MISMO dato a la vez aparecen
/// "condiciones de carrera" y el resultado se corrompe. Se resuelven con 'lock',
/// operaciones atómicas (Interlocked) o colecciones concurrentes.
/// </summary>
public class E25_Concurrencia : IEjercicio
{
    public string Titulo => "Concurrencia segura (lock, Interlocked)";

    public void Ejecutar()
    {
        const int hilos = 8;
        const int incrementosPorHilo = 100_000;
        const int esperado = hilos * incrementosPorHilo;

        // 1) SIN protección: 'contador++' no es atómico -> se pierden sumas.
        int inseguro = 0;
        EjecutarEnParalelo(hilos, () =>
        {
            for (int i = 0; i < incrementosPorHilo; i++)
                inseguro++;             // condición de carrera
        });
        Console.WriteLine($"Sin protección : {inseguro,8} (esperado {esperado}) <- casi siempre mal");

        // 2) Con 'lock': solo un hilo entra a la sección crítica a la vez.
        int conLock = 0;
        Lock candado = new();   // System.Threading.Lock: el tipo pensado para esto
        EjecutarEnParalelo(hilos, () =>
        {
            for (int i = 0; i < incrementosPorHilo; i++)
                lock (candado) { conLock++; }
        });
        Console.WriteLine($"Con lock       : {conLock,8} (esperado {esperado}) <- correcto");

        // 3) Con Interlocked: incremento atómico, más rápido que lock aquí.
        int atomico = 0;
        EjecutarEnParalelo(hilos, () =>
        {
            for (int i = 0; i < incrementosPorHilo; i++)
                Interlocked.Increment(ref atomico);
        });
        Console.WriteLine($"Con Interlocked: {atomico,8} (esperado {esperado}) <- correcto");

        // 4) Colección concurrente: segura para múltiples hilos sin lock manual.
        var bolsa = new ConcurrentBag<int>();
        EjecutarEnParalelo(hilos, () => bolsa.Add(Environment.CurrentManagedThreadId));
        Console.WriteLine($"\nConcurrentBag recibió {bolsa.Count} elementos sin corromperse.");
    }

    private static void EjecutarEnParalelo(int cantidad, Action trabajo)
    {
        var tareas = new Task[cantidad];
        for (int i = 0; i < cantidad; i++)
            tareas[i] = Task.Run(trabajo);
        Task.WaitAll(tareas);
    }
}
