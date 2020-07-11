using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonBindingSub : MonoBehaviour
{
    // UI elements
    private Button button;
    public Text text;
    private string defaultText;

    // Rebind de tes morts
    public InputAction actionToBind;
    private InputActionRebindingExtensions.RebindingOperation m_RebindOperation;

    // State
    public bool isKey;

    private void Start()
    {
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<Text>();

        if(this.isKey)
        {
            button.onClick.AddListener(delegate { RemoveKey(name); });
        } else
        {
            button.onClick.AddListener(delegate { AssignKey(name); });
        }

        this.defaultText = this.text.text;
    }

    private void RemoveKey(string name)
    {
        Destroy(this.gameObject);
    }

    private void AssignKey(string name)
    {
        button.enabled = false;

        text.text = "Press button/stick for " + name;

        m_RebindOperation?.Dispose();
        m_RebindOperation = actionToBind.PerformInteractiveRebinding()
            .WithRebindAddingNewBinding()
            .WithControlsExcluding("<Mouse>/position")
            .WithControlsExcluding("<Mouse>/delta")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => Complete());
        m_RebindOperation.Start();
    }

    private void Complete()
    {
        actionToBind.AddBinding(m_RebindOperation.selectedControl);
        text.text = m_RebindOperation.selectedControl.displayName;

        isKey = true;
        button.enabled = true;

        m_RebindOperation.Dispose();
        m_RebindOperation = null;
    }
}
