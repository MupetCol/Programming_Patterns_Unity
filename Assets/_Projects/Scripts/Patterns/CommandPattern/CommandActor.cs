using UnityEngine;

namespace GPP
{
    public class CommandActor : MonoBehaviour
    {     
        [SerializeField] private int _moveUnits = 1;

        public CommandActor()
        {
            //Constructor for needed components on the Command Methods
        }


        public void Jump(){
            Debug.Log("Jump");
        }

        public void Move(Vector2 direction){
            transform.Translate(direction * _moveUnits);
        }

        public void Fire(){
            Debug.Log("Fire");
        }

        public void ChangePos(Vector2 newPos){
            transform.localPosition = newPos;
        }

        public void Buy(FloatReference wallet){
            
        }
    }
}