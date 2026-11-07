using EjerciciosDotNetCSharp.Ejercicios;

// ============================================================================
//  Ejercicios de C# / .NET  -  Menú con submenús por nivel
//  Cada ejercicio implementa IEjercicio. Se agrupan en categorías (Básico,
//  Intermedio, Avanzado); el menú principal elige categoría y el submenú corre
//  los ejercicios de esa categoría.
//
//  Sin menú:  dotnet run -- --todos   ejecuta todos e indica en el código de
//  salida si alguno falló (útil para comprobarlos de forma automática).
// ============================================================================

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Fijamos una cultura para que números, fechas y moneda se muestren siempre
// igual, sin depender de la configuración regional de cada equipo.
System.Globalization.CultureInfo.CurrentCulture =
    System.Globalization.CultureInfo.GetCultureInfo("es-CO");

// Catálogo de categorías, en orden de dificultad creciente.
List<Categoria> categorias =
[
    new("Básico",
    [
        new E01_VariablesYTipos(),
        new E02_Operadores(),
        new E03_Cadenas(),
        new E04_Condicionales(),
        new E05_Bucles(),
        new E06_Colecciones(),
        new E07_Metodos(),
        new E08_ClasesYObjetos(),
        new E09_HerenciaPolimorfismo(),
        new E10_Interfaces(),
        new E11_Excepciones(),
        new E12_Linq(),
    ]),
    new("Intermedio",
    [
        new E13_Genericos(),
        new E14_DelegadosEventos(),
        new E15_NullSafety(),
        new E16_StructsVsClasses(),
        new E17_EnumsPatternMatching(),
        new E18_PropiedadesInmutabilidad(),
        new E19_MetodosExtension(),
        new E20_Iteradores(),
        new E21_Disposable(),
        new E22_ArchivosYJson(),
    ]),
    new("Avanzado",
    [
        new E23_AsyncAwait(),
        new E24_Paralelismo(),
        new E25_Concurrencia(),
        new E26_InyeccionDependencias(),
        new E27_Solid(),
        new E28_PatronesDiseno(),
        new E29_ReflexionAtributos(),
        new E30_PruebasUnitarias(),
        new E31_SpanMemory(),
        new E32_ProgramacionFuncional(),
    ]),
];

if (args.Contains("--todos"))
{
    int fallidos = categorias.SelectMany(c => c.Ejercicios).Count(e => !EjecutarEjercicio(e));
    Console.WriteLine($"\nEjercicios con error: {fallidos}");
    return fallidos == 0 ? 0 : 1;
}

MenuPrincipal(categorias);
return 0;

// --- Menú principal: elegir categoría -------------------------------------
static void MenuPrincipal(List<Categoria> categorias)
{
    while (true)
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("   EJERCICIOS DE C# / .NET");
        Console.WriteLine("========================================");
        Console.WriteLine("   Elige un nivel:\n");

        for (int i = 0; i < categorias.Count; i++)
            Console.WriteLine($"   {i + 1}. {categorias[i].Nombre} ({categorias[i].Ejercicios.Count} ejercicios)");

        Console.WriteLine("   0. Salir");
        Console.Write("\nOpción: ");

        string? opcion = Console.ReadLine();
        if (opcion is null) return;   // EOF / consola no interactiva
        opcion = opcion.Trim().ToLowerInvariant();

        if (opcion is "0" or "q" or "salir")
        {
            Console.WriteLine("¡Hasta luego!");
            return;
        }

        if (int.TryParse(opcion, out int num) && num >= 1 && num <= categorias.Count)
        {
            if (!Submenu(categorias[num - 1]))
                return;   // el submenú devolvió "salir del programa"
        }
        else
        {
            Console.WriteLine(">> Opción no válida.");
        }
    }
}

// --- Submenú de una categoría. Devuelve false si se pide salir del programa.
static bool Submenu(Categoria categoria)
{
    while (true)
    {
        Console.WriteLine($"\n---------- Nivel {categoria.Nombre} ----------");
        for (int i = 0; i < categoria.Ejercicios.Count; i++)
            Console.WriteLine($"  {i + 1,2}. {categoria.Ejercicios[i].Titulo}");

        Console.WriteLine("   T. Ejecutar TODOS los de este nivel");
        Console.WriteLine("   V. Volver al menú principal");
        Console.WriteLine("   0. Salir del programa");
        Console.Write("\nOpción: ");

        string? opcion = Console.ReadLine();
        if (opcion is null) return false;
        opcion = opcion.Trim().ToLowerInvariant();

        switch (opcion)
        {
            case "0" or "q" or "salir":
                Console.WriteLine("¡Hasta luego!");
                return false;

            case "v" or "volver":
                return true;

            case "t" or "todos":
                foreach (var ej in categoria.Ejercicios)
                    EjecutarEjercicio(ej);
                break;

            default:
                if (int.TryParse(opcion, out int num) && num >= 1 && num <= categoria.Ejercicios.Count)
                    EjecutarEjercicio(categoria.Ejercicios[num - 1]);
                else
                    Console.WriteLine(">> Opción no válida.");
                break;
        }
    }
}

// Devuelve false si el ejercicio falló; un error no debe cerrar el menú.
static bool EjecutarEjercicio(IEjercicio ejercicio)
{
    Console.WriteLine($"\n>>> {ejercicio.Titulo}");
    Console.WriteLine(new string('-', 50));
    bool correcto = true;
    try
    {
        ejercicio.Ejecutar();
    }
    catch (Exception ex)
    {
        Console.WriteLine($">> El ejercicio falló: {ex.GetType().Name}: {ex.Message}");
        correcto = false;
    }
    Console.WriteLine(new string('-', 50));
    return correcto;
}

// Agrupa un nivel con sus ejercicios.
record Categoria(string Nombre, List<IEjercicio> Ejercicios);
