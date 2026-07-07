namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 19 - Métodos de extensión.
/// Principio: agregar métodos a tipos existentes (incluso los del framework)
/// sin heredar de ellos ni modificar su código. Se declaran en una clase
/// estática con el modificador 'this' en el primer parámetro. Así funciona LINQ.
/// </summary>
public class E19_MetodosExtension : IEjercicio
{
    public string Titulo => "Métodos de extensión";

    public void Ejecutar()
    {
        // Ahora 'string' e 'int' parecen tener métodos nuevos.
        string palabra = "reconocer";
        Console.WriteLine($"'{palabra}'.EsPalindromo() -> {palabra.EsPalindromo()}");
        Console.WriteLine($"'hola'.EsPalindromo()      -> {"hola".EsPalindromo()}");

        Console.WriteLine($"\n10.EsPar() -> {10.EsPar()}");
        Console.WriteLine($"7.EsPar()  -> {7.EsPar()}");

        // Se pueden encadenar como cualquier método normal.
        string frase = "  El Veloz Zorro Marrón  ";
        Console.WriteLine($"\nResumen: '{frase.Normalizar().Truncar(10)}'");
    }
}

/// <summary>
/// Las extensiones viven en una clase estática. El 'this' del primer parámetro
/// indica el tipo que se está extendiendo.
/// </summary>
internal static class ExtensionesEjemplo
{
    public static bool EsPalindromo(this string texto)
    {
        string limpio = texto.ToLowerInvariant();
        char[] invertido = limpio.ToCharArray();
        Array.Reverse(invertido);
        return limpio == new string(invertido);
    }

    public static bool EsPar(this int numero) => numero % 2 == 0;

    public static string Normalizar(this string texto) => texto.Trim().ToLowerInvariant();

    public static string Truncar(this string texto, int max)
        => texto.Length <= max ? texto : texto[..max] + "…";
}
