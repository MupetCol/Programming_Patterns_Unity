using UnityEngine;

namespace GPP
{
    public class MoveCommand : Command
    {     
        private Vector2 _moveDirection;

        public MoveCommand(Vector2 direction)
        {
            _moveDirection = direction;
        }

        public override void Execute(CommandActor actor)
        {
            actor.Move(_moveDirection);
        }

        public override void Undo(CommandActor actor)
        {
            actor.Move(-_moveDirection);
        }


    }
}