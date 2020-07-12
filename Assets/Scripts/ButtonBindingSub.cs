using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ButtonBindingSub : MonoBehaviour
{
    // UI elements
    private Button button;
    public Text text;
    private string defaultText;

    // Rebind de tes morts
    public InputAction actionToBind;
    public InputAction action;
    private InputActionRebindingExtensions.RebindingOperation m_RebindOperation;

    // State
    public InputControl key;

    // Mapping
    private MappingCreator mapping;

    private void Start()
    {
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<Text>();

        this.defaultText = this.text.text;

        this.mapping = GameManager.Instance.MappingCreator;  // Oui bon

        button.onClick.AddListener(delegate
        {
            DoAction();
        });
    }

    private void DoAction()
    {
        if (this.key != null)
        {
            RemoveKey(this.key);
        }
        else
        {
            AssignKey(this.name);
        }
    }

    private void RemoveKey(InputControl key)
    {
        mapping.RemoveKey(key);
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
        key = m_RebindOperation.selectedControl;

        mapping.AddAction(key, actionToBind);

        //RIP decent programming practices
        //actionToBind.AddBinding(key);
        action.AddBinding(key);

        text.text = m_RebindOperation.selectedControl.displayName;

        button.enabled = true;

        m_RebindOperation.Dispose();
        m_RebindOperation = null;

        this.GetComponentInParent<PanelManager>().AddButton("Add new key", actionToBind, action, null);
    }
}
