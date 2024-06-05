using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using static GPP.ShopItem;

namespace GPP
{
    public class TradeUIHandler : MonoBehaviour
    {
        [SerializeField] private Button nextItemBtn, prevItemBtn, increaseUnitsBtn, decreaseUnitsBtn;
        [SerializeField] private Image tradeItemImage;
        [SerializeField] private TMP_Text tradeItemUnits, itemUnits;
        [SerializeField] private FloatReference playerCoins;
        [SerializeField] private ShopItemReference ShopItemData;

        private int tradeItemConversions = 0;

        private GameObject UIParent;
        
        private InventoryUI inventoryUI;
        private int currTradeItemValue = -1;
        private void Awake()
        {
            inventoryUI = FindObjectOfType<InventoryUI>();
            ResetTrade();
            prevItemBtn.gameObject.SetActive(false);
            decreaseUnitsBtn.gameObject.SetActive(false);
            UIParent = transform.GetChild(0).gameObject;
        }

        private void Update()
        {
            if(ShopItemData.Value.shopItemType != ShopItem.itemTypes.Coins){
                //IF ISN'T COIN WE ASSUME ITS A VALID SHOP DATA VALUE
                tradeItemConversions = ShopItemData.Value.itemsTradeValues.Count - 1;
                currTradeItemValue = ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].tradeCost;
                UIParent.SetActive(true);}
            else {
                UIParent.SetActive(false); }
        }

        public void CloseTradeUI()
        {
            ShopItemData.Value.Reset();
            UIParent.SetActive(false);
        }

        public void NextItem()
        {
            var nextTradeItem = NextTradeItem();
            nextItemBtn.gameObject.SetActive(nextTradeItem);
            prevItemBtn.gameObject.SetActive(true);
            tradeItemImage.sprite = ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].itemSprite;

            currTradeItemValue = ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].tradeCost;
            ResetTrade();
        }

        public void PreviousItem()
        {
            var prevTradeItem = PreviousTradeItem();
            prevItemBtn.gameObject.SetActive(prevTradeItem);
            nextItemBtn.gameObject.SetActive(true);
            tradeItemImage.sprite = ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].itemSprite;

            currTradeItemValue = ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].tradeCost;
            ResetTrade();
        }

        public void IncreaseUnits()
        {
            
            ShopItemData.Value.tradeAmmount +=currTradeItemValue;

            decreaseUnitsBtn.gameObject.SetActive(ShopItemData.Value.tradeAmmount > currTradeItemValue);
            tradeItemUnits.text = ShopItemData.Value.tradeAmmount.ToString();
            UpdateTradeTotal();
        }

        public void DecreaseUnits()
        {
            ShopItemData.Value.tradeAmmount -=currTradeItemValue;

            decreaseUnitsBtn.gameObject.SetActive(ShopItemData.Value.tradeAmmount > currTradeItemValue);
            tradeItemUnits.text = ShopItemData.Value.tradeAmmount.ToString();
            UpdateTradeTotal();
        }

        public void SealTrade()
        {   
            //Reflect on the profit visuals
            //This is part of a undoable command so have to create UndoTrade()
            if(ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].itemType == ShopItem.itemTypes.Coins)
            {
                playerCoins.Value -= ShopItemData.Value.itemsTradeValues[ShopItemData.Value.tradeIndex].tradeCost;
            }
            else
            {
                inventoryUI.UpdateItem(true, ShopItemData.Value.shopItemType);
                ResetTrade();
            }
        }

        public bool NextTradeItem()
        {

            ShopItemData.Value.tradeIndex++;

            if (ShopItemData.Value.tradeIndex >= tradeItemConversions)
            {
                return false;
            }

            ShopItemData.Value.tradeItemSelected = (itemTypes)ShopItemData.Value.tradeIndex;
            return true;
        }

        public bool PreviousTradeItem()
        {
            ShopItemData.Value.tradeIndex--;
            if (ShopItemData.Value.tradeIndex <= tradeItemConversions)
            {
                return false;
            }


            ShopItemData.Value.tradeItemSelected = (itemTypes)ShopItemData.Value.tradeIndex;
            return true;
        }

        private void UpdateTradeTotal()
        {
            int total = Mathf.FloorToInt(ShopItemData.Value.tradeAmmount / currTradeItemValue);
            itemUnits.text = total.ToString();
        }

        private void ResetTrade()
        {
            ShopItemData.Value.tradeAmmount = currTradeItemValue;
            itemUnits.text = "1";
            tradeItemUnits.text = currTradeItemValue.ToString();
            decreaseUnitsBtn.gameObject.SetActive(false);
        }
    }
}