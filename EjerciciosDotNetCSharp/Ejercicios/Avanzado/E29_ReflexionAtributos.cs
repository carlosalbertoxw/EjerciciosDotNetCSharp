using System.Reflection;

namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 29 - Reflexión y atributos.
/// Principio: la reflexión permite inspeccionar tipos, propiedades y métodos en
/// tiempo de EJECUCIÓN. Los atributos son metadatos que se adjuntan al código y
/// se leen con reflexión. Es la base de serializadores, validadores y ORMs.
/// </summary>
public class E29_ReflexionAtributos : IEjercicio
{
    public string Titulo => "Reflexión y atributos";

    public void Ejecutar()
    {
        var producto = new ProductoDemo { Nombre = "Café", Precio = 18000, Interno = "xyz" };

        // Inspeccionar el tipo en tiempo de ejecución.
        Type tipo = producto.GetType();
        Console.WriteLine($"Tipo: {tipo.Name}, propiedades: {tipo.GetProperties().Length}");

        // Leer los valores de todas las propiedades sin conocerlas de antemano.
        Console.WriteLine("\nValores (vía reflexión):");
        foreach (PropertyInfo prop in tipo.GetProperties())
            Console.WriteLine($"  {prop.Name,-8} = {prop.GetValue(producto)}");

        // Leer un atributo personalizado para construir un "reporte".
        Console.WriteLine("\nReporte usando el atributo [Columna]:");
        foreach (PropertyInfo prop in tipo.GetProperties())
        {
            var col = prop.GetCustomAttribute<ColumnaAttribute>();
            if (col is not null)
                Console.WriteLine($"  {col.Titulo}: {prop.GetValue(producto)}");
        }
        Console.WriteLine("\n(La propiedad 'Interno' no tiene [Columna], así que se omite.)");
    }

    // Atributo personalizado: solo se puede poner en propiedades.
    [AttributeUsage(AttributeTargets.Property)]
    private sealed class ColumnaAttribute(string titulo) : Attribute
    {
        public string Titulo { get; } = titulo;
    }

    private class ProductoDemo
    {
        [Columna("Nombre del producto")]
        public string Nombre { get; set; } = "";

        [Columna("Precio (COP)")]
        public decimal Precio { get; set; }

        // Sin atributo: no aparece en el reporte.
        public string Interno { get; set; } = "";
    }
}
