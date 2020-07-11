using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MappingCreator : MonoBehaviour
{
    InputMaster controls;
    // Map: KeyControl -> (InputAction, bool usable), ...)
    public Dictionary<KeyControl, Tuple<InputAction, bool>> mapping;

    private void Start()
    {
        this.mapping = new Dictionary<KeyControl, Tuple<InputAction, bool>>();
    }

    public bool AddAction(KeyControl key, InputAction action)
    {
        if(mapping[key] != null)
        {
            mapping[key] = Tuple.Create(action, true);
            return true;
        }

        return false;
    }

    public void ResetKey(KeyControl key)
    {
        mapping[key] = null;
    }

    public void ConsumeKey(KeyControl key)
    {
        mapping[key] = Tuple.Create(mapping[key].Item1, false);
    }

    public bool KeyIsUsable(KeyControl key)
    {
        return mapping[key].Item2;
    }

    public InputAction KeyAction(KeyControl key)
    {
        return mapping[key].Item1;
    }

    public void RemoveAllBinding()
    {
        // TODO if needed
    }

    public void ApplyInputBinding()
    {
        foreach(KeyValuePair<KeyControl, Tuple<InputAction, bool>> entry in mapping)
        {
            if(entry.Value.Item2)
            {
                entry.Value.Item1.AddBinding(entry.Key);
            }
        }
    }
}
