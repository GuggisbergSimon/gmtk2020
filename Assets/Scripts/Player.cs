using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    InputMaster controls;
    public double hardResetThreshold;

    // Enable and disable when waked up.
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Awake()
    {
        // We have to add our controls as a new set of controls.
        controls = new InputMaster();

        // For each control, register an event/a function to do when the action is performed.
        controls.Actions.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Actions.Reset.canceled += ctx => Reset(ctx.duration);
        controls.Actions.Remap.performed += ctx => Remap();
    }

    private void Move(Vector2 context)
    {
        Debug.Log("We are moving! " + context);
    }

    private void Reset(double duration)
    {
        Debug.Log("Reset: " + duration);

        if(duration > hardResetThreshold)
        {
            Debug.Log("HARD RESET !!!");
        } else
        {
            Debug.Log("Soft reset");
        }
    }

    private void Remap()
    {
        Debug.Log("Remap");
    }

}
