using TKS;
using UnityEngine;

namespace GPP
{
    public class StatsHandler : MonoBehaviour
    {     
        [SerializeField] private FloatReference healthPoints;
        [SerializeField] private GameEvent playerTookDamage;
        
        public void DamagePlayer(float damage){

            if(damage > 50){
                playerTookDamage.Raise();
            }
        }
    }
}