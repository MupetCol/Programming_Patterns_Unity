using UnityEngine;

namespace GPP
{
    public class InfoPanelSetter : MonoBehaviour
    {     
        private void Awake()
        {

        }
    }

    [System.Serializable]
    public class InfoBoxData
    {
        [SerializeField] private Sprite _shopItemSprite;
        [SerializeField] private Sprite _tradeItemSprite;
        [SerializeField] private float _tradeItemValue;
    }
}