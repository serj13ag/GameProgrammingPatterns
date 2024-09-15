using PatternsExamples.Behavioral.Command.Scripts.Commands;
using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public abstract class InputHandler
    {
        public static bool HasUndoInput()
        {
            return Input.GetKeyDown(KeyCode.Z);
        }

        public static bool HasChangeControlledActorInput(ActorControlChanger actorControlChanger, out ICommand command)
        {
            command = null;

            if (Input.GetKeyDown(KeyCode.F))
            {
                command = new ChangeControlledActorCommand(actorControlChanger);
            }

            return command != null;
        }

        public static bool HasMoveActorInput(IMovableActor actor, out ICommand command)
        {
            command = null;

            if (Input.GetKeyDown(KeyCode.W))
            {
                command = new MoveActorCommand(actor, Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                command = new MoveActorCommand(actor, Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                command = new MoveActorCommand(actor, Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                command = new MoveActorCommand(actor, Vector3.right);
            }

            return command != null;
        }
    }
}