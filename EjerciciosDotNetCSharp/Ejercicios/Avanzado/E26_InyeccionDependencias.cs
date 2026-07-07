namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 26 - Inyección de dependencias (DI) e inversión de control.
/// Principio: una clase NO crea sus dependencias; las RECIBE (normalmente por el
/// constructor) a través de una abstracción (interfaz). Esto la desacopla y la
/// hace testeable. En producción se usa Microsoft.Extensions.DependencyInjection;
/// aquí mostramos el principio con un contenedor mínimo hecho a mano.
/// </summary>
public class E26_InyeccionDependencias : IEjercicio
{
    public string Titulo => "Inyección de dependencias (IoC)";

    public void Ejecutar()
    {
        // "Composition root": el único lugar que decide implementaciones concretas.
        // Cambiar el notificador NO requiere tocar ServicioPedidos.
        Console.WriteLine("== Configurado con notificador de EMAIL ==");
        var conEmail = new ServicioPedidos(new NotificadorEmail());
        conEmail.Confirmar("PED-001");

        Console.WriteLine("\n== La MISMA clase, con notificador de SMS ==");
        var conSms = new ServicioPedidos(new NotificadorSms());
        conSms.Confirmar("PED-002");

        // Contenedor mínimo: resuelve la dependencia por nosotros.
        Console.WriteLine("\n== Resuelto por un contenedor simple ==");
        var contenedor = new ContenedorSimple();
        contenedor.Registrar<INotificador, NotificadorEmail>();
        var servicio = new ServicioPedidos(contenedor.Resolver<INotificador>());
        servicio.Confirmar("PED-003");
    }

    // Abstracción: el servicio depende de esto, no de una clase concreta.
    private interface INotificador { void Enviar(string mensaje); }

    private class NotificadorEmail : INotificador
    {
        public void Enviar(string mensaje) => Console.WriteLine($"  [EMAIL] {mensaje}");
    }

    private class NotificadorSms : INotificador
    {
        public void Enviar(string mensaje) => Console.WriteLine($"  [SMS]   {mensaje}");
    }

    // Recibe su dependencia por constructor: no sabe ni le importa cuál es.
    private class ServicioPedidos
    {
        private readonly INotificador _notificador;
        public ServicioPedidos(INotificador notificador) => _notificador = notificador;

        public void Confirmar(string pedido)
        {
            Console.WriteLine($"Procesando {pedido}...");
            _notificador.Enviar($"Tu pedido {pedido} fue confirmado.");
        }
    }

    // Contenedor didáctico: asocia una interfaz con una implementación.
    private class ContenedorSimple
    {
        private readonly Dictionary<Type, Func<object>> _registros = new();

        public void Registrar<TServicio, TImpl>() where TImpl : TServicio, new()
            => _registros[typeof(TServicio)] = () => new TImpl();

        public T Resolver<T>() => (T)_registros[typeof(T)]();
    }
}
