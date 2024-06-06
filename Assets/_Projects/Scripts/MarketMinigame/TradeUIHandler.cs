using System;
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
    [Serializable]
    public class TradeData
    {
        public ShopItem.itemTypes tradedItem, shopItem;
        public int tradedUnits, boughtUnits;
    }

    public class TradeUIHandler : MonoBehaviour
    {
        [SerializeField] private Button nextItemBtn, prevItemBtn, increaseUnitsBtn, decreaseUnitsBtn;
        [SerializeField] private Image tradeItemImage;
        [SerializeField] private TMP_Text tradeItemUnitsTxt, ShopItemUnitsTxt;
        [SerializeField] private FloatReference playerCoins;
        [SerializeField] private ShopItemReference ShopItemData;
        [SerializeField] private TradeReference tradeData;

        private int tradeItemConversions = 0;

        private GameObject UIParent;
        
        private InventoryUI inventoryUI;

        private int tradeIndex = 0;

        private int TradeItemUnits { get { return tradeData.Value.tradedUnits; 
        }
            set { tradeData.Value.tradedUnits = value; }
        }

        private int ShopItemUnits
        {
            get { return tradeData.Value.boughtUnits; }
            set { tradeData.Value.boughtUnits = value; }
        }

        public bool CheckNext()
        {

            tradeIndex++;

            Debug.Log(tradeItemConversions);
            if (tradeIndex >= tradeItemConversions - 1)
            {
                return false;
            }

            tradeData.Value.tradedItem = (itemTypes)tradeIndex;
            return true;
        }

        public bool CheckPrevious()
        {
            tradeIndex--;
            if (tradeIndex <= 0)
            {
                return false;
            }

            tradeData.Value.tradedItem = (itemTypes)tradeIndex;
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
                tradeData.Value.shopItem = ShopItemData.Value.shopItemType;
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
            tradeData.Value.tradedUnits = ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            tradeItemUnitsTxt.text = tradeData.Value.tradedUnits.ToString();
            ShopItemUnitsTxt.text = "1";
        }

        public void IncreaseUnits()
        {

            TradeItemUnits += ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            Debug.Log(TradeItemUnits);
            ShopItemUnits++;

            // CHECK FOR INVENTORY AND DISABLE/ENABLE INCREASE UNTIS BUTTONS
            //decreaseUnitsBtn.gameObject.SetActive(tradeItemUnits > currTradeItemValue);
            tradeItemUnitsTxt.text = TradeItemUnits.ToString();
            ShopItemUnitsTxt.text = ShopItemUnits.ToString();
        }

        public void DecreaseUnits()
        {
            TradeItemUnits -= ShopItemData.Value.itemsTradeValues[tradeIndex].tradeCost;
            ShopItemUnits--;

            //decreaseUnitsBtn.gameObject.SetActive(tradeItemUnits > currTradeItemValue);
            tradeItemUnitsTxt.text = TradeItemUnits.ToString();
            ShopItemUnitsTxt.text = ShopItemUnits.ToString();
        }

        private void ChangeTradeItem()
        {
            ShopItemUnits = 1;
            ShopItemUnitsTxt.text = "1";
            tradeItemUnitsTxt.text = TradeItemUnits.ToString();
            decreaseUnitsBtn.gameObject.SetActive(false);
        }
    }
}