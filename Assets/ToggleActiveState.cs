using UnityEngine;

namespace GPP
{
    public class ToggleActiveState : MonoBehaviour
    {     
        public void ToggleState(GameObject obj)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}