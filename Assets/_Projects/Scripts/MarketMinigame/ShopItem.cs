using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GPP
{
    public class ShopItem : MonoBehaviour
    {
        public enum itemTypes {Coins, Flowers, Paintings}

        public ShopItemReference TradeItemData;
        public ShopItemData data;

        private void Awake(){
            transform.GetChild(0).GetComponent<Image>().sprite = data.itemSprite;
        }


        public void SelectShopItem()
        {
            TradeItemData.Value.Init(data.itemsTradeValues, data.shopItemType, data.itemSprite);
        }
    }

    [System.Serializable]
    public class ShopItemData
    {
        public Sprite itemSprite;

        [HideInInspector]
        public ShopItem.itemTypes tradeItemSelected = ShopItem.itemTypes.Coins;
        public ShopItem.itemTypes shopItemType = ShopItem.itemTypes.Coins;

        //List of each type of item in the enum, below list of values of that item that costs this shop item
        public List<ItemTrade> itemsTradeValues = new List<ItemTrade>();

        public void Reset()
        {
            itemsTradeValues.Clear();
            tradeItemSelected = ShopItem.itemTypes.Coins;
            shopItemType = ShopItem.itemTypes.Coins;
            itemSprite = null;
        }

        public void Init(List<ItemTrade> itemsTradeValues, ShopItem.itemTypes shopItemType, Sprite itemSprite)
        {
            this.itemsTradeValues = new List<ItemTrade>(itemsTradeValues);
            this.itemSprite = itemSprite;
            this.shopItemType = shopItemType;
        }
    }

    [System.Serializable]
    public class ItemTrade{
        public ShopItem.itemTypes itemType;
        public Sprite itemSprite;
        public int tradeCost;
    }
}