namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 03 - Cadenas de texto (string).
/// Principio: las cadenas son inmutables (cada "modificación" crea una nueva
/// cadena). C# ofrece muchos métodos y la interpolación con $"...".
/// </summary>
public class E03_Cadenas : IEjercicio
{
    public string Titulo => "Cadenas de texto (string)";

    public void Ejecutar()
    {
        string frase = "Hola Mundo desde C#";

        Console.WriteLine($"Original      : {frase}");
        Console.WriteLine($"Longitud      : {frase.Length}");
        Console.WriteLine($"Mayúsculas    : {frase.ToUpper()}");
        Console.WriteLine($"Minúsculas    : {frase.ToLower()}");
        Console.WriteLine($"Contiene 'C#' : {frase.Contains("C#")}");
        Console.WriteLine($"Reemplazo     : {frase.Replace("Mundo", "Planeta")}");
        Console.WriteLine($"Subcadena(0,4): {frase.Substring(0, 4)}");
        Console.WriteLine($"Empieza 'Hola': {frase.StartsWith("Hola")}");

        // Dividir una cadena en partes (split) por un separador.
        string csv = "manzana,pera,uva,mango";
        string[] frutas = csv.Split(',');
        Console.WriteLine($"\nSplit por ',' -> {frutas.Length} elementos:");
        foreach (string fruta in frutas)
            Console.WriteLine($"  - {fruta}");

        // Unir un arreglo en una sola cadena (join).
        string unidas = string.Join(" | ", frutas);
        Console.WriteLine($"\nJoin con ' | ' -> {unidas}");

        // Interpolación vs concatenación.
        string usuario = "Ana";
        int puntos = 95;
        Console.WriteLine($"\nInterpolacion : {usuario} tiene {puntos} puntos");
        Console.WriteLine("Concatenación : " + usuario + " tiene " + puntos + " puntos");

        // Cadena literal cruda ("""): respeta saltos de línea y comillas sin escaparlas.
        string poema = """
            Caminante, no hay "camino",
            se hace camino al andar.
            """;
        Console.WriteLine($"\nCadena cruda:\n{poema}");

        // La inmutabilidad: Trim() NO cambia la original, devuelve una nueva.
        string conEspacios = "   texto   ";
        Console.WriteLine($"\nTrim() -> '{conEspacios.Trim()}' (la original sigue con espacios)");
    }
}
