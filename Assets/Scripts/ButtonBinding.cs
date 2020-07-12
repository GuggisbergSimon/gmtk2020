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

    public enum Inputs
    {
        MoveUp, MoveDown, MoveLeft, MoveRight, Reset, Remap
    }
    
    // Action that will be bound
    public Inputs inputRef;
    public InputActionReference actionReference;

    // Action to rebind
    private InputAction actionToBind;
    private InputAction action;

    public GameObject panel;

    private void Start()
    {
        // Action
        this.actionToBind = actionReference.action;
        this.action = GameManager.Instance.Controls.Actions.Get().FindAction(inputRef.ToString());
        
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<Text>();
        text.text = actionReference.name;
        
        // Process
        this.button.onClick.AddListener(delegate { AddNewKey(actionToBind, action); } );
    }

    private void AddNewKey(InputAction actionToBind, InputAction action)
    {
        panel.GetComponent<PanelManager>().actionToBind = actionToBind;
        panel.GetComponent<PanelManager>().action = action;
        panel.SetActive(true);
    }
}
