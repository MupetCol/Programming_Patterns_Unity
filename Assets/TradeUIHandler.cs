using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

namespace GPP
{
    public class TradeUIHandler : MonoBehaviour
    {     
        [SerializeField] private Button nextItemBtn, prevItemBtn, increaseUnitsBtn, decreaseUnitsBtn;
        [SerializeField] private Image tradeItemImage;
        [SerializeField] private TMP_Text tradeItemUnits, itemUnits;
        private ShopItem item;
        private int currTradeItemValue = -1;
        private void Awake()
        {
            item = GetComponentInParent<ShopItem>();
            currTradeItemValue = item.itemsTradeValues[item.tradeIndex].quantity;
            prevItemBtn.gameObject.SetActive(false);
            decreaseUnitsBtn.gameObject.SetActive(false);
        }

        public void NextItem()
        {
            var nextTradeItem = item.NextTradeItem();
            nextItemBtn.gameObject.SetActive(nextTradeItem);
            prevItemBtn.gameObject.SetActive(true);
            tradeItemImage.sprite = item.itemsTradeValues[item.tradeIndex].itemSprite;

            currTradeItemValue = item.itemsTradeValues[item.tradeIndex].quantity;
            ResetTrade();
        }

        public void PreviousItem()
        {
            var prevTradeItem = item.PreviousTradeItem();
            prevItemBtn.gameObject.SetActive(prevTradeItem);
            nextItemBtn.gameObject.SetActive(true);
            tradeItemImage.sprite = item.itemsTradeValues[item.tradeIndex].itemSprite;

            currTradeItemValue = item.itemsTradeValues[item.tradeIndex].quantity;
            ResetTrade();
        }

        public void IncreaseUnits()
        {
            
            item.tradeAmmount+=currTradeItemValue;

            decreaseUnitsBtn.gameObject.SetActive(item.tradeAmmount > currTradeItemValue);
            tradeItemUnits.text = item.tradeAmmount.ToString();
            UpdateTradeTotal();
        }

        public void DecreaseUnits()
        {
            item.tradeAmmount-=currTradeItemValue;

            decreaseUnitsBtn.gameObject.SetActive(item.tradeAmmount > currTradeItemValue);
            tradeItemUnits.text = item.tradeAmmount.ToString();
            UpdateTradeTotal();
        }

        public void SealTrade()
        {   
            //Reflect on the profit visuals
            //This is part of a undoable command so have to create UndoTrade()
            ResetTrade();
        }

        private void UpdateTradeTotal()
        {
            int total = Mathf.FloorToInt(item.tradeAmmount / currTradeItemValue);
            itemUnits.text = total.ToString();
        }

        private void ResetTrade()
        {
            item.tradeAmmount = currTradeItemValue;
            itemUnits.text = "1";
            tradeItemUnits.text = currTradeItemValue.ToString();
            decreaseUnitsBtn.gameObject.SetActive(false);
        }


    }
}