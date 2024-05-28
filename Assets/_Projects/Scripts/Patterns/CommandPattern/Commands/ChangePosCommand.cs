using System;
using UnityEngine;

namespace GPP
{
    public class ChangePosCommand : Command
    {
        private Vector2 _newPos;

        public ChangePosCommand(CommandActor actor, Vector2 newPos, Wallet wallet, MoveSpot spot)
        {
            _actor = actor;
            _newPos = newPos;
            wallet.PayGas(spot.gasCost);
        }

        public override void Execute()
        {
            _actor.ChangePos(_newPos);
        }

        public override void Undo()
        {
            _actor.ChangePos(-_newPos);
        }
    }
}