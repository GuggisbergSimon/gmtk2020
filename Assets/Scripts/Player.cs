using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Transform spritePlayer = null;
    [SerializeField] private SpriteRenderer spriteBoxObj = null;
    [SerializeField] private Sprite[] spritesBox = null;
    [SerializeField] private float hardResetThreshold = 1f;
    [SerializeField] private AudioMixerGroup soundGroup = null;
    [SerializeField] private AudioClip[] buttonUsed = null;
    [SerializeField] private AudioClip[] wallHit = null;
    [SerializeField] private AudioClip[] scrubFloor = null;
    [SerializeField] private AudioClip[] moveRobot = null;
    [SerializeField] private AudioClip[] moveMetal = null;
    [SerializeField] private AudioClip[] moveTrash = null;
    [SerializeField] private AudioClip[] robotNoise = null;
    private bool _canMove = true;
    private LevelManager _levelManager;
    private Animator _animator;
    private AudioSource _sourceRobot;
    private AudioSource _sourceItem;

    private void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
        _animator = GetComponent<Animator>();
        _sourceRobot = gameObject.AddComponent<AudioSource>();
        _sourceRobot.playOnAwake = false;
        _sourceRobot.loop = false;
        _sourceRobot.outputAudioMixerGroup = soundGroup;
        _sourceItem = gameObject.AddComponent<AudioSource>();
        _sourceItem.playOnAwake = false;
        _sourceItem.loop = false;
        _sourceItem.outputAudioMixerGroup = soundGroup;
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
        controls.Actions.MoveUp.performed += ctx => Move(ctx.action, ctx.control);
        controls.Actions.MoveDown.performed += ctx => Move(ctx.action, ctx.control);
        controls.Actions.MoveLeft.performed += ctx => Move(ctx.action, ctx.control);
        controls.Actions.MoveRight.performed += ctx => Move(ctx.action, ctx.control);
        controls.Actions.Reset.canceled += ctx => PlayerReset((float) ctx.duration);
        controls.Actions.Remap.performed += ctx => Remap();
    }

    private void Move(InputAction action, InputControl key)
    {
        //todo properly AddAction in MappingCreator in order to have
        if (_canMove)
        {
            if (GameManager.Instance.MappingCreator.KeyIsUsable(key))
            {
                StartCoroutine(Moving(action, key));
            }
            else
            {
                _sourceRobot.PlayOneShot(buttonUsed[Random.Range(0, buttonUsed.Length)]);
            }
        }
    }

    private void PlayerReset(float duration)
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

    IEnumerator Moving(InputAction action, InputControl key)
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
                _sourceRobot.PlayOneShot(robotNoise[Random.Range(0, robotNoise.Length)]);
                _sourceItem.PlayOneShot(wallHit[Random.Range(0, wallHit.Length)]);
                yield break;
            }

            if (nextPosName.StartsWith("box"))
            {
                //the player can only push if no wall or box behind the box
                if (_levelManager.Map.HasTile(Vector3Int.FloorToInt(nextPos + move)))
                {
                    _sourceRobot.PlayOneShot(robotNoise[Random.Range(0, robotNoise.Length)]);
                    _sourceItem.PlayOneShot(wallHit[Random.Range(0, wallHit.Length)]);
                    yield break;
                }

                //pushes the box
                _levelManager.Map.SetTile(Vector3Int.FloorToInt(nextPos), null);
                // because the name file format is "box trash 0" hence .Split(' ')[2] to access to the number
                spriteBoxObj.sprite = spritesBox[Convert.ToInt32(nextPosName.Split(' ')[2])];
                if (Convert.ToInt32(nextPosName.Split(' ')[2]) == 1)
                {
                    _sourceItem.PlayOneShot(moveMetal[Random.Range(0, moveMetal.Length)]);
                }
                else
                {
                    _sourceItem.PlayOneShot(moveTrash[Random.Range(0, moveTrash.Length)]);
                }
                spriteBoxObj.transform.localPosition = move;
                spriteBoxObj.gameObject.SetActive(true);
            }
        }
        else
        {
            _sourceItem.PlayOneShot(scrubFloor[Random.Range(0, scrubFloor.Length)]);
        }
        _sourceRobot.PlayOneShot(moveRobot[Random.Range(0, moveRobot.Length)]);

        _canMove = false;
        Vector3 pos = transform.position;
        float t = Time.deltaTime * moveSpeed;
        for (; t < 1f; t += Time.deltaTime * moveSpeed)
        {
            transform.position = pos + Vector3.Lerp(Vector3.zero, move, t);
            yield return null;
        }
        
        GameManager.Instance.MappingCreator.ConsumeKey(key);
        GameManager.Instance.MappingCreator.ApplyInputBinding();
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