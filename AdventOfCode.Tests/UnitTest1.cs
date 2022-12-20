namespace AdventOfCode.Tests;

public class Puzzle201501
{
    [Fact]
    public void Puzzle201501Works()
    {
        AdventOfCode.Puzzle201501 puzzle = new(new FakeInput());
        puzzle.Play();
    }
}


public class FakeInput : IProcessInput
{
    public string Process()
    {
        return "((()))";
    }
}