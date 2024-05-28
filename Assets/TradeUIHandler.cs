using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GPP
{
    public class TradeUIHandler : MonoBehaviour
    {     
        [SerializeField] private Button nextItemBtn, prevItemBtn, increaseUnitsBtn, decreaseImotsBtn;
        [SerializeField] private Image tradeItemImage;
        [SerializeField] private TMP_Text tradeItemUnits, itemUnits;
        private ShopItem item;
        private void Awake()
        {
            item = GetComponentInParent<ShopItem>();
        }

        public void NextItem(){
            var nextTradeItem = item.NextTradeItem();
            nextItemBtn.gameObject.SetActive(nextTradeItem);
            prevItemBtn.gameObject.SetActive(true);
            tradeItemImage.sprite = item.itemsTradeValues[item.tradeIndex].itemSprite;
        }

        public void PreviousItem(){
            var prevTradeItem = item.PreviousTradeItem();
            prevItemBtn.gameObject.SetActive(prevTradeItem);
            nextItemBtn.gameObject.SetActive(true);
            tradeItemImage.sprite = item.itemsTradeValues[item.tradeIndex].itemSprite;
        }
    }
}