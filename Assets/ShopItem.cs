using System.Collections.Generic;
using UnityEngine;

namespace GPP
{
    public class ShopItem : MonoBehaviour
    {     
        public enum itemTypes {Coins, Flowers, Paintings};

        [HideInInspector]
        public itemTypes tradeItemSelected = itemTypes.Coins;
        public itemTypes shopItemType = itemTypes.Coins;
  
        public int tradeIndex = 0;
        //Min 1
        public int tradeAmmount = 1;
        private int tradeItemConversions = 0;

        //List of each type of item in the enum, below list of values of that item that costs this shop item
        public List<ItemTrade> itemsTradeValues = new List<ItemTrade>();

        private void Awake(){
            tradeItemConversions = itemsTradeValues.Count - 1;
            //enumCount = tradeItems.GetNames(typeof(tradeItems)).Length - 1;
            Debug.Log(tradeItemConversions);
        }


        public bool NextTradeItem(){
            
            tradeIndex++;

            if(tradeIndex >= tradeItemConversions){
                return false;
            }

            tradeItemSelected = (itemTypes)tradeIndex;
            return true;
        }

        public bool PreviousTradeItem(){
            tradeIndex--;
            if(tradeIndex <= tradeItemConversions){
                return false;
            }
            

            tradeItemSelected = (itemTypes)tradeIndex;
            return true;
        }
    }

    [System.Serializable]
    public class ItemTrade{
        public ShopItem.itemTypes itemType;
        public Sprite itemSprite;
        public int quantity;
    }
}