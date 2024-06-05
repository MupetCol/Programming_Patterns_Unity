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
            //enumCount = tradeItems.GetNames(typeof(tradeItems)).Length - 1;
        }


        public void SelectShopItem()
        {
            TradeItemData.Value = data;
        }


    }

    [System.Serializable]
    public class ShopItemData
    {
        public Sprite itemSprite;

        [HideInInspector]
        public ShopItem.itemTypes tradeItemSelected = ShopItem.itemTypes.Coins;
        public ShopItem.itemTypes shopItemType = ShopItem.itemTypes.Coins;

        [Range(1f, 100f)]
        public int tradeIndex = 0;
        //Min 1
        [Range(1f, 100f)]
        public int tradeAmmount = 1;

        //List of each type of item in the enum, below list of values of that item that costs this shop item
        public List<ItemTrade> itemsTradeValues = new List<ItemTrade>();

        public void Reset()
        {
            itemsTradeValues.Clear();
            tradeAmmount = 1;
            tradeIndex = 0;
            tradeItemSelected = ShopItem.itemTypes.Coins;
            shopItemType = ShopItem.itemTypes.Coins;
        }
    }

    [System.Serializable]
    public class ItemTrade{
        public ShopItem.itemTypes itemType;
        public Sprite itemSprite;
        public int tradeCost;
    }
}