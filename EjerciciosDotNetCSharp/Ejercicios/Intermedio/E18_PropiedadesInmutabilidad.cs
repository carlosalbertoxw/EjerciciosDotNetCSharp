namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 18 - Propiedades avanzadas e inmutabilidad.
/// Principio: los objetos inmutables no cambian tras crearse, lo que los hace
/// más seguros y predecibles. C# lo facilita con 'init', 'required',
/// 'readonly' y la expresión 'with' de los records. Cuando una propiedad sí
/// cambia, la palabra clave 'field' permite validarla sin declarar un campo aparte.
/// </summary>
public class E18_PropiedadesInmutabilidad : IEjercicio
{
    public string Titulo => "Propiedades avanzadas e inmutabilidad (init/with/field)";

    public void Ejecutar()
    {
        // 'required' obliga a asignar la propiedad al construir el objeto.
        // 'init' permite asignarla solo durante la inicialización, no después.
        var config = new Configuracion
        {
            Nombre = "Servidor A",
            Puerto = 8080,
        };
        Console.WriteLine($"Config: {config.Nombre}:{config.Puerto} (reintentos={config.Reintentos})");

        // config.Puerto = 9090;  // <-- error de compilación: init es de solo lectura

        // Records: inmutables por defecto. 'with' crea una COPIA con cambios.
        var usuario = new Usuario("ana", "Ana", Activo: true);
        var desactivado = usuario with { Activo = false };

        Console.WriteLine($"\nOriginal  : {usuario}");
        Console.WriteLine($"with{{...}}: {desactivado}");
        Console.WriteLine($"¿El original cambió? No: Activo={usuario.Activo}");

        // Igualdad por valor de los records.
        var copia = usuario with { };   // copia idéntica
        Console.WriteLine($"\nusuario == copia -> {usuario == copia} (igualdad por valor)");

        // 'field' (C# 14): valida al asignar sin declarar un campo privado.
        var inventario = new Inventario { Existencias = 5 };
        Console.WriteLine($"\nExistencias: {inventario.Existencias}");
        try
        {
            inventario.Existencias = -1;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Asignar -1 fue rechazado por el 'set' de la propiedad.");
        }
    }

    private class Configuracion
    {
        public required string Nombre { get; init; }
        public required int Puerto { get; init; }
        public int Reintentos { get; init; } = 3;   // valor por defecto
    }

    private record Usuario(string Id, string Nombre, bool Activo);

    private class Inventario
    {
        public int Existencias
        {
            get;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                field = value;
            }
        }
    }
}
