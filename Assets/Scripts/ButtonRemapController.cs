using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonRemapController : MonoBehaviour
{
    public Button ok;
    public InputActionAsset inputs;
    private InputActionMap actions;

    private void Start()
    {
        // First we are registering the "Actions" map and disabling it.
        // We don't want no trouble while remaping.
        actions = inputs.FindActionMap("Actions");
        actions.Disable();

        // Lil' okay button.
        ok.onClick.AddListener(ConfirmRemap);
    }

    private void ConfirmRemap()
    {
        // Enable control again.
        actions.Enable();

        // Something something get back in the game.
        // SceneManager.LoadScene("Level");
        // or
        // Unpause();
    }
}
