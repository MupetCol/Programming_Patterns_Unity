using UnityEngine;

namespace GPP
{
    [CreateAssetMenu(menuName = "Variables/TradeData", fileName = "Trade")]
    public class TradeVariable : Variable<TradeData> { }

    [System.Serializable]
    public class TradeReference : VariableReference<TradeData> { }
}