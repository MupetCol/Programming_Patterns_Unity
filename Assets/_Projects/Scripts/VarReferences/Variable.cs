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

    [CreateAssetMenu(menuName = "Variables/Float", fileName = "FloatVar")]
    public class FloatVariable:Variable<float>{

    }

    [CreateAssetMenu(menuName = "Variables/Bool", fileName = "BoolVar")]
    public class BoolVariable:Variable<bool>{

    }

    [System.Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public float Value{
            get{return UseConstant? ConstantValue:
            Variable.Value;}
        }
    }
}
