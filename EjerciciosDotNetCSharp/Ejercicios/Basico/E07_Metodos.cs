namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 07 - Métodos (funciones).
/// Principio: encapsular lógica reutilizable. Un método recibe parámetros de
/// entrada y puede devolver un valor. Ayuda a no repetir código (DRY).
/// </summary>
public class E07_Metodos : IEjercicio
{
    public string Titulo => "Métodos (parámetros, retorno, sobrecarga)";

    public void Ejecutar()
    {
        // Llamada a un método que devuelve un valor.
        int suma = Sumar(4, 6);
        Console.WriteLine($"Sumar(4, 6) = {suma}");

        // Sobrecarga: mismo nombre, distintos parámetros. C# elige cual usar.
        Console.WriteLine($"Sumar(1, 2, 3) = {Sumar(1, 2, 3)}");

        // Parámetro opcional (tiene valor por defecto).
        Console.WriteLine($"Saludar()        -> {Saludar()}");
        Console.WriteLine($"Saludar(\"Carlos\") -> {Saludar("Carlos")}");

        // Parámetro por referencia con 'out': el método devuelve varios valores.
        DividirConResto(17, 5, out int cociente, out int resto);
        Console.WriteLine($"17 / 5 -> cociente {cociente}, resto {resto}");

        // Método con cuerpo de expresion (forma abreviada, => ).
        Console.WriteLine($"AlCuadrado(9) = {AlCuadrado(9)}");
    }

    // Método: recibe dos int, devuelve un int.
    private int Sumar(int a, int b) => a + b;

    // Sobrecarga del método anterior con tres parámetros.
    private int Sumar(int a, int b, int c) => a + b + c;

    // Parámetro con valor por defecto.
    private string Saludar(string nombre = "invitado") => $"Hola, {nombre}!";

    // 'out' permite devolver más de un resultado.
    private void DividirConResto(int dividendo, int divisor, out int cociente, out int resto)
    {
        cociente = dividendo / divisor;
        resto = dividendo % divisor;
    }

    private int AlCuadrado(int x) => x * x;
}
