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

    private void KeyToAction(InputControl key, InputAction actionToBind)
    {
        GameManager.Instance.MappingCreator.AddAction(key, actionToBind);

        //RIP decent programming practices
        actionToBind.AddBinding(key);
        //action.AddBinding(key);
    }
}
