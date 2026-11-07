using System.Diagnostics;

namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 23 - Programación asíncrona (async / await).
/// Principio: 'await' libera el hilo mientras una operación lenta (red, disco)
/// termina, en vez de bloquearlo. Varias tareas pueden ejecutarse en paralelo
/// con Task.WhenAll, y IAsyncEnumerable entrega resultados a medida que llegan.
/// Aquí simulamos latencia con Task.Delay.
/// </summary>
public class E23_AsyncAwait : IEjercicio
{
    public string Titulo => "async / await y Task";

    // El menú llama a un método síncrono (void). Puenteamos al mundo async
    // con GetAwaiter().GetResult(). En una app real, Main sería 'async Task'.
    public void Ejecutar() => EjecutarAsync().GetAwaiter().GetResult();

    private static async Task EjecutarAsync()
    {
        var reloj = Stopwatch.StartNew();

        // SECUENCIAL: espera una, luego la otra (~300 ms en total).
        Console.WriteLine("Secuencial (una tras otra):");
        string a = await DescargarAsync("A", 150);
        string b = await DescargarAsync("B", 150);
        Console.WriteLine($"  -> {a}, {b} en {reloj.ElapsedMilliseconds} ms");

        // EN PARALELO: se lanzan juntas y se espera a ambas (~150 ms).
        reloj.Restart();
        Console.WriteLine("\nEn paralelo (Task.WhenAll):");
        Task<string> t1 = DescargarAsync("C", 150);
        Task<string> t2 = DescargarAsync("D", 150);
        string[] resultados = await Task.WhenAll(t1, t2);
        Console.WriteLine($"  -> {string.Join(", ", resultados)} en {reloj.ElapsedMilliseconds} ms");
        Console.WriteLine("\n(El paralelo tarda ~la mitad: no espera en fila.)");

        // FLUJO ASÍNCRONO: cada elemento se procesa en cuanto está disponible.
        Console.WriteLine("\nFlujo asíncrono (await foreach):");
        await foreach (string pagina in LeerPaginasAsync(3))
            Console.WriteLine($"  -> {pagina}");
    }

    // Simula una operación de E/S que tarda 'ms' milisegundos.
    private static async Task<string> DescargarAsync(string id, int ms)
    {
        await Task.Delay(ms);           // no bloquea el hilo mientras "descarga"
        return $"datos-{id}";
    }

    // async + yield return: una secuencia cuyos elementos llegan con el tiempo.
    private static async IAsyncEnumerable<string> LeerPaginasAsync(int cantidad)
    {
        for (int i = 1; i <= cantidad; i++)
        {
            await Task.Delay(50);
            yield return $"página {i}";
        }
    }
}
