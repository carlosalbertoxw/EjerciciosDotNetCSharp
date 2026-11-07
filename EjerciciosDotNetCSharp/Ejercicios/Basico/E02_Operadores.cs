namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 02 - Operadores.
/// Principio: los operadores combinan valores para producir nuevos valores.
/// Existen aritméticos, de comparación, lógicos y de asignación.
/// </summary>
public class E02_Operadores : IEjercicio
{
    public string Titulo => "Operadores (aritméticos, comparación, lógicos)";

    public void Ejecutar()
    {
        int a = 7, b = 3;

        Console.WriteLine("== Aritméticos ==");
        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        Console.WriteLine($"{a} / {b} = {a / b}   (división ENTERA: descarta el resto)");
        Console.WriteLine($"{a} % {b} = {a % b}   (módulo: el resto de la división)");
        Console.WriteLine($"{a} / {b} como double = {(double)a / b}   (con conversión)");

        Console.WriteLine("\n== Comparación (devuelven bool) ==");
        Console.WriteLine($"{a} > {b}  -> {a > b}");
        Console.WriteLine($"{a} == {b} -> {a == b}");
        Console.WriteLine($"{a} != {b} -> {a != b}");

        Console.WriteLine("\n== Lógicos ==");
        bool tieneLicencia = true;
        bool esMayorDeEdad = true;
        Console.WriteLine($"AND (&&): puede conducir = {tieneLicencia && esMayorDeEdad}");
        Console.WriteLine($"OR  (||): día de descanso = {false || true}");
        Console.WriteLine($"NOT (!) : lo contrario de true = {!true}");

        Console.WriteLine("\n== Asignación compuesta e incremento ==");
        int contador = 10;
        contador += 5;   // equivale a: contador = contador + 5;
        Console.WriteLine($"contador += 5 -> {contador}");
        contador++;      // incrementa en 1
        Console.WriteLine($"contador++    -> {contador}");
    }
}
