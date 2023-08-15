using UnityEngine;

    public class Move : MonoBehaviour
    {
        public void UseModule(int x, int y)
        {
            transform.position = new Vector2(x, y);
        }
    }