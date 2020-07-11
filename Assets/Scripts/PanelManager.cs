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

    // Mapping Creator
    public MappingCreator mapping;

    // Prefab
    public GameObject addKeyPrefab;

    private List<GameObject> buttons;

    private void OnEnable()
    {
        buttons = new List<GameObject>();

        foreach (KeyValuePair<KeyControl, Tuple<InputAction, bool>> entry in mapping.mapping)
        {
            AddButton(entry.Key.displayName, actionToBind, true);
        }

        AddButton("Add new key", actionToBind, false);
    }

    public void AddButton(string text, InputAction actionToBind, bool isKey)
    {
        GameObject existingButton = Instantiate(addKeyPrefab, this.transform);

        existingButton.GetComponentInChildren<Text>().text = text;

        existingButton.GetComponent<ButtonBindingSub>().actionToBind = actionToBind;

        existingButton.GetComponent<ButtonBindingSub>().isKey = isKey;

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
