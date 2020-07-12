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
    public Dictionary<InputControl, Tuple<InputAction, bool>> mapping;

    private void Start()
    {
        this.mapping = new Dictionary<InputControl, Tuple<InputAction, bool>>();
    }

    public bool AddAction(InputControl key, InputAction action)
    {
        if (!mapping.ContainsKey(key))
        {
            mapping[key] = Tuple.Create(action, true);
            return true;
        }

        return false;
    }

    public void RemoveKey(InputControl key)
    {
        if(mapping.ContainsKey(key))
        {
            mapping.Remove(key);
        }
    }

    public void ConsumeKey(InputControl key)
    {
        if(mapping.ContainsKey(key))
        {
            mapping[key] = Tuple.Create(mapping[key].Item1, false);
        }
    }

    public bool KeyIsUsable(InputControl key)
    {
        return mapping[key].Item2;
    }

    public InputAction KeyAction(InputControl key)
    {
        return mapping[key].Item1;
    }

    public void RemoveAllBinding()
    {
        // TODO if needed
    }

    // Do not use
    public void ApplyInputBinding()
    {
        foreach(KeyValuePair<InputControl, Tuple<InputAction, bool>> entry in mapping)
        {
            if(entry.Value.Item2)
            {
                entry.Value.Item1.AddBinding(entry.Key);
            }
        }
    }
}
