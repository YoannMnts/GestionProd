public interface IPuzzle
{
    bool IsCompleted { get; }
    event System.Action OnPuzzleCompleted;
}