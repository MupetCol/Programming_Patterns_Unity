using UnityEngine;

namespace GPP
{
    [CreateAssetMenu(menuName = "Variables/Bool", fileName = "BoolVar")]
    public class BoolVariable:Variable<bool>{}

    [System.Serializable]
    public class BoolReference : VariableReference<bool>{}
}