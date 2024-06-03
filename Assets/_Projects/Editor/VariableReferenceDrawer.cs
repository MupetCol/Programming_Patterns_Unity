using UnityEditor;
using UnityEngine;

namespace GPP
{
    [CustomPropertyDrawer(typeof(VariableReference<>),true)]
    public class VariableReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var dropdownRect = new Rect(position.x, position.y, 20, position.height);
            var inputRect = new Rect(position.x + 25, position.y, position.width - 26, position.height);

            // Get bool property
            var useConstantProp = property.FindPropertyRelative("UseConstant");

            // Remove background
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            GUI.contentColor = new Color(0, 0, 0, 0);

            // Draw Icon
            var iconRect = new Rect(position.x, position.y, 20, position.height);
            Texture icon = EditorGUIUtility.Load("icons/d_UnityEditor.SceneHierarchyWindow.png") as Texture2D;
            GUI.DrawTexture(iconRect, icon);

            // Create Popup and find bool value
            int popup = EditorGUI.Popup(dropdownRect, useConstantProp.boolValue ? 0 : 1, new string[] { "Use Constant", "Use Variable" });
            useConstantProp.boolValue = popup == 0 ? true : false;

            // Return colours
            GUI.backgroundColor = Color.white;
            GUI.contentColor = Color.white;

            // Show appropriate input field
            if (useConstantProp.boolValue)
            {
                EditorGUI.PropertyField(inputRect, property.FindPropertyRelative("ConstantValue"), GUIContent.none);
            }
            else
            {
                EditorGUI.PropertyField(inputRect, property.FindPropertyRelative("Variable"), GUIContent.none);
            }
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}