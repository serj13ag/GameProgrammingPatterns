namespace PatternsExamples.Behavioral.Command.Scripts.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}