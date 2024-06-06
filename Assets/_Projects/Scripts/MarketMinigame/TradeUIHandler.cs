using System.Runtime.CompilerServices;
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
        [SerializeField] private TMP_Text tradeItemUnitsTxt, shopItemUnitsTxt;
        [SerializeField] private FloatReference playerCoins;
        [SerializeField] private ShopItemReference ShopItemData;

        private int tradeItemConversions = 0;

        private GameObject UIParent;
        
        private InventoryUI inventoryUI;

        private int tradeIndex = 0;
        private int tradeItemUnits = 1;
        private int shopItemUnits = 1;

        public bool CheckNext()
        {

            tradeIndex++;

            Debug.Log(tradeItemConversions);
            if (tradeIndex >= tradeItemConversions - 1)
            {
                return false;
            }

            ShopItemData.Value.tradeItemSelected = (itemTypes)tradeIndex;
            return true;
        }

        public bool CheckPrevious()
        {
            tradeIndex--;
            if (tradeIndex <= 0)
            {
                return false;
            }


            ShopItemData.Value.tradeItemSelected = (itemTypes)tradeIndex;
            return true;
        }

        private void Awake()
        {
            inventoryUI = FindObjectOfType<InventoryUI>();
            ChangeTradeItem();
            prevItemBtn.gameObject.SetActive(false);
            decreaseUnitsBtn.gameObject.SetActive(false);
            UIParent = transform.GetChild(0).gameObject;
        }

        private void Update()
        {
            if(ShopItemData.Value.shopItemType != ShopItem.itemTypes.Coins && !UIParent.activeSelf){
                //IF ISN'T COIN WE ASSUME ITS A VALID SHOP DATA VALUE
                tradeItemConversions = ShopItemData.Value.itemsTradeValues.Count;
                SetTradeUI(false, nextItemBtn.gameObject, prevItemBtn.gameObject);
                UIParent.SetActive(true);}
        }

        public void CloseTradeUI()
        {
            ShopItemData.Value.Reset();
            ChangeTradeItem();
            UIParent.SetActive(false);
            tradeIndex = 0;
        }

        public void NextTradeItem()
        {
            var isNextItem = CheckNext();

            SetTradeUI(isNextItem, prevItemBtn.gameObject, nextItemBtn.gameObject);
            ChangeTradeItem();
        }

        public void PreviousTradeItem()
        {
            var isPreviousItem = CheckPrevious();

            SetTradeUI(isPreviousItem, nextItemBtn.gameObject, prevItemBtn.gameObject);
            ChangeTradeItem();
        }

        private void SetTradeUI(bool buttonActiveState, GameObject enableObject, GameObject conditionalObject)
        {
            conditionalObject.SetActive(buttonActiveState);
            enableObject.SetActive(true);
            tradeItemImage.sprite = ShopItemData.Value.itemsTradeValues[tradeIndex].itemSprite;
            tradeItemUnits = ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            tradeItemUnitsTxt.text = tradeItemUnits.ToString();
            shopItemUnitsTxt.text = "1";
        }

        public void IncreaseUnits()
        {
            
            tradeItemUnits += ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            shopItemUnits++;

            // CHECK FOR INVENTORY AND DISABLE/ENABLE INCREASE UNTIS BUTTONS
            //decreaseUnitsBtn.gameObject.SetActive(tradeItemUnits > currTradeItemValue);
            tradeItemUnitsTxt.text = tradeItemUnits.ToString();
            shopItemUnitsTxt.text = shopItemUnits.ToString();
        }

        public void DecreaseUnits()
        {
            tradeItemUnits -= ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            shopItemUnits--;

            //decreaseUnitsBtn.gameObject.SetActive(tradeItemUnits > currTradeItemValue);
            tradeItemUnitsTxt.text = tradeItemUnits.ToString();
            shopItemUnitsTxt.text = shopItemUnits.ToString();
        }

        public void SealTrade()
        {   
            //Reflect on the profit visuals
            //This is part of a undoable command so have to create UndoTrade()
            if(ShopItemData.Value.itemsTradeValues[tradeIndex].itemType == ShopItem.itemTypes.Coins)
            {
                playerCoins.Value -= ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            }
            else
            {
                inventoryUI.UpdateItem(true, ShopItemData.Value.shopItemType);
                ChangeTradeItem();
            }
        }

        private void ChangeTradeItem()
        {
            shopItemUnits = 1;
            shopItemUnitsTxt.text = "1";
            tradeItemUnitsTxt.text = tradeItemUnits.ToString();
            decreaseUnitsBtn.gameObject.SetActive(false);
        }
    }
}