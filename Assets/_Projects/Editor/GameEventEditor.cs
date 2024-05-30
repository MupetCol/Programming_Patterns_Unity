using UnityEngine;
using UnityEditor;
using TKS;

namespace GPP
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameEvent gameEvent = (GameEvent)target;

            if (GUILayout.Button("Raise"))
            {
                Debug.Log("Raised");
                gameEvent.Raise();
            }
        }
    }
}