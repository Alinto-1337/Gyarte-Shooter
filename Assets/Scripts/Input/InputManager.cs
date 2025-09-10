using System;
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace GyarteShooter.Input
{
    internal class InputManager : SingletonBehaviour<InputManager>
    {
        [SerializeField] public InputContextConfig inputContextConfig;
        [SerializeField] InputContext initialContext = InputContext.Menu;
        public InputContext currentInputState = InputContext.None;
        public ProjectWideInputActions inputActions;

        private new void Awake()
        {
            if (inputContextConfig == null || inputContextConfig.inputActions == null)
            {
                Debug.LogError("InputContextConfig or its InputActionAsset is not assigned in InputManager.");
                gameObject.SetActive(false);
                return;
            }
            inputActions = new ProjectWideInputActions();

            base.Awake();

            SetInputContext(initialContext);
        }

        public void SetInputContext(InputContext inputContext)
        {
            currentInputState = inputContext;
            UpdateActionMaps();
        }

        public void UpdateActionMaps()
        {

            foreach (var mapContext in inputContextConfig.mapContexts)
            {
                var map = inputActions.asset.FindActionMap(mapContext.mapName);
                if (map == null) continue;

                if (mapContext.context.HasFlag(currentInputState))
                {
                    map.Enable();
                }
                else
                {
                    map.Disable();
                }
            }
        }
    }

    [CustomEditor(typeof(InputManager))]
    public class InputManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Update Action Maps"))
            {
                InputManager gay = (InputManager)target;
                gay.UpdateActionMaps();
            }
        }
    }
}
