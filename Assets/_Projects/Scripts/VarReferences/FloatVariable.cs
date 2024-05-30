using UnityEngine;

namespace GPP
{
    [CreateAssetMenu(menuName = "Variables/Float", fileName = "FloatVar")]
    public class FloatVariable:Variable<float>{}

    [System.Serializable]
    public class FloatReference : VariableReference<float>{}
}