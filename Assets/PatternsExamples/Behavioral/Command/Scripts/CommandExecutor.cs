using System.Collections.Generic;
using System.Text;
using PatternsExamples.Behavioral.Command.Scripts.Commands;
using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public class CommandExecutor : MonoBehaviour
    {
        [SerializeField] private int _undoCapacity;

        private readonly LinkedList<ICommand> _lastCommands = new LinkedList<ICommand>();

        private void Update()
        {
            if (InputHandler.HasUndoInput())
            {
                TryUndoLastCommand();
            }
        }

        public void Execute(ICommand command)
        {
            command.Execute();
            StoreCommand(command);
        }

        private void TryUndoLastCommand()
        {
            if (_lastCommands.Count == 0)
            {
                return;
            }

            var lastCommand = PopLastCommand();
            lastCommand.Undo();
        }

        private void StoreCommand(ICommand command)
        {
            if (_lastCommands.Count >= _undoCapacity)
            {
                _lastCommands.RemoveFirst();
            }

            _lastCommands.AddLast(command);
            PrintCommandsCapacity();
        }

        private ICommand PopLastCommand()
        {
            var lastCommand = _lastCommands.Last.Value;
            _lastCommands.RemoveLast();
            PrintCommandsCapacity();

            return lastCommand;
        }

        private void PrintCommandsCapacity()
        {
            var sb = new StringBuilder();
            sb.Append("Undo capacity: ");

            for (var i = 0; i < _undoCapacity; i++)
            {
                var square = _lastCommands.Count > i ? "\u25a0" : "\u25a1";
                sb.Append(square);
            }

            Debug.Log(sb.ToString());
        }
    }
}