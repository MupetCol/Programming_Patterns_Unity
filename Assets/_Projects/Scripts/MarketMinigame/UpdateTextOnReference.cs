using UnityEngine;
using TMPro;

namespace GPP
{
    [RequireComponent(typeof(TMP_Text))]
    [ExecuteInEditMode]
    public class UpdateTextOnReference : MonoBehaviour
    {
        [SerializeField] private FloatReference playerCoins;
        [SerializeField] private TMP_Text coinsText;

        private float currCoins = 0f;

        private void Update()
        {
            if(playerCoins.Value != currCoins)
            {
                currCoins = playerCoins.Value;
                coinsText.text = currCoins.ToString();
            }
        }
    }
}