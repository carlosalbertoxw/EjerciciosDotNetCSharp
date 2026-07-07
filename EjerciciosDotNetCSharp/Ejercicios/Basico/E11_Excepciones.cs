namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 11 - Manejo de excepciones.
/// Principio: cuando algo falla en tiempo de ejecucion, C# lanza una excepcion.
/// Con try/catch la capturamos para que el programa no se caiga; finally se
/// ejecuta siempre. Tambien podemos lanzar (throw) nuestras propias excepciones.
/// </summary>
public class E11_Excepciones : IEjercicio
{
    public string Titulo => "Manejo de excepciones (try / catch / finally)";

    public void Ejecutar()
    {
        // 1) Capturar una division por cero.
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

        // 2) Convertir texto a numero de forma segura.
        string entrada = "abc";
        if (int.TryParse(entrada, out int numero))
            Console.WriteLine($"'{entrada}' convertido a {numero}");
        else
            Console.WriteLine($"'{entrada}' no es un numero valido (TryParse evita la excepcion)\n");

        // 3) Lanzar y capturar una excepcion propia (validacion de edad).
        try
        {
            ValidarEdad(-5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"  [capturada] {ex.Message}");
        }
    }

    private void ValidarEdad(int edad)
    {
        if (edad < 0)
            throw new ArgumentException("La edad no puede ser negativa");

        Console.WriteLine($"Edad valida: {edad}");
    }
}
