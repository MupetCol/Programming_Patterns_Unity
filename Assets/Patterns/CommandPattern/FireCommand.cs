using UnityEngine;

    public class FireCommand : Command
    {
        public override void Execute()
        {
            Fire();
        }

        private void Fire()
        {
            unit_.Fire();
        }

        public FireCommand(Unit unit) : base(unit)
        {
        }
    }