using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonBindingSub : MonoBehaviour
{
    // UI elements
    private Button button;
    public Text text;
    private Text defaultText;

    // Rebind de tes morts
    public InputAction actionToBind;
    private InputActionRebindingExtensions.RebindingOperation m_RebindOperation;

    private void Start()
    {
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<Text>();

        if(!text.Equals("Add new key!"))
        {
            button.onClick.AddListener(delegate { RemoveKey(name); });
        } else
        {
            button.onClick.AddListener(delegate { AssignKey(name); });
        }

        this.defaultText.text = this.text.text;
    }

    private void RemoveKey(string name)
    {
        Destroy(this.gameObject);
    }

    private void AssignKey(string name)
    {
        this.GetComponent<Button>().enabled = false;

        this.GetComponentInChildren<Text>().text = "Press button/stick for " + name;

        m_RebindOperation?.Dispose();
        //m_RebindOperation = actionToBind.PerformInteractiveRebinding()
          //  .WithControlsExcluding("<Mouse>/position")
            //.WithControlsExcluding("<Mouse>/delta")
            //.OnMatchWaitForAnother(0.1f)
           // .OnComplete(operation => Complete());
        m_RebindOperation.Cancel();
    }

    private void Complete()
    {
        
        this.GetComponentInChildren<Text>().text = "Add new key!";
    }
}
