using UnityEngine;

namespace GPP
{
    public class FireCommand : Command
    {     
        public FireCommand(CommandActor actor){
            _actor = actor;
        }
        public override void Execute()
        {
            _actor.Fire();
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }

        private void Fire()
        {

        }
    }
}