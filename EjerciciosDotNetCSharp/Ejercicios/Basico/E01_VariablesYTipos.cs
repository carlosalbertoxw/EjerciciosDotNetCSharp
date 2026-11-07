namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 01 - Variables y tipos de datos.
/// Principio: en C# cada variable tiene un TIPO fijo. El compilador conoce el
/// tipo en tiempo de compilación (tipado estático), lo que previene errores.
/// </summary>
public class E01_VariablesYTipos : IEjercicio
{
    public string Titulo => "Variables y tipos de datos";

    public void Ejecutar()
    {
        // Tipos por valor (value types): guardan el dato directamente.
        int edad = 30;                 // entero de 32 bits
        double precio = 19.99;         // punto flotante de doble precisión
        decimal salario = 2500.50m;    // decimal: ideal para dinero (sufijo m)
        bool esActivo = true;          // booleano: true / false
        char inicial = 'C';            // un solo carácter (comillas simples)

        // Tipos por referencia (reference types): apuntan a datos en memoria.
        string nombre = "Carlos";      // cadena de texto (comillas dobles)

        // 'var' infiere el tipo a partir del valor. Sigue siendo tipado estático:
        // aquí 'ciudad' ES un string, no puede cambiar de tipo después.
        var ciudad = "Bogotá";

        Console.WriteLine($"nombre  (string) : {nombre}");
        Console.WriteLine($"edad    (int)    : {edad}");
        Console.WriteLine($"precio  (double) : {precio}");
        Console.WriteLine($"salario (decimal): {salario:C}");   // :C = formato moneda
        Console.WriteLine($"esActivo(bool)   : {esActivo}");
        Console.WriteLine($"inicial (char)   : {inicial}");
        Console.WriteLine($"ciudad  (var)    : {ciudad}");

        // Constantes: su valor no puede cambiar tras la asignación.
        const double PI = 3.14159;
        Console.WriteLine($"\nConstante PI     : {PI}");

        // Cada tipo tiene rangos. Aquí vemos los límites de int:
        Console.WriteLine($"\nint.MinValue = {int.MinValue}");
        Console.WriteLine($"int.MaxValue = {int.MaxValue}");
    }
}
