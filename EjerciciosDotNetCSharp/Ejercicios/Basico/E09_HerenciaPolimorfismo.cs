namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 09 - Herencia y polimorfismo.
/// Principio: una clase hija HEREDA de una clase base y puede REDEFINIR su
/// comportamiento (override). El polimorfismo permite tratar objetos distintos
/// a traves de un mismo tipo base y que cada uno responda a su manera.
/// </summary>
public class E09_HerenciaPolimorfismo : IEjercicio
{
    public string Titulo => "Herencia y polimorfismo";

    public void Ejecutar()
    {
        // Guardamos objetos de tipos distintos en una lista del tipo base.
        var animales = new List<Animal>
        {
            new Perro("Firulais"),
            new Gato("Michi"),
            new Animal("Criatura"),
        };

        // Polimorfismo: aunque el tipo de la variable es Animal, cada objeto
        // ejecuta SU propia version de HacerSonido().
        foreach (Animal animal in animales)
            Console.WriteLine($"{animal.Nombre,-10} dice: {animal.HacerSonido()}");
    }
}

/// <summary>Clase base. 'virtual' permite que las hijas la sobreescriban.</summary>
public class Animal
{
    public string Nombre { get; }

    public Animal(string nombre) => Nombre = nombre;

    public virtual string HacerSonido() => "...(sonido generico)";
}

/// <summary>Perro hereda de Animal y redefine el sonido con 'override'.</summary>
public class Perro : Animal
{
    // ': base(nombre)' pasa el nombre al constructor de la clase base.
    public Perro(string nombre) : base(nombre) { }

    public override string HacerSonido() => "Guau!";
}

/// <summary>Gato tambien hereda y aporta su propia version.</summary>
public class Gato : Animal
{
    public Gato(string nombre) : base(nombre) { }

    public override string HacerSonido() => "Miau!";
}
