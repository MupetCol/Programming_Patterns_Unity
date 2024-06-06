using UnityEngine;

namespace GPP
{
    public class BuyCommand : Command
    {     
        private InventoryUI _inventoryUI;
        private FloatReference _playerCoins;
        private int _cost;
        private ShopItem.itemTypes _purchaseType;

        public BuyCommand(int cost, FloatReference playerCoins, ShopItem.itemTypes purchaseType, InventoryUI inventoryUI)
        {
            _cost = cost;
            _purchaseType = purchaseType;
            _inventoryUI = inventoryUI;
            _playerCoins = playerCoins;
        }

        public override void Execute()
        {
            if(_purchaseType == ShopItem.itemTypes.Coins)
            {
                _playerCoins.Value -= _cost;
            }
            else
            {
                _inventoryUI.UpdateItem(-_cost, _purchaseType);
            }
        }

        public override void Undo()
        {
            if (_purchaseType == ShopItem.itemTypes.Coins)
            {
                _playerCoins.Value += _cost;
            }
            else
            {
                _inventoryUI.UpdateItem(_cost, _purchaseType);
            }
        }
    }
}