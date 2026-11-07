namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 06 - Arreglos y colecciones.
/// Principio: guardar varios valores juntos. Un arreglo tiene tamaño fijo;
/// List&lt;T&gt; crece dinámicamente; Dictionary&lt;K,V&gt; asocia clave -> valor.
/// </summary>
public class E06_Colecciones : IEjercicio
{
    public string Titulo => "Arreglos, List<T> y Dictionary<K,V>";

    public void Ejecutar()
    {
        // Arreglo: tamaño fijo, se accede por índice (empieza en 0).
        Console.WriteLine("== Arreglo (tamaño fijo) ==");
        int[] numeros = { 10, 20, 30, 40 };
        Console.WriteLine($"Primer elemento (índice 0): {numeros[0]}");
        Console.WriteLine($"Último elemento           : {numeros[^1]}");  // ^1 = último
        Console.WriteLine($"Cantidad                  : {numeros.Length}");

        // List<T>: colección que crece y se encoge.
        Console.WriteLine("\n== List<string> (dinámica) ==");
        var tareas = new List<string> { "Estudiar", "Programar" };
        tareas.Add("Descansar");             // agregar
        tareas.Remove("Estudiar");           // quitar
        Console.WriteLine($"Tareas ({tareas.Count}): {string.Join(", ", tareas)}");

        // Dictionary<K,V>: busca valores por una clave (muy rápido).
        Console.WriteLine("\n== Dictionary<string,int> (clave -> valor) ==");
        var edades = new Dictionary<string, int>
        {
            ["Ana"] = 28,
            ["Luis"] = 35,
        };
        edades["Marta"] = 41;                // agregar una entrada
        Console.WriteLine($"Edad de Luis: {edades["Luis"]}");

        foreach (var par in edades)
            Console.WriteLine($"  {par.Key} tiene {par.Value} años");

        // TryGetValue: forma segura de leer sin provocar excepción si no existe.
        if (edades.TryGetValue("Pedro", out int edadPedro))
            Console.WriteLine($"Pedro: {edadPedro}");
        else
            Console.WriteLine("\nPedro no está en el diccionario");
    }
}
