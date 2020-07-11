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
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""9e4ef3dd-c742-4a90-bde6-cb6cbc5c0d71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""83d66030-e1e3-4f62-889e-0ffe8b2f417d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""4d5ad3ed-9f1d-48de-90c1-80bd4be36e00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""7585562e-7d07-4dd4-9525-dc56781f2642"",
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
                    ""interactions"": ""Press""
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
                    ""name"": """",
                    ""id"": ""2ac64f71-f57a-454f-b515-087ef4b73b74"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
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
                    ""interactions"": """",
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
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Remap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8361b6c-66e5-4b7d-8479-8dab07629862"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b3e45bd-5837-49a2-93de-69ce2446a98c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f84e1993-7c8e-4136-be06-267739b5d71f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""203d7fbe-e238-4fc6-8562-119fbc36e8a7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveLeft"",
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
        m_Actions_MoveUp = m_Actions.FindAction("MoveUp", throwIfNotFound: true);
        m_Actions_MoveLeft = m_Actions.FindAction("MoveLeft", throwIfNotFound: true);
        m_Actions_MoveDown = m_Actions.FindAction("MoveDown", throwIfNotFound: true);
        m_Actions_MoveRight = m_Actions.FindAction("MoveRight", throwIfNotFound: true);
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
    private readonly InputAction m_Actions_MoveUp;
    private readonly InputAction m_Actions_MoveLeft;
    private readonly InputAction m_Actions_MoveDown;
    private readonly InputAction m_Actions_MoveRight;
    private readonly InputAction m_Actions_Input;
    private readonly InputAction m_Actions_Reset;
    private readonly InputAction m_Actions_Remap;
    public struct ActionsActions
    {
        private @InputMaster m_Wrapper;
        public ActionsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_Actions_MoveUp;
        public InputAction @MoveLeft => m_Wrapper.m_Actions_MoveLeft;
        public InputAction @MoveDown => m_Wrapper.m_Actions_MoveDown;
        public InputAction @MoveRight => m_Wrapper.m_Actions_MoveRight;
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
                @MoveUp.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveUp;
                @MoveLeft.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveLeft;
                @MoveDown.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveDown;
                @MoveRight.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMoveRight;
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
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
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
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnInput(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnRemap(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
