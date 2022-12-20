namespace AdventOfCode;

public interface IPuzzle
{
    IProcessInput ProcessInput { get; }
    string Play();
}


public interface IProcessInput
{
    string Process();
}