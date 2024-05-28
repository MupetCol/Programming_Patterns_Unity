using System.Collections.Generic;
using UnityEngine;

namespace GPP
{
    public class ShopItem : MonoBehaviour
    {     
        public enum tradeItems {Coins, Flowers, Paintings};
        public int availableUnits = 1;

        [HideInInspector]
        public tradeItems tradeItemSelected = tradeItems.Coins;
        public int tradeIndex = 0;
        private int tradeCount = 0;
        


        //List of each type of item in the enum, below list of values of that item that costs this shop item
        public List<ItemTrade> itemsTradeValues = new List<ItemTrade>();

        private void Awake(){
            tradeCount = itemsTradeValues.Count - 1;
            //enumCount = tradeItems.GetNames(typeof(tradeItems)).Length - 1;
            Debug.Log(tradeCount);
        }

        

        public void Buy(int units){
            if(availableUnits < units) return;

            availableUnits -= units;
        }

        public void SellBack(int units){
            availableUnits += units;
        }


        public bool NextTradeItem(){
            
            tradeIndex++;

            if(tradeIndex >= tradeCount){
                return false;
            }

            tradeItemSelected = (tradeItems)tradeIndex;
            return true;
        }

        public bool PreviousTradeItem(){
            tradeIndex--;
            if(tradeIndex <= tradeCount){
                return false;
            }
            

            tradeItemSelected = (tradeItems)tradeIndex;
            return true;
        }
    }

    [System.Serializable]

    public class ItemTrade{
        public ShopItem.tradeItems itemType;
        public Sprite itemSprite;
        public int quantity;
    }
}