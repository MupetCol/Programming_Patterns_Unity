using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPP
{
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
    public class ScriptableObjectClass : ScriptableObject
    {
        public string objectName = "New MyScriptableObject";
        public bool colorIsRandom = false;
        public Color thisColor = Color.white;
        public Vector3[] spawnPoints;
    }
}
