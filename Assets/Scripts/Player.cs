using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Interactions;

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
        controls.Actions.MoveUp.performed += ctx => Move(ctx.control);
        controls.Actions.MoveDown.performed += ctx => Move(ctx.control);
        controls.Actions.MoveLeft.performed += ctx => Move(ctx.control);
        controls.Actions.MoveRight.performed += ctx => Move(ctx.control);
        controls.Actions.Reset.canceled += ctx => Reset(ctx.duration);
        controls.Actions.Remap.performed += ctx => Remap();
    }

    private void Move(InputControl key)
    {
        Debug.Log("We are moving! " + key);
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

        // Call the remap menu
    }
}
