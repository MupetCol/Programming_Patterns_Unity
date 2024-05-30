using UnityEngine;

namespace GPP
{
    //Variables and References, a great tool for abstraction and easy inspector design
    public class Variable<T> : ScriptableObject
    {
        public T Value;

        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
    }

    [System.Serializable]
    public class VariableReference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public Variable<T> Variable;

        public T Value{
            get{return UseConstant? ConstantValue:
            Variable.Value;}
        }
    }
}
