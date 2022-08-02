// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlatformControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlatformControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlatformControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlatformControls"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""1522eabd-c424-4a2d-ab8a-5afb6dbe1832"",
            ""actions"": [
                {
                    ""name"": ""Input"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1fc556b-7b66-45ad-9d32-6f515976e6c2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""56f73173-36bc-4c98-aa80-243861e4477a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""6d8352e3-5e02-4e72-9d13-92923b8a0bab"",
            ""actions"": [
                {
                    ""name"": ""Input"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d409ba71-4ce1-4ee3-8fb0-965447a865df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0edfb86-6322-40c6-b495-2c87358f7e05"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Input = m_Mouse.FindAction("Input", throwIfNotFound: true);
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Input = m_Touch.FindAction("Input", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Input;
    public struct MouseActions
    {
        private @PlatformControls m_Wrapper;
        public MouseActions(@PlatformControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Input => m_Wrapper.m_Mouse_Input;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Input.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnInput;
                @Input.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnInput;
                @Input.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnInput;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Input.started += instance.OnInput;
                @Input.performed += instance.OnInput;
                @Input.canceled += instance.OnInput;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Input;
    public struct TouchActions
    {
        private @PlatformControls m_Wrapper;
        public TouchActions(@PlatformControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Input => m_Wrapper.m_Touch_Input;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Input.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnInput;
                @Input.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnInput;
                @Input.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnInput;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Input.started += instance.OnInput;
                @Input.performed += instance.OnInput;
                @Input.canceled += instance.OnInput;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface IMouseActions
    {
        void OnInput(InputAction.CallbackContext context);
    }
    public interface ITouchActions
    {
        void OnInput(InputAction.CallbackContext context);
    }
}
