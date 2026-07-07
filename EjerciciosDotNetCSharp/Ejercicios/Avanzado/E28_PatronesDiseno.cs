namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 28 - Patrones de diseño.
/// Principio: soluciones probadas a problemas de diseño recurrentes. Aquí:
///  - Strategy: intercambiar un algoritmo en tiempo de ejecución.
///  - Factory: centralizar la creación de objetos.
///  - Observer: notificar cambios a múltiples interesados.
/// </summary>
public class E28_PatronesDiseno : IEjercicio
{
    public string Titulo => "Patrones de diseño (Strategy, Factory, Observer)";

    public void Ejecutar()
    {
        // STRATEGY: el mismo carrito calcula distinto según la estrategia.
        Console.WriteLine("== Strategy ==");
        var carrito = new Carrito(100_000m);
        Console.WriteLine($"Sin descuento : {carrito.Total(new SinDescuento()):C0}");
        Console.WriteLine($"Cliente VIP   : {carrito.Total(new DescuentoVip()):C0}");
        Console.WriteLine($"Temporada     : {carrito.Total(new DescuentoTemporada(0.15m)):C0}");

        // FACTORY: pedimos un producto por nombre, la fábrica decide la clase.
        Console.WriteLine("\n== Factory ==");
        foreach (var tipo in new[] { "circulo", "cuadrado" })
        {
            var forma = FabricaFormas.Crear(tipo);
            Console.WriteLine($"  '{tipo}' -> {forma.Dibujar()}");
        }

        // OBSERVER: varios observadores reaccionan a un cambio de estado.
        Console.WriteLine("\n== Observer ==");
        var estacion = new EstacionClima();
        estacion.Suscribir(t => Console.WriteLine($"  [Pantalla] {t}°"));
        estacion.Suscribir(t => Console.WriteLine($"  [Alarma] {(t > 35 ? "¡calor extremo!" : "ok")}"));
        estacion.NuevaLectura(38);
    }

    // ---- Strategy ----
    private interface IDescuento { decimal Aplicar(decimal monto); }
    private class SinDescuento : IDescuento { public decimal Aplicar(decimal m) => m; }
    private class DescuentoVip : IDescuento { public decimal Aplicar(decimal m) => m * 0.8m; }
    private class DescuentoTemporada(decimal pct) : IDescuento
    {
        public decimal Aplicar(decimal m) => m * (1 - pct);
    }
    private class Carrito(decimal subtotal)
    {
        public decimal Total(IDescuento descuento) => descuento.Aplicar(subtotal);
    }

    // ---- Factory ----
    private interface IForma { string Dibujar(); }
    private class Circulo2 : IForma { public string Dibujar() => "○ círculo"; }
    private class Cuadrado2 : IForma { public string Dibujar() => "□ cuadrado"; }
    private static class FabricaFormas
    {
        public static IForma Crear(string tipo) => tipo switch
        {
            "circulo" => new Circulo2(),
            "cuadrado" => new Cuadrado2(),
            _ => throw new ArgumentException($"Forma desconocida: {tipo}"),
        };
    }

    // ---- Observer ----
    private class EstacionClima
    {
        private readonly List<Action<int>> _observadores = new();
        public void Suscribir(Action<int> obs) => _observadores.Add(obs);
        public void NuevaLectura(int temp)
        {
            foreach (var obs in _observadores) obs(temp);
        }
    }
}
