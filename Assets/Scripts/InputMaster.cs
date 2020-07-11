// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""d7002342-42f5-4192-b781-18736cdc848a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9e4ef3dd-c742-4a90-bde6-cb6cbc5c0d71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Input"",
                    ""type"": ""Button"",
                    ""id"": ""7e2f2cc5-8d58-4a1a-a36c-f30f436cca3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""93d66bde-9d35-4068-99ad-30cd63071fef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Remap"",
                    ""type"": ""Button"",
                    ""id"": ""5219ef48-5b8d-4c6b-a8c7-e1cb72b17eba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""e2185457-d3dd-42d3-bf8d-3d2fa365a994"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9dd8ff2e-e772-4fc0-8b83-65f603c5194e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22700245-85b8-4273-923b-3cca70fd3f80"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9af9608d-2b90-4990-b962-530890b7b473"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5bf3c453-1c92-4016-8332-75047db5a617"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2ac64f71-f57a-454f-b515-087ef4b73b74"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57041e35-00ba-4302-b83e-8df844dcf6d8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45f4ef74-dbcd-464d-a388-443390de2fc6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Remap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""b44bb2b0-185d-4982-81bd-5b2430a795af"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""2e7cc204-b4a4-4307-aa7c-fbcc471a652c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fdb1f404-6e56-4dc8-b570-66ca4c02ac6a"",
                    ""path"": ""*/{SecondaryTrigger}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1c75a18-cc0f-474d-98b6-57164aba6533"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Move = m_Actions.FindAction("Move", throwIfNotFound: true);
        m_Actions_Input = m_Actions.FindAction("Input", throwIfNotFound: true);
        m_Actions_Reset = m_Actions.FindAction("Reset", throwIfNotFound: true);
        m_Actions_Remap = m_Actions.FindAction("Remap", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
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

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_Move;
    private readonly InputAction m_Actions_Input;
    private readonly InputAction m_Actions_Reset;
    private readonly InputAction m_Actions_Remap;
    public struct ActionsActions
    {
        private @InputMaster m_Wrapper;
        public ActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Actions_Move;
        public InputAction @Input => m_Wrapper.m_Actions_Input;
        public InputAction @Reset => m_Wrapper.m_Actions_Reset;
        public InputAction @Remap => m_Wrapper.m_Actions_Remap;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMove;
                @Input.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInput;
                @Input.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInput;
                @Input.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnInput;
                @Reset.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Remap.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRemap;
                @Remap.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRemap;
                @Remap.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRemap;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Input.started += instance.OnInput;
                @Input.performed += instance.OnInput;
                @Input.canceled += instance.OnInput;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @Remap.started += instance.OnRemap;
                @Remap.performed += instance.OnRemap;
                @Remap.canceled += instance.OnRemap;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private @InputMaster m_Wrapper;
        public MenuActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInput(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnRemap(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
