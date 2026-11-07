namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 12 - LINQ (Language Integrated Query).
/// Principio: consultar y transformar colecciones de forma declarativa (decir
/// QUE queremos, no COMO recorrerlas). Where filtra, Select proyecta, OrderBy
/// ordena, y hay agregados como Sum, Average, Count.
/// </summary>
public class E12_Linq : IEjercicio
{
    public string Titulo => "LINQ (consultas sobre colecciones)";

    public void Ejecutar()
    {
        var productos = new List<Producto>
        {
            new("Teclado", 25.0m, "Periféricos"),
            new("Mouse", 15.0m, "Periféricos"),
            new("Monitor", 180.0m, "Pantallas"),
            new("Laptop", 950.0m, "Cómputo"),
            new("Webcam", 40.0m, "Periféricos"),
        };

        // Where: filtra los que cumplen una condición.
        var baratos = productos.Where(p => p.Precio < 50);
        Console.WriteLine("Productos con precio < 50:");
        foreach (var p in baratos)
            Console.WriteLine($"  - {p.Nombre} ({p.Precio:C})");

        // OrderByDescending + Select: ordena y proyecta solo el nombre.
        var porPrecio = productos
            .OrderByDescending(p => p.Precio)
            .Select(p => p.Nombre);
        Console.WriteLine($"\nDe más caro a más barato: {string.Join(", ", porPrecio)}");

        // Agregados.
        Console.WriteLine($"\nCantidad de productos : {productos.Count}");
        Console.WriteLine($"Precio total          : {productos.Sum(p => p.Precio):C}");
        Console.WriteLine($"Precio promedio       : {productos.Average(p => p.Precio):C}");
        Console.WriteLine($"Producto más caro     : {productos.Max(p => p.Precio):C}");

        // GroupBy: agrupar por categoria y contar.
        Console.WriteLine("\nConteo por categoria:");
        var porCategoria = productos.GroupBy(p => p.Categoria);
        foreach (var grupo in porCategoria)
            Console.WriteLine($"  {grupo.Key}: {grupo.Count()} producto(s)");
    }
}

/// <summary>
/// 'record' es una forma concisa de declarar un tipo inmutable centrado en datos.
/// Genera automaticamente constructor, comparación por valor y ToString().
/// </summary>
file record Producto(string Nombre, decimal Precio, string Categoria);
