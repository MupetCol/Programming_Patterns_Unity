using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GPP
{
    public class CommandInputHandler : MonoBehaviour
    {
        [SerializeField] private TradeReference _currenTrade;
        [SerializeField] private FloatReference _playerCoins;
        [SerializeField] private CommandActor _actor;
        private InputMap _inputMap;
        private InventoryUI _inventoryUI;

        public static MoveSpot currentSpot;
        
        // KEYMAP SWITCHING LOGIC
        public enum KeyMaps {WestButton, SouthButton};
        public enum Commands {Fire, Jump};
        public List<InputPairing> inputPairings = new List<InputPairing>();

        private Wallet playerWallet;

        private void Awake()
        {
            _inventoryUI = FindObjectOfType<InventoryUI>();
            _inputMap = new InputMap();
            _inputMap.Player.Enable();
            playerWallet = FindObjectOfType<Wallet>();
        } 

        public Command HandleInput()
        {
            if(_inputMap.Player.DPad.WasPressedThisFrame()){
                Debug.Log("Added move command");

                Vector2 dir = _inputMap.Player.DPad.ReadValue<Vector2>();
                return new MoveCommand(dir, _actor);
            }

            if(_inputMap.Player.WestButton.WasPressedThisFrame()){

                return PairedCommand(inputPairings[(int)KeyMaps.WestButton].command);
            }

            if(_inputMap.Player.SouthButton.WasPressedThisFrame()){
                return PairedCommand(inputPairings[(int)KeyMaps.SouthButton].command);
            }

            return null;
        }

        public void RunChangePosCommand(Transform newPos)
        {
            Command command = new ChangePosCommand(_actor, newPos.position, playerWallet, currentSpot);
            CommandInvoker.Add(command);
        }

        public void RunBuyCommand()
        {
            Command command = new BuyCommand(_currenTrade.Value.tradedUnits, _playerCoins,
                _currenTrade.Value.boughtUnits, _currenTrade.Value.tradedItem, _currenTrade.Value.shopItem, _inventoryUI);
            CommandInvoker.Add(command);
        }

        private Command PairedCommand(int command){

            switch(command){

                case (int)Commands.Fire:
                return new FireCommand(_actor);

                case (int)Commands.Jump:
                return new JumpCommand(_actor);

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