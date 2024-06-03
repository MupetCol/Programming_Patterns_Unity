using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GPP
{
    public class InfoPanelSetter : MonoBehaviour
    {
        public ShopItem[] shopItems;
        public InfoBox infoBoxPrefab;
        private void Awake()
        {
            GenInfoBoxes();
        }

        private void GenInfoBoxes()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            foreach (ShopItem item in shopItems)
            {
                for (int i = 0; i < item.itemsTradeValues.Count; i++)
                {
                    InfoBox box = Instantiate(infoBoxPrefab, transform);
                    box.shopItemImage.sprite = item.itemSprite;
                    box.tradeItemImage.sprite = item.itemsTradeValues[i].itemSprite;
                    box.radeItemValueText.text = item.itemsTradeValues[i].tradeCost.ToString();
                }
            }
        }

        public void GenInfoBoxesOnEditor()
        {
            List<InfoBox> boxes = new List<InfoBox>();
            foreach (Transform child in transform)
            {
                boxes.Add(child.GetComponent<InfoBox>());   
            }

            foreach (ShopItem item in shopItems)
            {
                if(item.itemsTradeValues.Count == 0)
                {
                    Debug.LogWarning("No Trade Info to Display, Check Shopitem: " + item.name);
                }
                for (int i = 0; i < item.itemsTradeValues.Count; i++)
                {
                    InfoBox box;
                    if(boxes.Count > i)
                    {
                        box = boxes[i];
                    }
                    else
                    {
                        box = Instantiate(infoBoxPrefab, transform);
                    }
                    
                    box.shopItemImage.sprite = item.itemSprite;
                    box.tradeItemImage.sprite = item.itemsTradeValues[i].itemSprite;
                    box.radeItemValueText.text = item.itemsTradeValues[i].tradeCost.ToString();
                }
            }
        }
    }

    [System.Serializable]
    public class InfoBoxData
    {
        public float _tradeItemValue;
        public Sprite _tradeItemSprite;
        public Sprite _shopItemSprite;
    }
}