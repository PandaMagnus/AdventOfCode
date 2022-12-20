namespace AdventOfCode;

public class Puzzle201501 : IPuzzle
{
    public Puzzle201501(IProcessInput input)
    {
        Console.WriteLine(@"Welcome to the 2015, Day 1 puzzle.\r\n
                            For this puzzle, you must provide Santa directions to the correct apartments in a large building.\r\n
                            He starts on floor 0. an open parens ( means he should go up a floor.\r\n
                            A close parens ) means he should go down a floor.\r\n
                            For example: ((( and (()(()( both result in floor 3.\r\n
                            ()) and ))( both result in floor -1 (the first basement level).");
        Console.WriteLine("For more information, please visit: https://adventofcode.com/2015/day/1");

        ProcessInput = input;
    }

    public IProcessInput ProcessInput { get; }

    // Or should this be an int for the return code?
    // Or void and let this method handle all appropriate results?
    public string Play()
    {
        string? instructions = null;
        do
        {
            Console.WriteLine("Please enter a set of instructions.");
            instructions = ProcessInput.Process();
            if (instructions.ToUpperInvariant() == "EXIT") return "Exiting...";
        }
        while (string.IsNullOrWhiteSpace(instructions) 
            && instructions.All(c => c is '(' || c is ')'));

        char[] steps = instructions!.ToCharArray();

        int floor = 0;

        // Is there a way to this simpler?
        // Add up all of the ( and all of the )?
        foreach(char c in steps)
        {
            if(c is '(')
            {
                floor++;
            }
            else
            {
                floor--;
            }
        }

        return $"Santa is on floor {floor}";
    }
}


public class ConsoleInput : IProcessInput
{
    public string Process()
    {
        return Console.ReadLine() ?? "";
    }
}