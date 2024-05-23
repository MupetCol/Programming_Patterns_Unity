using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GPP
{
    public class CommandInputHandler : MonoBehaviour
    {     
        private InputMap _inputMap;
        
        // KEYMAP SWITCHING LOGIC
        public enum KeyMaps {WestButton, SouthButton};
        public enum Commands {Fire, Jump};
        public List<InputPairing> inputPairings = new List<InputPairing>();

        // COMMANDS 
        private FireCommand fireCommand = new FireCommand();
        private JumpCommand jumpCommand = new JumpCommand();

        private void Awake()
        {
            _inputMap = new InputMap();
            _inputMap.Player.Enable();
        } 

        public Command HandleInput()
        {
            if(_inputMap.Player.DPad.WasPressedThisFrame()){
                Debug.Log("Added move command");

                Vector2 dir = _inputMap.Player.DPad.ReadValue<Vector2>();
                return new MoveCommand(dir);
            }

            if(_inputMap.Player.WestButton.WasPressedThisFrame()){

                return PairedCommand(inputPairings[(int)KeyMaps.WestButton].command);
            }

            if(_inputMap.Player.SouthButton.WasPressedThisFrame()){
                return PairedCommand(inputPairings[(int)KeyMaps.SouthButton].command);
            }

            return null;
        }

        private Command PairedCommand(int command){

            switch(command){

                case (int)Commands.Fire:
                return fireCommand;

                case (int)Commands.Jump:
                return jumpCommand;

                default:
                return null;
            }
        }
    }

    [Serializable]
    public class InputPairing{
        public int keyMap;
        public int command;
    }
}