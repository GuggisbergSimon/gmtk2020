using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public InputAction actionToBind;
    public InputAction action;

    // Mapping Creator
    public MappingCreator mapping;

    // Prefab
    public GameObject addKeyPrefab;

    private List<GameObject> buttons;

    private void OnEnable()
    {
        buttons = new List<GameObject>();

        foreach (KeyValuePair<InputControl, Tuple<InputAction, bool>> entry in mapping.mapping)
        {
            if(entry.Value.Item1.Equals(actionToBind))
            {
                AddButton(entry.Key.displayName, actionToBind, action, entry.Key);
            }
        }

        AddButton("Add new key", actionToBind, action, null);
    }

    public void AddButton(string text, InputAction actionToBind, InputAction action, InputControl key)
    {
        GameObject existingButton = Instantiate(addKeyPrefab, this.transform);

        existingButton.GetComponentInChildren<Text>().text = text;
        existingButton.GetComponent<ButtonBindingSub>().actionToBind = actionToBind;
        existingButton.GetComponent<ButtonBindingSub>().action = action;
        existingButton.GetComponent<ButtonBindingSub>().key = key;

        buttons.Add(existingButton);
    }

    private void OnDisable()
    {
        foreach (GameObject butt in buttons)
        {
            Destroy(butt);
        }
    }
}
