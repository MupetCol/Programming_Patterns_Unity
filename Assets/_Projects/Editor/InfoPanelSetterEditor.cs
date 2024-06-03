using UnityEditor;
using UnityEngine;

namespace GPP
{
    [CustomEditor(typeof(InfoPanelSetter))]
    public class InfoPanelSetterEditor : Editor
    {     
        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();

            InfoPanelSetter infoPanelSetter = (InfoPanelSetter)target;

            if(GUILayout.Button("Generate Info Boxes"))
            {
                infoPanelSetter.GenInfoBoxesOnEditor();
            }
        }
    }
}