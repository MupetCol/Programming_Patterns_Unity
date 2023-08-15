using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
        private static Unit player;

        private static Command buttonX_, buttonA_, buttonY_, buttonB_,
            dpadUp_, dpadDown_, dpadRight_, dpadLeft_;

        private static InputAction BUTTON_X, BUTTON_Y, BUTTON_B, BUTTON_A,
            DPAD_UP, DPAD_DOWN, DPAD_RIGHT, DPAD_LEFT;

        private Controller _input;
        public static Command handleInput()
        {
            // Unit* unit = getSelectedUnit(); If it was a fleshed system we would have to get active unity every command
            
            if (BUTTON_B == null) return null;
            
            // So only gets in when actions have been initialized
            if (BUTTON_X.WasPressedThisFrame()) return buttonX_;
            if (BUTTON_A.WasPressedThisFrame()) return buttonA_;
            if (BUTTON_Y.WasPressedThisFrame()) return buttonY_;
            if (BUTTON_B.WasPressedThisFrame()) return buttonB_;

            if (DPAD_UP.WasPressedThisFrame()) 
            {
                // Move the unit up one.
                int destY = player.y() + 1;
                return new MoveUnitCommand(
                    player, player.x(), destY);
            }
            if (DPAD_RIGHT.WasPressedThisFrame()) 
            {
                // Move the unit right one.
                int destX = player.x() + 1;
                return new MoveUnitCommand(
                    player, destX, player.y());
            }
            if (DPAD_LEFT.WasPressedThisFrame()) 
            {
                // Move the unit left one.
                int destX = player.x() - 1;
                return new MoveUnitCommand(
                    player, destX, player.y());
            }
            if (DPAD_DOWN.WasPressedThisFrame()) 
            {
                // Move the unit down one.
                int destY = player.y() - 1;
                return new MoveUnitCommand(
                    player, player.x(), destY);
            }

            return null;
        }

        void Start()
        {
            _input = new Controller();

            player = GameObject.Find("Player").GetComponent<Unit>();
            
            // Assign input actions 
            BUTTON_X = _input.PlayerActions.Fire;
            BUTTON_Y = _input.PlayerActions.Undo;
            BUTTON_A = _input.PlayerActions.Jump;
            BUTTON_B = _input.PlayerActions.EastButton;
            DPAD_DOWN = _input.PlayerActions.MoveDown;
            DPAD_UP = _input.PlayerActions.MoveUp;
            DPAD_LEFT = _input.PlayerActions.MoveLeft;
            DPAD_RIGHT = _input.PlayerActions.MoveRight;
            
            _input.PlayerActions.Enable();

            // Instantiate commands that don't change on runtime
            buttonX_ = new FireCommand(player);
            buttonA_ = new JumpCommand(player);
            buttonY_ = new CommandNull(player);
            buttonB_ = new CommandNull(player);
        }
}