using System.Collections;
using UnityEngine;

namespace GPP
{
    public class NotebookAnimator : MonoBehaviour
    {
        public const string upAnimationID = "MerchantNotebook_UP";
        public const string downAnimationID = "MerchantNotebook_DOWN";

        private Animator animator;
        [HideInInspector]
        public bool isHidden = true;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ShowNotebook()
        {
            StartCoroutine(ShowNotebookCor());
        }

        private IEnumerator ShowNotebookCor()
        {
            if(!isHidden) { yield return null; }

            animator.Play(upAnimationID);
            var state = animator.GetCurrentAnimatorClipInfo(0);

            yield return new WaitForSeconds(.5f);
            Debug.Log(state[0].clip.name);
            yield return new WaitForSeconds(state[0].clip.length);

            isHidden = false;
        }

        public void HideNotebook()
        {
            StartCoroutine(HideNotebookCor());
        }

        private IEnumerator HideNotebookCor()
        {
            if (isHidden) { yield return null; }

            animator.Play(downAnimationID);
            var state = animator.GetCurrentAnimatorClipInfo(0);

            yield return new WaitForSeconds(.5f);
            Debug.Log(state[0].clip.name);
            yield return new WaitForSeconds(state[0].clip.length);

            isHidden = true;
        }
    }
}