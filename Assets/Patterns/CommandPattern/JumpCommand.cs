using UnityEngine;

    public class JumpCommand : Command
    {
        public override void Execute()
        {
            Jump();
        }

        private void Jump()
        {
            unit_.Jump();
        }

        public JumpCommand(Unit unit) : base(unit)
        {
        }
    }