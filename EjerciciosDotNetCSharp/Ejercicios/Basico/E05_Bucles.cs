namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 05 - Bucles (iteración).
/// Principio: repetir un bloque de código varias veces. C# ofrece for, while,
/// do-while y foreach. Se controlan con break (salir) y continue (saltar).
/// </summary>
public class E05_Bucles : IEjercicio
{
    public string Titulo => "Bucles (for / while / do-while / foreach)";

    public void Ejecutar()
    {
        // for: cuando sabes cuántas veces vas a iterar.
        Console.WriteLine("== for: tabla del 5 ==");
        for (int i = 1; i <= 5; i++)
            Console.WriteLine($"5 x {i} = {5 * i}");

        // while: repite MIENTRAS la condición sea verdadera.
        Console.WriteLine("\n== while: cuenta regresiva ==");
        int cuenta = 3;
        while (cuenta > 0)
        {
            Console.WriteLine($"{cuenta}...");
            cuenta--;
        }
        Console.WriteLine("Despegue!");

        // do-while: se ejecuta AL MENOS una vez (evalúa al final).
        Console.WriteLine("\n== do-while ==");
        int n = 10;
        do
        {
            Console.WriteLine($"Se ejecuta aunque n ({n}) ya no cumpla la condición");
        } while (n < 5);

        // foreach: recorre cada elemento de una colección sin usar índices.
        Console.WriteLine("\n== foreach ==");
        string[] colores = { "rojo", "verde", "azul" };
        foreach (string color in colores)
            Console.WriteLine($"Color: {color}");

        // break y continue.
        Console.WriteLine("\n== break y continue (pares hasta encontrar el 8) ==");
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 != 0) continue;   // salta los impares
            if (i == 8) break;          // detiene el bucle en el 8
            Console.WriteLine($"Número par: {i}");
        }
    }
}
