namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 06 - Arreglos y colecciones.
/// Principio: guardar varios valores juntos. Un arreglo tiene tamano fijo;
/// List&lt;T&gt; crece dinamicamente; Dictionary&lt;K,V&gt; asocia clave -> valor.
/// </summary>
public class E06_Colecciones : IEjercicio
{
    public string Titulo => "Arreglos, List<T> y Dictionary<K,V>";

    public void Ejecutar()
    {
        // Arreglo: tamano fijo, se accede por indice (empieza en 0).
        Console.WriteLine("== Arreglo (tamano fijo) ==");
        int[] numeros = { 10, 20, 30, 40 };
        Console.WriteLine($"Primer elemento (indice 0): {numeros[0]}");
        Console.WriteLine($"Ultimo elemento           : {numeros[^1]}");  // ^1 = ultimo
        Console.WriteLine($"Cantidad                  : {numeros.Length}");

        // List<T>: coleccion que crece y se encoge.
        Console.WriteLine("\n== List<string> (dinamica) ==");
        var tareas = new List<string> { "Estudiar", "Programar" };
        tareas.Add("Descansar");             // agregar
        tareas.Remove("Estudiar");           // quitar
        Console.WriteLine($"Tareas ({tareas.Count}): {string.Join(", ", tareas)}");

        // Dictionary<K,V>: busca valores por una clave (muy rapido).
        Console.WriteLine("\n== Dictionary<string,int> (clave -> valor) ==");
        var edades = new Dictionary<string, int>
        {
            ["Ana"] = 28,
            ["Luis"] = 35,
        };
        edades["Marta"] = 41;                // agregar una entrada
        Console.WriteLine($"Edad de Luis: {edades["Luis"]}");

        foreach (var par in edades)
            Console.WriteLine($"  {par.Key} tiene {par.Value} anios");

        // TryGetValue: forma segura de leer sin provocar excepcion si no existe.
        if (edades.TryGetValue("Pedro", out int edadPedro))
            Console.WriteLine($"Pedro: {edadPedro}");
        else
            Console.WriteLine("\nPedro no esta en el diccionario");
    }
}
