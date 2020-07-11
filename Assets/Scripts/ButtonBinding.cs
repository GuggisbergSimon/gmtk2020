using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonBinding : MonoBehaviour
{
    // UI elements
    private Button button;
    private Text text;

    // Action that will be binded
    public InputActionReference actionReference;

    // Action to rebind
    private InputAction actionToBind;

    // Rebinding
    private InputActionRebindingExtensions.RebindingOperation rebindOperation;

    private void Start()
    {
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<Text>();

        // Action
        this.actionToBind = actionReference.action;

        // Process
        // this.button.onClick.AddListener();  // TODO
    }

    private void AddNewKeyToAction(InputBinding binding)
    {
        actionToBind.AddBinding(binding);
    }





    private void ButtonRebindPressed(string name)
    {
        // DO NOT CLICK ANYMORE.
        button.enabled = false;

        text.text = "Press button/stick for " + name;

        // First, discard any remaining rebinding operation, before selecting the new one.
        rebindOperation?.Dispose();
        rebindOperation = actionToBind.PerformInteractiveRebinding()
            // To avoid accidental input from mouse motion
            .WithControlsExcluding("<Mouse>/position")
            .WithControlsExcluding("<Mouse>/delta")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => ButtonRebindCompleted());
    }

    private void ButtonRebindCompleted()
    {
        // Discard everything so the player can bind again.
        rebindOperation.Dispose();
        rebindOperation = null;

        // You can use the button again.
        button.enabled = true;
    }

    private void OnDestroy()
    {
        
    }
}
