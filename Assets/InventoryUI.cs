using TMPro;
using UnityEngine;

namespace GPP
{
    public class InventoryUI : MonoBehaviour
    {     
        public ItemTrade[] itemsOwned;
        public TMP_Text[] texts;
        
        public void UpdateItem(bool add, ShopItem.itemTypes itemType)
        {
            int itemSelectedIndex = -1;

            for(int i = 0;  i < itemsOwned.Length; i++){
                if(itemsOwned[i].itemType == itemType){
                    itemSelectedIndex = i;
                    break;
                }
            }
        

            if(add){
                itemsOwned[itemSelectedIndex].quantity++;
            }else{
                itemsOwned[itemSelectedIndex].quantity--;
            }
            texts[itemSelectedIndex].text = itemsOwned[itemSelectedIndex].quantity.ToString();
        }
    }
}