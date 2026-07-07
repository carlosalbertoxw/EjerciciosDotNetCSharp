namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 31 - Span&lt;T&gt; y rendimiento sin asignaciones.
/// Principio: Span&lt;T&gt; es una "ventana" sobre memoria existente (un arreglo,
/// la pila, una cadena) que permite leer y rebanar SIN crear copias nuevas.
/// Reduce la presión sobre el recolector de basura en código de alto rendimiento.
/// </summary>
public class E31_SpanMemory : IEjercicio
{
    public string Titulo => "Span<T> (rebanar sin copiar)";

    public void Ejecutar()
    {
        int[] numeros = { 10, 20, 30, 40, 50, 60 };

        // Un Span sobre el arreglo: no copia datos, apunta a los mismos.
        Span<int> ventana = numeros;

        // Slice: una sub-ventana. Tampoco copia.
        Span<int> medio = ventana.Slice(2, 3);   // {30, 40, 50}
        Console.WriteLine($"Slice(2,3) = [{string.Join(", ", medio.ToArray())}]");

        // Modificar el span MODIFICA el arreglo original (misma memoria).
        medio[0] = 999;
        Console.WriteLine($"Tras medio[0]=999, arreglo original: [{string.Join(", ", numeros)}]");

        // Rebanar cadenas sin asignar: ReadOnlySpan<char> sobre substrings.
        ReadOnlySpan<char> fecha = "2026-07-06";
        int anio = int.Parse(fecha.Slice(0, 4));
        int mes = int.Parse(fecha.Slice(5, 2));
        int dia = int.Parse(fecha.Slice(8, 2));
        Console.WriteLine($"\nParseo de '2026-07-06' sin substrings -> año={anio}, mes={mes}, día={dia}");

        // stackalloc: buffer en la PILA (se libera solo, sin tocar el heap).
        Span<int> buffer = stackalloc int[5];
        for (int i = 0; i < buffer.Length; i++)
            buffer[i] = i * i;
        Console.WriteLine($"\nBuffer en pila (stackalloc): [{string.Join(", ", buffer.ToArray())}]");

        Console.WriteLine("\nIdea clave: Span evita copias y asignaciones en el heap, " +
                          "clave para código de alto rendimiento.");
    }
}
