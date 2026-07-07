namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 21 - IDisposable y using.
/// Principio: algunos recursos (archivos, conexiones, sockets) deben liberarse
/// explícitamente. Implementando IDisposable y usando 'using', C# garantiza que
/// se liberen al salir del bloque, incluso si ocurre una excepción.
/// </summary>
public class E21_Disposable : IEjercicio
{
    public string Titulo => "IDisposable y using (liberación de recursos)";

    public void Ejecutar()
    {
        // 'using' con bloque: Dispose() se llama al cerrar la llave, garantizado.
        Console.WriteLine("== using con bloque ==");
        using (var conexion = new ConexionSimulada("BD-Principal"))
        {
            conexion.Ejecutar("SELECT * FROM usuarios");
        } // <- aquí se llama Dispose() automáticamente
        Console.WriteLine("(fuera del using: el recurso ya se liberó)");

        // 'using' declaración (C# 8+): se libera al final del método/ámbito.
        Console.WriteLine("\n== using declaración ==");
        using var otra = new ConexionSimulada("BD-Reportes");
        otra.Ejecutar("SELECT COUNT(*) FROM ventas");

        // Aunque falle, Dispose se ejecuta igual (equivale a try/finally).
        Console.WriteLine("\n== se libera incluso ante excepción ==");
        try
        {
            using var frágil = new ConexionSimulada("BD-Temporal");
            throw new InvalidOperationException("fallo simulado");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  Excepción capturada: {ex.Message}");
        }
    }

    /// <summary>Recurso de ejemplo que debe cerrarse al terminar de usarlo.</summary>
    private sealed class ConexionSimulada : IDisposable
    {
        private readonly string _nombre;

        public ConexionSimulada(string nombre)
        {
            _nombre = nombre;
            Console.WriteLine($"  [ABRIR]  conexión a {_nombre}");
        }

        public void Ejecutar(string consulta)
            => Console.WriteLine($"  [QUERY]  {consulta}");

        // Se invoca automáticamente al salir del 'using'.
        public void Dispose()
            => Console.WriteLine($"  [CERRAR] conexión a {_nombre} liberada");
    }
}
