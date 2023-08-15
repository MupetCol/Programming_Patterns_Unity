using UnityEngine;

    public class CommandNull : Command
    {
        // "Null object" Pattern
        public override void Execute()
        {
            //Do nothing
        }

        public CommandNull(Unit unit) : base(unit)
        {
        }
    }