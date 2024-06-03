using UnityEngine;

namespace GPP
{
    public class AttackToNoteBook : MonoBehaviour
    {
        private NotebookHandler notebook;
        [SerializeField] private InfoBox infoBox;
        private void Awake()
        {
            notebook= FindAnyObjectByType<NotebookHandler>();
            infoBox = GetComponentInParent<InfoBox>();
        }

        public void AttachInfoBoxToNotebook()
        {
            Instantiate(infoBox.gameObject,notebook.transform);
        }
    }
}