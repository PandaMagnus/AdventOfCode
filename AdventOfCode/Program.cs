// See https://aka.ms/new-console-template for more information
using AdventOfCode;
using System.Reflection;

if (!args.Any())
{
    Console.WriteLine("Please enter a year and day separated by a dash (E.G. 2020-1) for the Advent of Code puzzle.");
    Console.WriteLine("Note: this can be entered as a command line argument.");
    string? input = Console.ReadLine();
    while(string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Please enter a year and day.");
        input = Console.ReadLine();
    }
    args = new[] { input };
}

IPuzzle puzzle = FindPuzzle(args);

string result = puzzle.Play();
Console.WriteLine(result);
return 0;


IPuzzle FindPuzzle(string[] mainArgs)
{
    // What if we don't use a dash?
    // Check for that.
    string[] puzzleArgs = args[0].Split('-');

    if (puzzleArgs[1].Length == 1)
    {
        puzzleArgs[1] = $"0{puzzleArgs[1]}";
    }
    string puzzleName = $"Puzzle{puzzleArgs[0]}{puzzleArgs[1]}";
    Assembly myAssembly = Assembly.GetExecutingAssembly();

    IPuzzle? foundPuzzle = null;
    foreach (Type type in myAssembly.GetTypes())
    {
        if (type.Name == puzzleName /*&& type.FindInterfaces(new TypeFilter())*/)
        {
            Type? foundInterface = type.GetInterface("IPuzzle");
            if (foundInterface is not null)
            {
                foundPuzzle = Activator.CreateInstance(type, new object[] {new ConsoleInput()}) as IPuzzle;
                break;
            }
        }
    }
    if(foundPuzzle is not null)
    {
        return foundPuzzle;
    }
    else
    {
        throw new InvalidOperationException("Could not find puzzle. Do something different here.");
    }
}

static bool InterfaceFilter(Type typeObj, Object criteriaObj)
{
    if (typeObj.Name == criteriaObj.ToString())
        return true;
    else
        return false;
}