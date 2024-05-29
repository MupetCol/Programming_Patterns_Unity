using UnityEngine;

namespace GPP
{
    public class TreeModel : MonoBehaviour
    {    
        [TextArea(5,10)]
        [Tooltip("Doesn't do anything. Just comments shown in inspector")]
        public string Notes = "This is quite the obvious use case"
        + " a less obvious and more useful would be on procedurally generated worlds"
        + "storing a model per terrain (tile) type saving a ton of memory" 
        + "can also be complemented with a pool pattern for instanced already tiles .";
        
        public Sprite bark;
        public Sprite leaves;
    }
}