using System.Reflection;
using EjerciciosDotNetCSharp.Ejercicios;

namespace EjerciciosDotNetCSharp.Tests;

/// <summary>
/// Prueba de humo: encuentra por reflexión todos los ejercicios y comprueba que
/// ninguno lanza una excepción, así un ejercicio nuevo queda cubierto sin registrarlo.
/// </summary>
public class TodosLosEjerciciosTests
{
    public static TheoryData<string> Ejercicios()
    {
        var nombres = typeof(IEjercicio).Assembly.GetTypes()
            .Where(t => t.IsClass && typeof(IEjercicio).IsAssignableFrom(t))
            .Select(t => t.FullName!);
        return new TheoryData<string>(nombres);
    }

    [Theory]
    [MemberData(nameof(Ejercicios))]
    public void Ejercicio_SeEjecutaSinErrores(string nombreDeTipo)
    {
        Assembly ensamblado = typeof(IEjercicio).Assembly;
        var ejercicio = (IEjercicio)ensamblado.CreateInstance(nombreDeTipo)!;

        ejercicio.Ejecutar();
    }

    [Fact]
    public void Coleccion_TieneLos32Ejercicios() => Assert.Equal(32, Ejercicios().Count);
}
