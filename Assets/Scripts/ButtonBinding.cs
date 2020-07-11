using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
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

    // Mapping Creator
    public MappingCreator mapping;
    public GameObject panel;
    public GameObject addKeyPrefab;

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

        // Mapping Creator
        this.mapping = this.GetComponentInParent<MappingCreator>();
    }

    private void AddNewKey(InputAction actionToBind)
    {
        panel.SetActive(true);

        foreach(KeyValuePair<KeyControl, Tuple<InputAction, bool>> entry in mapping.mapping)
        {
            GameObject existingButton = Instantiate(addKeyPrefab, panel.transform);

            existingButton.GetComponentInChildren<Text>().text = entry.Key.displayName;

            existingButton.GetComponent<ButtonBindingSub>().actionToBind = actionToBind;
        }
    }
}
