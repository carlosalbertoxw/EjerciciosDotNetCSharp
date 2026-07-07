namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 32 - Programación funcional en C#.
/// Principio: favorecer funciones PURAS (misma entrada -> misma salida, sin
/// efectos secundarios), la inmutabilidad y la COMPOSICIÓN de funciones. Un tipo
/// Resultado explícito evita null y excepciones para representar el fallo.
/// </summary>
public class E32_ProgramacionFuncional : IEjercicio
{
    public string Titulo => "Programación funcional (pureza, composición, Result)";

    public void Ejecutar()
    {
        // Funciones puras: no leen ni modifican estado externo.
        Func<int, int> duplicar = x => x * 2;
        Func<int, int> incrementar = x => x + 1;

        // Composición: combinar funciones pequeñas en una más grande.
        Func<int, int> duplicarLuegoIncrementar = Componer(incrementar, duplicar);
        Console.WriteLine($"(x*2)+1 con x=5 -> {duplicarLuegoIncrementar(5)}");

        // Pipeline funcional con LINQ: transformar datos sin mutar la lista.
        int[] numeros = { 1, 2, 3, 4, 5, 6 };
        var resultado = numeros
            .Where(n => n % 2 == 0)   // filtrar
            .Select(duplicar)         // transformar
            .Sum();                   // reducir
        Console.WriteLine($"Pares -> duplicar -> sumar = {resultado}");
        Console.WriteLine($"(La lista original NO cambió: [{string.Join(", ", numeros)}])");

        // Tipo Result: el fallo es un VALOR, no una excepción ni un null.
        Console.WriteLine("\n== Manejo de errores con Result ==");
        MostrarDivision(10, 2);
        MostrarDivision(10, 0);
    }

    // Compone f y g: primero g, luego f  ->  f(g(x)).
    private static Func<int, int> Componer(Func<int, int> f, Func<int, int> g)
        => x => f(g(x));

    private static void MostrarDivision(int a, int b)
    {
        Resultado<int> r = DividirSeguro(a, b);
        string texto = r.EsExito ? $"= {r.Valor}" : $"error: {r.Error}";
        Console.WriteLine($"  {a} / {b} -> {texto}");
    }

    // Devuelve éxito o fallo SIN lanzar excepciones.
    private static Resultado<int> DividirSeguro(int a, int b)
        => b == 0
            ? Resultado<int>.Fallo("división por cero")
            : Resultado<int>.Exito(a / b);

    /// <summary>Encapsula "éxito con valor" o "fallo con mensaje".</summary>
    private readonly struct Resultado<T>
    {
        public bool EsExito { get; }
        public T? Valor { get; }
        public string? Error { get; }

        private Resultado(bool ok, T? valor, string? error)
        {
            EsExito = ok; Valor = valor; Error = error;
        }

        public static Resultado<T> Exito(T valor) => new(true, valor, null);
        public static Resultado<T> Fallo(string error) => new(false, default, error);
    }
}
