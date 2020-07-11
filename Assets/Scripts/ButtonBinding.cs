using System;
using System.Collections.Generic;
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

    public GameObject panel;

    private void Start()
    {
        // Action
        this.actionToBind = actionReference.action;

        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<Text>();
        text.text = actionReference.name;

        // Process
        this.button.onClick.AddListener(delegate { AddNewKey(actionToBind); } );
    }

    private void AddNewKey(InputAction actionToBind)
    {
        panel.GetComponent<PanelManager>().actionToBind = actionToBind;
        panel.GetComponent<PanelManager>().mapping = this.GetComponentInParent<MappingCreator>();
        panel.SetActive(true);
    }
}
