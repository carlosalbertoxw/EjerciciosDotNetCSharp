namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 17 - Enums y pattern matching.
/// Principio: un 'enum' nombra un conjunto fijo de valores (más legible que
/// números sueltos). El pattern matching permite inspeccionar tipos, valores
/// y propiedades de forma expresiva con 'switch' e 'is'.
/// </summary>
public class E17_EnumsPatternMatching : IEjercicio
{
    public string Titulo => "Enums y pattern matching";

    public void Ejecutar()
    {
        // Enum simple.
        DiaSemana hoy = DiaSemana.Sabado;
        bool esFinde = hoy is DiaSemana.Sabado or DiaSemana.Domingo;
        Console.WriteLine($"Hoy es {hoy} (valor {(int)hoy}). ¿Fin de semana? {esFinde}");

        // Enum [Flags]: combina varios valores con OR (|).
        Permisos permisos = Permisos.Leer | Permisos.Escribir;
        Console.WriteLine($"\nPermisos: {permisos}");
        Console.WriteLine($"¿Puede escribir? {permisos.HasFlag(Permisos.Escribir)}");
        Console.WriteLine($"¿Puede borrar?   {permisos.HasFlag(Permisos.Borrar)}");

        // Pattern matching por TIPO con 'switch' de expresión.
        Console.WriteLine("\n== switch por tipo ==");
        object[] cosas = { 42, "hola", 3.14, true };
        foreach (var cosa in cosas)
            Console.WriteLine($"  {cosa,-6} -> {Describir(cosa)}");

        // Property pattern: examina propiedades del objeto.
        var envio = new Envio(Peso: 12, EsInternacional: true);
        Console.WriteLine($"\nCosto de envío: {CalcularCosto(envio):C0}");
    }

    private static string Describir(object o) => o switch
    {
        int n when n > 10 => "entero grande",
        int => "entero",
        string s => $"texto de {s.Length} letras",
        double => "decimal",
        bool b => b ? "verdadero" : "falso",
        _ => "desconocido",
    };

    private static decimal CalcularCosto(Envio e) => e switch
    {
        { EsInternacional: true, Peso: > 10 } => 50_000m,
        { EsInternacional: true } => 30_000m,
        { Peso: > 10 } => 15_000m,
        _ => 8_000m,
    };

    private enum DiaSemana { Lunes = 1, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo }

    [Flags]
    private enum Permisos { Ninguno = 0, Leer = 1, Escribir = 2, Borrar = 4 }

    private record Envio(double Peso, bool EsInternacional);
}
