using UnityEngine;

namespace GPP
{
    public class NotebookHandler : MonoBehaviour
    {
        NotebookAnimator animatorHandler;

        private void Awake()
        {
            animatorHandler = GetComponent<NotebookAnimator>(); 
        }


        public void ToggleNotebookSate()
        {
            if (animatorHandler.isHidden){
                animatorHandler.ShowNotebook();}
            else{
                animatorHandler.HideNotebook();}
        }
    }
}