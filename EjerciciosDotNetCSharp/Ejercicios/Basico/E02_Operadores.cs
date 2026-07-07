namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 02 - Operadores.
/// Principio: los operadores combinan valores para producir nuevos valores.
/// Existen aritmeticos, de comparacion, logicos y de asignacion.
/// </summary>
public class E02_Operadores : IEjercicio
{
    public string Titulo => "Operadores (aritmeticos, comparacion, logicos)";

    public void Ejecutar()
    {
        int a = 7, b = 3;

        Console.WriteLine("== Aritmeticos ==");
        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        Console.WriteLine($"{a} / {b} = {a / b}   (division ENTERA: descarta el resto)");
        Console.WriteLine($"{a} % {b} = {a % b}   (modulo: el resto de la division)");
        Console.WriteLine($"{a} / {b} como double = {(double)a / b}   (con conversion)");

        Console.WriteLine("\n== Comparacion (devuelven bool) ==");
        Console.WriteLine($"{a} > {b}  -> {a > b}");
        Console.WriteLine($"{a} == {b} -> {a == b}");
        Console.WriteLine($"{a} != {b} -> {a != b}");

        Console.WriteLine("\n== Logicos ==");
        bool tieneLicencia = true;
        bool esMayorDeEdad = true;
        Console.WriteLine($"AND (&&): puede conducir = {tieneLicencia && esMayorDeEdad}");
        Console.WriteLine($"OR  (||): dia de descanso = {false || true}");
        Console.WriteLine($"NOT (!) : lo contrario de true = {!true}");

        Console.WriteLine("\n== Asignacion compuesta e incremento ==");
        int contador = 10;
        contador += 5;   // equivale a: contador = contador + 5;
        Console.WriteLine($"contador += 5 -> {contador}");
        contador++;      // incrementa en 1
        Console.WriteLine($"contador++    -> {contador}");
    }
}
