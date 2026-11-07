# EjerciciosDotNetCSharp

Colección de ejercicios básicos para aprender los principios fundamentales del
lenguaje **C#** sobre **.NET 10**. Cada ejercicio es una clase autocontenida y
comentada que demuestra un concepto, y se ejecuta desde un menú interactivo en
consola.

## Requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) o superior
- Opcional: Visual Studio 2026 / VS Code con el kit de C#

Verifica tu instalación con:

```bash
dotnet --version
```

## Cómo ejecutar

Desde la raíz del repositorio:

```bash
dotnet run --project EjerciciosDotNetCSharp/EjerciciosDotNetCSharp.csproj
```

Para ejecutarlos todos sin pasar por el menú (termina con error si alguno falla):

```bash
dotnet run --project EjerciciosDotNetCSharp/EjerciciosDotNetCSharp.csproj -- --todos
```

Para correr las pruebas automatizadas (xUnit):

```bash
dotnet test
```

El menú principal te deja elegir un **nivel** (Básico / Intermedio / Avanzado).
Dentro de cada nivel: escribe el número de un ejercicio, `T` para ejecutar
**todos** los de ese nivel, `V` para volver al menú principal, o `0` para salir.

## Contenido de la colección

Los ejercicios están organizados en tres niveles de dificultad creciente.

### Nivel Básico

| #  | Ejercicio                     | Principio que enseña |
|----|-------------------------------|----------------------|
| 01 | Variables y tipos de datos    | Tipado estático, tipos por valor y por referencia, `var`, `const` |
| 02 | Operadores                    | Aritméticos, comparación, lógicos, asignación compuesta |
| 03 | Cadenas de texto              | Métodos de `string`, inmutabilidad, interpolación, `Split`/`Join`, cadenas crudas |
| 04 | Condicionales                 | `if/else`, operador ternario, sentencia y expresión `switch`, pattern matching |
| 05 | Bucles                        | `for`, `while`, `do-while`, `foreach`, `break`/`continue` |
| 06 | Arreglos y colecciones        | Arreglos, `List<T>`, `Dictionary<K,V>` |
| 07 | Métodos                       | Parámetros, retorno, sobrecarga, opcionales, `out` |
| 08 | Clases y objetos              | Encapsulamiento, propiedades, constructores (POO) |
| 09 | Herencia y polimorfismo       | Clases base/derivadas, `virtual`/`override` |
| 10 | Interfaces                    | Contratos y bajo acoplamiento |
| 11 | Manejo de excepciones         | `try/catch/finally`, `TryParse`, `throw`, excepciones propias |
| 12 | LINQ                          | `Where`, `Select`, `OrderBy`, agregados, `GroupBy`, `record` |

### Nivel Intermedio

| #  | Ejercicio                          | Principio que enseña |
|----|------------------------------------|----------------------|
| 13 | Genéricos                          | Clases y métodos `<T>`, restricciones `where` |
| 14 | Delegados, lambdas y eventos       | `Func`/`Action`/`Predicate`, `event`, publicador/suscriptor |
| 15 | Nullables y null-safety            | `?`, `??`, `??=`, `?.`, patrón `is null` |
| 16 | Structs vs clases                  | Semántica por valor vs. referencia, `record struct` |
| 17 | Enums y pattern matching           | `enum`, `[Flags]`, `switch` con patrones y propiedades |
| 18 | Propiedades e inmutabilidad        | `init`, `required`, expresión `with`, palabra clave `field` |
| 19 | Métodos de extensión               | Extender tipos sin heredar, bloques `extension` de C# 14 |
| 20 | Iteradores (`yield`)               | Evaluación perezosa, secuencias infinitas |
| 21 | `IDisposable` y `using`            | Liberación determinista de recursos |
| 22 | Archivos y JSON                    | `System.IO`, `System.Text.Json` |

### Nivel Avanzado

| #  | Ejercicio                          | Principio que enseña |
|----|------------------------------------|----------------------|
| 23 | `async` / `await`                  | Asincronía, `Task`, `Task.WhenAll`, `await foreach` |
| 24 | Paralelismo                        | `Parallel.ForEach`, PLINQ, cuándo compensa, `CancellationToken` |
| 25 | Concurrencia segura                | Condiciones de carrera, `lock` con `Lock`, `Interlocked` |
| 26 | Inyección de dependencias          | Inversión de control, desacoplamiento |
| 27 | Principios SOLID                   | Las 5 reglas de diseño (demo de Abierto/Cerrado) |
| 28 | Patrones de diseño                 | Strategy, Factory, Observer |
| 29 | Reflexión y atributos              | Inspección en runtime, atributos personalizados |
| 30 | Pruebas unitarias                  | Patrón AAA, aserciones (versión real con xUnit en `EjerciciosDotNetCSharp.Tests/`) |
| 31 | `Span<T>`                          | Rebanar memoria sin copiar, `stackalloc` |
| 32 | Programación funcional             | Funciones puras, composición, tipo `Result` |

> Los ejercicios 26 (DI) y 28 (patrones) enseñan el **principio** sin dependencias
> externas; en producción se usaría `Microsoft.Extensions.DependencyInjection`.
> El ejercicio 30 muestra la idea de una prueba y el proyecto de pruebas la aplica con xUnit.

## Estructura del proyecto

```
EjerciciosDotNetCSharp/
├── EjerciciosDotNetCSharp.slnx
├── global.json                          # Versión del SDK y ejecutor de pruebas
├── README.md
├── EjerciciosDotNetCSharp/
│   ├── EjerciciosDotNetCSharp.csproj    # Proyecto SDK-style, net10.0
│   ├── Program.cs                       # Menú con submenús por nivel
│   └── Ejercicios/
│       ├── IEjercicio.cs                # Contrato común (Titulo + Ejecutar)
│       ├── Basico/                      # E01 a E12
│       ├── Intermedio/                  # E13 a E22
│       └── Avanzado/                    # E23 a E32
└── EjerciciosDotNetCSharp.Tests/        # Pruebas con xUnit
```

## Cómo agregar un ejercicio nuevo

1. Crea una clase en la carpeta del nivel correspondiente que implemente `IEjercicio`:

   ```csharp
   public class E33_MiTema : IEjercicio
   {
       public string Titulo => "Mi tema nuevo";
       public void Ejecutar()
       {
           // ... tu demostración aquí ...
       }
   }
   ```

2. Regístrala en la lista del nivel correspondiente dentro de `Program.cs`.

¡Listo! Aparecerá automáticamente en el submenú de ese nivel, y la prueba de humo de
`TodosLosEjerciciosTests` lo ejecutará (actualiza ahí el total esperado de ejercicios).

## Licencia

[MIT](LICENSE)
