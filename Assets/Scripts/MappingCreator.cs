using System;
using System.Collections.Generic;
using UnityEngine;

public enum Action {
    Null, MoveUp, MoveDown, MoveLeft, MoveRight, Reset, Remap
}

public class MappingCreator : MonoBehaviour
{
    public Dictionary<KeyCode, Tuple<Action, bool>> mapping;
    private Dictionary<KeyCode, Tuple<Action, bool>> mappingCopy;


    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        mapping = new Dictionary<KeyCode, Tuple<Action, bool>>();
        AddAction(KeyCode.UpArrow, Action.MoveUp);
        AddAction(KeyCode.DownArrow, Action.MoveDown);
        AddAction(KeyCode.RightArrow, Action.MoveRight);
        AddAction(KeyCode.LeftArrow, Action.MoveLeft);
        AddAction(KeyCode.R, Action.Reset);
        AddAction(KeyCode.Space, Action.Remap);
    }

    public void Save()
    {
        mappingCopy = new Dictionary<KeyCode, Tuple<Action, bool>>();
        foreach (var entry in mapping)
        {
            mappingCopy.Add(entry.Key, entry.Value);
        }
    }

    public void Copy()
    {
        mapping = new Dictionary<KeyCode, Tuple<Action, bool>>();
        foreach (var entry in mappingCopy)
        {
            mapping.Add(entry.Key, entry.Value);
        }
    }

    public bool AddAction(KeyCode key, Action action)
    {
        if (mapping.ContainsKey(key)) return false;
        mapping[key] = Tuple.Create(action, true);
        return true;

    }

    public void RemoveKey(KeyCode key)
    {
        if(mapping.ContainsKey(key))
        {
            mapping.Remove(key);
        }
    }

    public void ConsumeKey(KeyCode key)
    {
        if(mapping.ContainsKey(key))
        {
            mapping[key] = Tuple.Create(mapping[key].Item1, false);
        }
    }

    public bool KeyIsUsable(KeyCode key)
    {
        return mapping[key].Item2;
    }

    public Action KeyAction(KeyCode key)
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
        foreach(KeyValuePair<KeyCode, Tuple<Action, bool>> entry in mapping)
        {
            if(entry.Value.Item2)
            {
                //entry.Value.Item1.AddBinding(entry.Key);
            }
        }
    }
}
