using UnityEngine;

namespace GPP
{
    public class JumpCommand : Command
    {
         public JumpCommand(CommandActor actor){
            _actor = actor;
        }
        public override void Execute()
        {
            _actor.Jump();
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}