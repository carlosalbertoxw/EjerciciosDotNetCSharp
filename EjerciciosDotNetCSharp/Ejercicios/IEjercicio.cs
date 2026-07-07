namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Contrato comun para todos los ejercicios. Cada ejercicio expone un titulo
/// (lo que se muestra en el menu) y un metodo Ejecutar() que corre la demo.
/// </summary>
public interface IEjercicio
{
    /// <summary>Nombre del ejercicio, mostrado en el menu principal.</summary>
    string Titulo { get; }

    /// <summary>Corre el ejercicio e imprime su salida en la consola.</summary>
    void Ejecutar();
}
