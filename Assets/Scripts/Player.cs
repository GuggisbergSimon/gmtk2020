using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Transform spritePlayer = null;
    [SerializeField] private SpriteRenderer spriteBoxObj = null;
    [SerializeField] private Sprite[] spritesBox = null;
    [SerializeField] private float hardResetThreshold = 1f;
    private bool _canMove = true;
    private LevelManager _levelManager;
    private Animator _animator;

    private void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
        _animator = GetComponent<Animator>();
    }

    InputMaster controls;

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
        controls.Actions.MoveUp.performed += ctx => Move(ctx.action);
        controls.Actions.MoveDown.performed += ctx => Move(ctx.action);
        controls.Actions.MoveLeft.performed += ctx => Move(ctx.action);
        controls.Actions.MoveRight.performed += ctx => Move(ctx.action);
        controls.Actions.Reset.canceled += ctx => Reset(ctx.duration);
        controls.Actions.Remap.performed += ctx => Remap();
    }

    private void Move(InputAction action)
    {
        //todo check remaining controls and decrease them
        //Debug.Log("We are moving! " + action.name);
        if (_canMove)
        {
            StartCoroutine(Moving(action));
        }
    }

    private void Reset(double duration)
    {
        Debug.Log("Reset: " + duration);

        if (duration > hardResetThreshold)
        {
            Debug.Log("HARD RESET !!!");
        }
        else
        {
            Debug.Log("Soft reset");
        }
    }

    private void Remap()
    {
        Debug.Log("Remap");

        // Call the remap menu
    }

    IEnumerator Moving(InputAction action)
    {
        Vector2 input = new Vector2(action.name.Equals("MoveRight") ? 1 : action.name.Equals("MoveLeft") ? -1 : 0,
            action.name.Equals("MoveUp") ? 1 : action.name.Equals("MoveDown") ? -1 : 0);

        Vector3 move =
            Vector3.right * (input.x * _levelManager.Map.cellSize.x) +
            Vector3.up * (input.y * _levelManager.Map.cellSize.y);

        //Handles animation triggers
        _animator.ResetTrigger("Up");
        _animator.ResetTrigger("Down");
        _animator.ResetTrigger("LR");

        if (Mathf.Abs(input.x) > 0)
        {
            _animator.SetTrigger("LR");
            spritePlayer.right = Vector3.right * input.x;
        }
        else if (input.y < 0)
        {
            _animator.SetTrigger("Down");
        }
        else if (input.y > 0)
        {
            _animator.SetTrigger("Up");
        }

        Vector3 nextPos = transform.position + move;
        TileBase nextTile = _levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos));

        if (_levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos)) != null)
        {
            string nextPosName = _levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos)).name;
            if (nextPosName.StartsWith("wall"))
            {
                yield break;
            }

            if (nextPosName.StartsWith("box"))
            {
                //the player can only push if no wall or box behind the box
                if (_levelManager.Map.HasTile(Vector3Int.FloorToInt(nextPos + move)))
                {
                    yield break;
                }

                //pushes the box
                _levelManager.Map.SetTile(Vector3Int.FloorToInt(nextPos), null);
                // because the name file format is "box trash 0"
                spriteBoxObj.sprite = spritesBox[Convert.ToInt32(nextPosName.Split(' ')[2])];
                spriteBoxObj.transform.localPosition = move;
                spriteBoxObj.gameObject.SetActive(true);
            }
        }

        _canMove = false;
        Vector3 pos = transform.position;
        float t = Time.deltaTime * moveSpeed;
        for (; t < 1f; t += Time.deltaTime * moveSpeed)
        {
            transform.position = pos + Vector3.Lerp(Vector3.zero, move, t);
            yield return null;
        }

        transform.position = nextPos;
        if (spriteBoxObj.gameObject.activeSelf)
        {
            _levelManager.Map.SetTile(Vector3Int.FloorToInt(nextPos + move), nextTile);
            spriteBoxObj.gameObject.SetActive(false);
            if (_levelManager.CheckFlags())
            {
                Debug.Log("omedetou");
                //todo win
            }
        }

        _canMove = true;
    }
}