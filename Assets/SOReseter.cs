using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GPP
{
    public class SOReseter : MonoBehaviour
    {
        [SerializeField] List<ScriptableObject> SOs;

        private List<ScriptableObject> SOObjectsBackUp = new List<ScriptableObject>();

        private void Awake()
        {
            SOObjectsBackUp = SOs;
        }

        private void OnDestroy()
        {
            for (int i = 0; i < SOs.Count; i++)
            {
                 SOs[i] = SOObjectsBackUp[i];
            }
        }
    }
}