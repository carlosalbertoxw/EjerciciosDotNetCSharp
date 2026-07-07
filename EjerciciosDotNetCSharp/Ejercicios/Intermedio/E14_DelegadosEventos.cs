namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 14 - Delegados, lambdas y eventos.
/// Principio: en C# los métodos se pueden guardar en variables y pasar como
/// argumentos. Un delegado es un "tipo función". Los eventos aplican este
/// mecanismo al patrón publicador/suscriptor.
/// </summary>
public class E14_DelegadosEventos : IEjercicio
{
    public string Titulo => "Delegados, lambdas y eventos";

    public void Ejecutar()
    {
        // Func<entradas..., salida>: representa un método que devuelve algo.
        Func<int, int, int> sumar = (a, b) => a + b;
        Console.WriteLine($"Func sumar(2,5)   = {sumar(2, 5)}");

        // Action: método que NO devuelve valor (void).
        Action<string> saludar = nombre => Console.WriteLine($"Action -> Hola {nombre}");
        saludar("Ana");

        // Predicate<T>: método que devuelve bool (una condición).
        Predicate<int> esPar = n => n % 2 == 0;
        Console.WriteLine($"Predicate esPar(4) = {esPar(4)}");

        // Pasar una función como argumento a otra función.
        Console.WriteLine($"\nAplicar(10, x => x*x) = {Aplicar(10, x => x * x)}");

        // Eventos: el termostato "avisa" y varios suscriptores reaccionan.
        Console.WriteLine("\n== Eventos (publicador/suscriptor) ==");
        var termostato = new Termostato();
        termostato.AlertaCalor += t => Console.WriteLine($"  [Ventilador] enciendo, hay {t}°");
        termostato.AlertaCalor += t => Console.WriteLine($"  [App] notificación: {t}°");
        termostato.Medir(30);
        termostato.Medir(18);   // no dispara el evento
    }

    private static int Aplicar(int valor, Func<int, int> operacion) => operacion(valor);

    /// <summary>Publicador: expone un evento al que otros se suscriben.</summary>
    private class Termostato
    {
        // 'event' + delegado. Los suscriptores se agregan con +=.
        public event Action<int>? AlertaCalor;

        public void Medir(int temperatura)
        {
            Console.WriteLine($"Temperatura medida: {temperatura}°");
            if (temperatura >= 28)
                AlertaCalor?.Invoke(temperatura);   // ?. por si no hay suscriptores
        }
    }
}
