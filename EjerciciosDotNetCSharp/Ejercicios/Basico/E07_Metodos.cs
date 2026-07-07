namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 07 - Metodos (funciones).
/// Principio: encapsular logica reutilizable. Un metodo recibe parametros de
/// entrada y puede devolver un valor. Ayuda a no repetir codigo (DRY).
/// </summary>
public class E07_Metodos : IEjercicio
{
    public string Titulo => "Metodos (parametros, retorno, sobrecarga)";

    public void Ejecutar()
    {
        // Llamada a un metodo que devuelve un valor.
        int suma = Sumar(4, 6);
        Console.WriteLine($"Sumar(4, 6) = {suma}");

        // Sobrecarga: mismo nombre, distintos parametros. C# elige cual usar.
        Console.WriteLine($"Sumar(1, 2, 3) = {Sumar(1, 2, 3)}");

        // Parametro opcional (tiene valor por defecto).
        Console.WriteLine($"Saludar()        -> {Saludar()}");
        Console.WriteLine($"Saludar(\"Carlos\") -> {Saludar("Carlos")}");

        // Parametro por referencia con 'out': el metodo devuelve varios valores.
        DividirConResto(17, 5, out int cociente, out int resto);
        Console.WriteLine($"17 / 5 -> cociente {cociente}, resto {resto}");

        // Metodo con cuerpo de expresion (forma abreviada, => ).
        Console.WriteLine($"AlCuadrado(9) = {AlCuadrado(9)}");
    }

    // Metodo: recibe dos int, devuelve un int.
    private int Sumar(int a, int b) => a + b;

    // Sobrecarga del metodo anterior con tres parametros.
    private int Sumar(int a, int b, int c) => a + b + c;

    // Parametro con valor por defecto.
    private string Saludar(string nombre = "invitado") => $"Hola, {nombre}!";

    // 'out' permite devolver mas de un resultado.
    private void DividirConResto(int dividendo, int divisor, out int cociente, out int resto)
    {
        cociente = dividendo / divisor;
        resto = dividendo % divisor;
    }

    private int AlCuadrado(int x) => x * x;
}
