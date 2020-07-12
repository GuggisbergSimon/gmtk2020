using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    // Rebind de tes morts
    public InputAction actionToBind;
    public InputAction action;

    private void Awake()
    {
        // KeyToAction()
    }

    private void KeyToAction(KeyCode key, Action actionToBind)
    {
        GameManager.Instance.MappingCreator.AddAction(key, actionToBind);
    }
}
