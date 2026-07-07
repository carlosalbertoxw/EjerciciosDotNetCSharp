namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 05 - Bucles (iteracion).
/// Principio: repetir un bloque de codigo varias veces. C# ofrece for, while,
/// do-while y foreach. Se controlan con break (salir) y continue (saltar).
/// </summary>
public class E05_Bucles : IEjercicio
{
    public string Titulo => "Bucles (for / while / do-while / foreach)";

    public void Ejecutar()
    {
        // for: cuando sabes cuantas veces vas a iterar.
        Console.WriteLine("== for: tabla del 5 ==");
        for (int i = 1; i <= 5; i++)
            Console.WriteLine($"5 x {i} = {5 * i}");

        // while: repite MIENTRAS la condicion sea verdadera.
        Console.WriteLine("\n== while: cuenta regresiva ==");
        int cuenta = 3;
        while (cuenta > 0)
        {
            Console.WriteLine($"{cuenta}...");
            cuenta--;
        }
        Console.WriteLine("Despegue!");

        // do-while: se ejecuta AL MENOS una vez (evalua al final).
        Console.WriteLine("\n== do-while ==");
        int n = 10;
        do
        {
            Console.WriteLine($"Se ejecuta aunque n ({n}) ya no cumpla la condicion");
        } while (n < 5);

        // foreach: recorre cada elemento de una coleccion sin usar indices.
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
            Console.WriteLine($"Numero par: {i}");
        }
    }
}
