namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 15 - Nullables y seguridad ante null.
/// Principio: 'null' representa "sin valor" y es la causa clásica de errores.
/// C# ofrece tipos anulables (string?) y operadores (?., ??, ??=, !) para
/// manejar la ausencia de valor de forma explícita y segura.
/// </summary>
public class E15_NullSafety : IEjercicio
{
    public string Titulo => "Nullables y null-safety (?. ?? ??=)";

    public void Ejecutar()
    {
        // Tipo anulable: puede contener un valor o null.
        string? apodo = null;

        // ?? (null-coalescing): usa el segundo valor si el primero es null.
        string mostrado = apodo ?? "(sin apodo)";
        Console.WriteLine($"apodo ?? valor -> {mostrado}");

        // ??= (asignación coalescente): asigna solo si la variable es null.
        apodo ??= "Anónimo";
        Console.WriteLine($"tras ??=       -> {apodo}");

        // ?. (acceso condicional): si es null NO explota, devuelve null.
        string? texto = null;
        int? longitud = texto?.Length;   // no lanza NullReferenceException
        Console.WriteLine($"texto?.Length  -> {(longitud is null ? "null" : longitud.ToString())}");

        // Anulables de tipos por valor: int? puede ser null.
        int? cantidad = null;
        Console.WriteLine($"cantidad.HasValue -> {cantidad.HasValue}");
        Console.WriteLine($"cantidad ?? 0     -> {cantidad ?? 0}");

        // Patrón 'is null' / 'is not null' (forma recomendada de comparar).
        string? entrada = ObtenerNombre(mostrarNulo: true);
        if (entrada is null)
            Console.WriteLine("\nEl nombre vino nulo, uso un valor por defecto.");
        else
            Console.WriteLine($"\nNombre recibido: {entrada}");

        // Encadenar acceso seguro en objetos anidados.
        Persona? p = new Persona("Luis", null);
        Console.WriteLine($"Ciudad (puede faltar): {p?.Direccion?.Ciudad ?? "desconocida"}");
    }

    private static string? ObtenerNombre(bool mostrarNulo) => mostrarNulo ? null : "Carlos";

    private record Persona(string Nombre, Direccion? Direccion);
    private record Direccion(string Ciudad);
}
