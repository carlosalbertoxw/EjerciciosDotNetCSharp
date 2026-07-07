namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 04 - Estructuras condicionales.
/// Principio: el programa toma decisiones y ejecuta distintos caminos segun
/// se cumplan o no ciertas condiciones (if/else, switch, operador ternario).
/// </summary>
public class E04_Condicionales : IEjercicio
{
    public string Titulo => "Condicionales (if / switch / ternario)";

    public void Ejecutar()
    {
        // if / else if / else
        int nota = 82;
        Console.WriteLine($"Nota = {nota}");

        if (nota >= 90)
            Console.WriteLine("Calificacion: A (Excelente)");
        else if (nota >= 80)
            Console.WriteLine("Calificacion: B (Bien)");
        else if (nota >= 70)
            Console.WriteLine("Calificacion: C (Suficiente)");
        else
            Console.WriteLine("Calificacion: Reprobado");

        // Operador ternario: condicion ? valorSiTrue : valorSiFalse
        string resultado = nota >= 70 ? "APROBADO" : "REPROBADO";
        Console.WriteLine($"Ternario -> {resultado}");

        // switch clasico: compara una variable contra varios casos.
        int dia = 3;
        string nombreDia = dia switch
        {
            1 => "Lunes",
            2 => "Martes",
            3 => "Miercoles",
            4 => "Jueves",
            5 => "Viernes",
            6 or 7 => "Fin de semana",
            _ => "Dia invalido",   // _ es el caso por defecto
        };
        Console.WriteLine($"\nEl dia {dia} es: {nombreDia}");

        // switch con rangos (pattern matching).
        double temperatura = 28.5;
        string clima = temperatura switch
        {
            < 0 => "Congelante",
            >= 0 and < 15 => "Frio",
            >= 15 and < 25 => "Templado",
            _ => "Caluroso",
        };
        Console.WriteLine($"Con {temperatura} grados el clima es: {clima}");
    }
}
