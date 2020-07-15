using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Rebind de tes morts

    private void Awake()
    {
        // KeyToAction()
    }

    private void KeyToAction(KeyCode key, Action actionToBind)
    {
        GameManager.Instance.MappingCreator.AddAction(key, actionToBind);
    }
}
