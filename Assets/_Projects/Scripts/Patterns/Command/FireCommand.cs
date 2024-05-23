using UnityEngine;

namespace GPP
{
    public class FireCommand : Command
    {     
        public override void Execute(CommandActor actor)
        {
            actor.Fire();
        }

        public override void Undo(CommandActor actor)
        {
            throw new System.NotImplementedException();
        }

        private void Fire()
        {

        }
    }
}