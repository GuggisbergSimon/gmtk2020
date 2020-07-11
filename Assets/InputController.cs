using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputController : MonoBehaviour
{
    static Dictionary<string, KeyCode> KeyMapping;

    static string[] KeyMaps = new string[]
    {
        "Up",
        "Down",
        "Left",
        "Right",
        "Reset",
        "Map"
    };

    static Controls.KeyControl[] Defaults = new KeyControl[]
    {
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.R,
        KeyCode.Escape
    };

    private void Awake()
    {
        KeyMapping = new Dictionary<string, KeyCode>();

        for(int i = 0; i < KeyMaps.Length; ++i)
        {
            KeyMapping.Add(KeyMaps[i], Defaults[i]);
        }
    }

    void FixedUpdate()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>()

        if(kb.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("aaa");
        }
    }
}
