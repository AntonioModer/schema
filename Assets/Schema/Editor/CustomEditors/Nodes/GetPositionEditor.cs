using UnityEngine;
using UnityEditor;

namespace SchemaEditor.Editors.Nodes
{
    [CustomEditor(typeof(Schema.Builtin.Nodes.GetPosition)), CanEditMultipleObjects]
    public class GetPositionEditor : Editor
    {
        SerializedProperty useSelf;
        SerializedProperty local;
        SerializedProperty gameObjectKey;
        SerializedProperty positionKey;
        void OnEnable()
        {
            useSelf = serializedObject.FindProperty("useSelf");
            local = serializedObject.FindProperty("local");
            gameObjectKey = serializedObject.FindProperty("gameObject");
            positionKey = serializedObject.FindProperty("positionKey");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(useSelf);
            EditorGUILayout.PropertyField(local);

            if (!useSelf.boolValue)
                EditorGUILayout.PropertyField(gameObjectKey);

            EditorGUILayout.PropertyField(positionKey);

            serializedObject.ApplyModifiedProperties();
        }
    }
}