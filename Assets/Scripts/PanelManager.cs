using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public Action actionToBind;

    // Prefab
    public GameObject addKeyPrefab;

    private List<GameObject> buttons;

    private void OnEnable()
    {
        buttons = new List<GameObject>();
        
        foreach (KeyValuePair<KeyCode, Tuple<Action, bool>> entry in GameManager.Instance.MappingCreator.mapping)
        {
            if(entry.Value.Item1.Equals(actionToBind) && GameManager.Instance.MappingCreator.KeyIsUsable(entry.Key))
            {
                AddButton(entry.Key.ToString(), actionToBind, entry.Key);
            }
        }

        AddButton("Add new key", actionToBind, KeyCode.Escape);
    }

    public void AddButton(string text, Action actionToBind, KeyCode key)
    {
        GameObject existingButton = Instantiate(addKeyPrefab, this.transform);

        existingButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        existingButton.GetComponent<ButtonBindingSub>().actionToBind = actionToBind;
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
