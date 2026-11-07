namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 08 - Clases y objetos (POO).
/// Principio: una clase es un molde que describe datos (propiedades) y
/// comportamiento (métodos). Un objeto es una instancia concreta de la clase.
/// </summary>
public class E08_ClasesYObjetos : IEjercicio
{
    public string Titulo => "Clases y objetos (POO básica)";

    public void Ejecutar()
    {
        // Crear objetos (instancias) a partir de la clase CuentaBancaria.
        var cuenta = new CuentaBancaria("Ana Perez", 100m);
        Console.WriteLine($"Titular: {cuenta.Titular}, saldo inicial: {cuenta.Saldo:C}");

        cuenta.Depositar(50m);
        Console.WriteLine($"Tras depositar 50 -> saldo: {cuenta.Saldo:C}");

        bool ok = cuenta.Retirar(200m);   // intenta retirar más de lo disponible
        Console.WriteLine($"Retirar 200 exitoso? {ok} -> saldo: {cuenta.Saldo:C}");

        cuenta.Retirar(120m);
        Console.WriteLine($"Tras retirar 120 -> saldo: {cuenta.Saldo:C}");
    }
}

/// <summary>Clase de ejemplo: modela una cuenta bancaria simple.</summary>
file class CuentaBancaria
{
    // Propiedad de solo lectura desde fuera (set privado): encapsulamiento.
    public string Titular { get; }
    public decimal Saldo { get; private set; }

    // Constructor: se ejecuta al crear el objeto con 'new'.
    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    // Método que modifica el estado interno del objeto.
    public void Depositar(decimal monto)
    {
        if (monto > 0)
            Saldo += monto;
    }

    // Devuelve true si el retiro fue posible; protege el saldo de quedar negativo.
    public bool Retirar(decimal monto)
    {
        if (monto <= 0 || monto > Saldo)
            return false;

        Saldo -= monto;
        return true;
    }
}
