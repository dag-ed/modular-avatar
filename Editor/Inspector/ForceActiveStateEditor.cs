using UnityEditor;
using UnityEngine;
using static nadena.dev.modular_avatar.core.editor.Localization;

namespace nadena.dev.modular_avatar.core.editor
{
    [CustomEditor(typeof(ModularAvatarForceActiveState))]
    [CanEditMultipleObjects]
    internal class ForceActiveStateEditor : MAEditorBase
    {
        private SerializedProperty _active;

        private void OnEnable()
        {
            _active = serializedObject.FindProperty(nameof(ModularAvatarForceActiveState.m_active));
        }

        protected override void OnInnerInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.HelpBox(S("force_active_state.help"), MessageType.Info);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_active, G("force_active_state.active"));
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            ShowLanguageUI();
        }
    }
}
