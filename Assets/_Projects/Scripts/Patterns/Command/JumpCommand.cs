using UnityEngine;

namespace GPP
{
    public class JumpCommand : Command
    {
        public override void Execute(CommandActor actor)
        {
            actor.Jump();
        }

        public override void Undo(CommandActor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}