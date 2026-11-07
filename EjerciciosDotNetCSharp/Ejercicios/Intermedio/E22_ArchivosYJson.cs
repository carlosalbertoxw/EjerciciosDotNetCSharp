using System.Text.Json;

namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 22 - Archivos y JSON.
/// Principio: leer y escribir datos en disco con System.IO, y convertir objetos
/// a/desde JSON con System.Text.Json (serializar = objeto->texto, deserializar
/// = texto->objeto). Usamos un archivo temporal y lo borramos al final.
/// </summary>
public class E22_ArchivosYJson : IEjercicio
{
    public string Titulo => "Archivos y JSON (System.IO / System.Text.Json)";

    public void Ejecutar()
    {
        // Objeto que vamos a persistir.
        var jugador = new Jugador("Zelda", Nivel: 7, Puntos: 12500);

        // Serializar: objeto -> texto JSON (WriteIndented lo hace legible).
        string json = JsonSerializer.Serialize(jugador,
            new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("JSON generado:");
        Console.WriteLine(json);

        // Escribir a un archivo temporal con nombre único.
        string ruta = Path.GetTempFileName();
        try
        {
            File.WriteAllText(ruta, json);
            Console.WriteLine($"\nGuardado en: {ruta}");

            // Leer el archivo de vuelta.
            string leido = File.ReadAllText(ruta);

            // Deserializar: texto JSON -> objeto.
            Jugador? recuperado = JsonSerializer.Deserialize<Jugador>(leido);
            Console.WriteLine($"\nRecuperado del disco: {recuperado}");
            Console.WriteLine($"Nivel del jugador: {recuperado?.Nivel}");
        }
        finally
        {
            // Limpieza: finally borra el temporal aunque algo falle arriba.
            File.Delete(ruta);
        }
        Console.WriteLine($"\nArchivo temporal borrado. ¿Existe aún? {File.Exists(ruta)}");
    }

    private record Jugador(string Nombre, int Nivel, int Puntos);
}
