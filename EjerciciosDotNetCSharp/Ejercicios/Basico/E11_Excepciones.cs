namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 11 - Manejo de excepciones.
/// Principio: cuando algo falla en tiempo de ejecución, C# lanza una excepción.
/// Con try/catch la capturamos para que el programa no se caiga; finally se
/// ejecuta siempre. También podemos lanzar (throw) excepciones, incluso de un
/// tipo creado por nosotros.
/// </summary>
public class E11_Excepciones : IEjercicio
{
    public string Titulo => "Manejo de excepciones (try / catch / finally)";

    public void Ejecutar()
    {
        // 1) Capturar una división por cero.
        try
        {
            int a = 10, b = 0;
            Console.WriteLine($"Intentando {a} / {b}...");
            int r = a / b;                     // esto lanza DivideByZeroException
            Console.WriteLine($"Resultado: {r}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"  [capturada] No se puede dividir por cero: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  finally: este bloque SIEMPRE se ejecuta.\n");
        }

        // 2) Convertir texto a número de forma segura.
        string entrada = "abc";
        if (int.TryParse(entrada, out int numero))
            Console.WriteLine($"'{entrada}' convertido a {numero}");
        else
            Console.WriteLine($"'{entrada}' no es un número válido (TryParse evita la excepción)\n");

        // 3) Lanzar y capturar una excepción propia (validación de edad).
        try
        {
            ValidarEdad(-5);
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine($"  [capturada] {ex.Message} (edad recibida: {ex.Edad})");
        }

        // 4) Para argumentos inválidos comunes, .NET ya trae métodos de ayuda.
        try
        {
            ArgumentOutOfRangeException.ThrowIfNegative(-1, "cantidad");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  [capturada] {ex.GetType().Name} en el parámetro '{ex.ParamName}'");
        }
    }

    private static void ValidarEdad(int edad)
    {
        if (edad < 0)
            throw new EdadInvalidaException(edad);

        Console.WriteLine($"Edad válida: {edad}");
    }
}

/// <summary>
/// Excepción propia: hereda de Exception y agrega los datos del error, así quien
/// la captura puede distinguirla de las demás y consultar el valor recibido.
/// </summary>
file class EdadInvalidaException(int edad)
    : Exception("La edad no puede ser negativa")
{
    public int Edad { get; } = edad;
}
