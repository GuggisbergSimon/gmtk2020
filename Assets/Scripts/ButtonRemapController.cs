using UnityEngine;
using UnityEngine.UI;

public class ButtonRemapController : MonoBehaviour
{
    public Button ok;

    private void Start()
    {
        // First we are registering the "Actions" map and disabling it.
        // We don't want no trouble while remapping.

        // Lil' okay button.
        ok.onClick.AddListener(ConfirmRemap);
    }

    private void ConfirmRemap()
    {
        // Apply the binding
        //mapping.ApplyInputBinding();

        // Enable control again.

        // Something something get back in the game.
        // SceneManager.LoadScene("Level");
        // or
        // Unpause();
    }
}
