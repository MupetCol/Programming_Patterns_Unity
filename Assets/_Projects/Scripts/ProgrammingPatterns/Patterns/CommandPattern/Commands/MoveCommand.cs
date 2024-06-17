using UnityEngine;

namespace GPP
{
    public class MoveCommand : Command
    {     
        private Vector2 _moveDirection;

        public MoveCommand(Vector2 direction, CommandActor actor)
        {
            _actor = actor;
            _moveDirection = direction;
        }

        public override void Execute()
        {
            _actor.Move(_moveDirection);
        }

        public override void Undo()
        {
            _actor.Move(-_moveDirection);
        }
    }
}