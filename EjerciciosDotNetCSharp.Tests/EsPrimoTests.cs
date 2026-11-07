using EjerciciosDotNetCSharp.Ejercicios;

namespace EjerciciosDotNetCSharp.Tests;

/// <summary>
/// Las pruebas del ejercicio 30, ahora con un framework real: xUnit las descubre,
/// las ejecuta e informa del resultado (dotnet test).
/// </summary>
public class EsPrimoTests
{
    [Fact]
    public void EsPrimo_De7_DevuelveTrue()
    {
        // Arrange
        const int numero = 7;

        // Act
        bool resultado = E30_PruebasUnitarias.EsPrimo(numero);

        // Assert
        Assert.True(resultado);
    }

    // [Theory] repite la misma prueba con varios datos de entrada.
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(97, true)]
    [InlineData(int.MaxValue, true)]   // 2 147 483 647 es primo: no debe desbordarse
    [InlineData(9, false)]
    [InlineData(1, false)]
    [InlineData(0, false)]
    [InlineData(-5, false)]
    public void EsPrimo_ClasificaCorrectamente(int numero, bool esperado)
        => Assert.Equal(esperado, E30_PruebasUnitarias.EsPrimo(numero));
}
