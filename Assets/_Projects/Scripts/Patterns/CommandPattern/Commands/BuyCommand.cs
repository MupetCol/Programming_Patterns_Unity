using UnityEngine;

namespace GPP
{
    public class BuyCommand : Command
    {     
        private InventoryUI _inventoryUI;
        private FloatReference _playerCoins;
        private int _tradedUnits;
        private int _boughtUnits;
        private ShopItem.itemTypes _purchaseType;
        private ShopItem.itemTypes _shopItem;

        public BuyCommand(int tradedUnits, FloatReference playerCoins, int boughtUnits, ShopItem.itemTypes purchaseType, ShopItem.itemTypes shopitem, InventoryUI inventoryUI)
        {
            _tradedUnits = tradedUnits;
            _purchaseType = purchaseType;
            _inventoryUI = inventoryUI;
            _playerCoins = playerCoins;
            _boughtUnits = boughtUnits;
            _shopItem = shopitem;
        }

        public override void Execute()
        {
            if (_tradedUnits > _inventoryUI.GetOwnedUnits(_purchaseType)) return;

            if(_purchaseType == ShopItem.itemTypes.Coins){
                _playerCoins.Value -= _tradedUnits;}
            _inventoryUI.UpdateItem(-_tradedUnits, _purchaseType);
            _inventoryUI.UpdateItem(_boughtUnits, _shopItem);
        }

        public override void Undo()
        {
            if (_purchaseType == ShopItem.itemTypes.Coins)
            {
                _playerCoins.Value += _tradedUnits;
            }
            else
            {
                _inventoryUI.UpdateItem(_tradedUnits, _purchaseType);
            }
        }
    }
}