namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Contrato común para todos los ejercicios. Cada ejercicio expone un título
/// (lo que se muestra en el menú) y un método Ejecutar() que corre la demo.
/// </summary>
public interface IEjercicio
{
    /// <summary>Nombre del ejercicio, mostrado en el menú principal.</summary>
    string Titulo { get; }

    /// <summary>Corre el ejercicio e imprime su salida en la consola.</summary>
    void Ejecutar();
}
