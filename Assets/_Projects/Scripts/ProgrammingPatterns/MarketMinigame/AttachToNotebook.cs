using UnityEngine;

namespace GPP
{
    public class AttachToNotebook : MonoBehaviour
    {
        private NotebookHandler notebook;
        [SerializeField] private NotebookInfoBox notebookInfoBox;
        [SerializeField] private InfoBox infoBox;
        private void Awake()
        {
            notebook= FindAnyObjectByType<NotebookHandler>();
            infoBox = GetComponentInParent<InfoBox>();
        }

        public void AttachInfoBoxToNotebook()
        {
            NotebookInfoBox info = Instantiate(notebookInfoBox,notebook.transform);
            info.Init(infoBox.shopItemImage.sprite, infoBox.tradeItemImage.sprite,
                infoBox.radeItemValueText.text.ToString(), infoBox);
        }
    }
}