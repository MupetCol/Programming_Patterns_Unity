using TMPro;
using UnityEngine;

namespace GPP
{
    public class InventoryUI : MonoBehaviour
    {     
        public ItemInventory[] itemsOwned;
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
                itemsOwned[itemSelectedIndex].unitsOwned++;
            }else{
                itemsOwned[itemSelectedIndex].unitsOwned--;
            }
            texts[itemSelectedIndex].text = itemsOwned[itemSelectedIndex].unitsOwned.ToString();
        }

        public void UpdateItem(int addition, ShopItem.itemTypes itemType)
        {
            int itemSelectedIndex = -1;

            for (int i = 0; i < itemsOwned.Length; i++)
            {
                if (itemsOwned[i].itemType == itemType)
                {
                    itemSelectedIndex = i;
                    break;
                }
            }


            itemsOwned[itemSelectedIndex].unitsOwned += addition;
            texts[itemSelectedIndex].text = itemsOwned[itemSelectedIndex].unitsOwned.ToString();
        }

        [System.Serializable]
        public class ItemInventory
        {
            public ShopItem.itemTypes itemType;
            public Sprite itemSprite;
            public int unitsOwned;
        }
    }
}