using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace GPP
{
    public class MoveSpot : MonoBehaviour
    {     
        public UnityEvent MoveEvent;
        public float gasCost = 10f;

        private void OnMouseDown(){
            CommandInputHandler.currentSpot = this;
            MoveEvent?.Invoke();
        }
    }
}