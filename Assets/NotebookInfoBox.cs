using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GPP
{
    public class NotebookInfoBox : MonoBehaviour
    {
        public Image shopItemImage, tradeItemImage;
        public TMP_Text tradeItemValueText;
        public InfoBox referenceInfoBox;

        public void Init(Sprite itemSprite, Sprite tradeItemSprite, string tradeValue, InfoBox refInfo)
        {
            shopItemImage.sprite = itemSprite;
            tradeItemImage.sprite = tradeItemSprite;    
            tradeItemValueText.text = tradeValue;
            referenceInfoBox = refInfo;
        }

        public void RemoveFromNotebook()
        {
            referenceInfoBox.attachToNotebookBtn.interactable = true;
            Destroy(this.gameObject);
        }
    }
}