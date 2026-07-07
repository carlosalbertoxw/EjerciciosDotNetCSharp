namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 18 - Propiedades avanzadas e inmutabilidad.
/// Principio: los objetos inmutables no cambian tras crearse, lo que los hace
/// más seguros y predecibles. C# lo facilita con 'init', 'required',
/// 'readonly' y la expresión 'with' de los records.
/// </summary>
public class E18_PropiedadesInmutabilidad : IEjercicio
{
    public string Titulo => "Propiedades avanzadas e inmutabilidad (init/with)";

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
    }

    private class Configuracion
    {
        public required string Nombre { get; init; }
        public required int Puerto { get; init; }
        public int Reintentos { get; init; } = 3;   // valor por defecto
    }

    private record Usuario(string Id, string Nombre, bool Activo);
}
