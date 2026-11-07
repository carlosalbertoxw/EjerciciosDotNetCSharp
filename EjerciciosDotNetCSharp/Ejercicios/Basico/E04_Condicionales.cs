namespace EjerciciosDotNetCSharp.Ejercicios;

/// <summary>
/// Ejercicio 04 - Estructuras condicionales.
/// Principio: el programa toma decisiones y ejecuta distintos caminos según
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
            Console.WriteLine("Calificación: A (Excelente)");
        else if (nota >= 80)
            Console.WriteLine("Calificación: B (Bien)");
        else if (nota >= 70)
            Console.WriteLine("Calificación: C (Suficiente)");
        else
            Console.WriteLine("Calificación: Reprobado");

        // Operador ternario: condición ? valorSiTrue : valorSiFalse
        string resultado = nota >= 70 ? "APROBADO" : "REPROBADO";
        Console.WriteLine($"Ternario -> {resultado}");

        // Sentencia switch clásica: ejecuta el bloque del caso que coincide.
        // Cada caso termina con break; varios 'case' seguidos comparten bloque.
        int dia = 3;
        Console.Write($"\nSentencia switch: el día {dia} es ");
        switch (dia)
        {
            case 1:
                Console.WriteLine("Lunes");
                break;
            case 2:
                Console.WriteLine("Martes");
                break;
            case 3:
                Console.WriteLine("Miércoles");
                break;
            case 4:
                Console.WriteLine("Jueves");
                break;
            case 5:
                Console.WriteLine("Viernes");
                break;
            case 6:
            case 7:
                Console.WriteLine("Fin de semana");
                break;
            default:
                Console.WriteLine("Día inválido");
                break;
        }

        // Expresión switch: forma compacta que DEVUELVE un valor.
        string nombreDia = dia switch
        {
            1 => "Lunes",
            2 => "Martes",
            3 => "Miércoles",
            4 => "Jueves",
            5 => "Viernes",
            6 or 7 => "Fin de semana",
            _ => "Día inválido",   // _ es el caso por defecto
        };
        Console.WriteLine($"Expresión switch: el día {dia} es {nombreDia}");

        // Expresión switch con rangos (pattern matching). Los casos se evalúan
        // en orden, así que cada uno ya sabe que no se cumplieron los anteriores.
        double temperatura = 28.5;
        string clima = temperatura switch
        {
            < 0 => "Congelante",
            < 15 => "Frío",
            < 25 => "Templado",
            _ => "Caluroso",
        };
        Console.WriteLine($"Con {temperatura} grados el clima es: {clima}");
    }
}
