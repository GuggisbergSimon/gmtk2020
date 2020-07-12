using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
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
    private Coroutine _resetCoroutine;

    public bool CanMove
    {
        get => _canMove;
        set => _canMove = value;
    }

    private LevelManager _levelManager;
    private Animator _animator;
    private AudioSource _sourceRobot;
    private AudioSource _sourceItem;
    private PauseMenu _pauseMenu;
    private WinPanel _winPanel;

    private void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
        _animator = GetComponent<Animator>();
        _pauseMenu = FindObjectOfType<PauseMenu>();
        _winPanel = FindObjectOfType<WinPanel>();
        //audiosource setup
        _sourceRobot = gameObject.AddComponent<AudioSource>();
        _sourceRobot.playOnAwake = false;
        _sourceRobot.loop = false;
        _sourceRobot.outputAudioMixerGroup = soundGroup;
        _sourceItem = gameObject.AddComponent<AudioSource>();
        _sourceItem.playOnAwake = false;
        _sourceItem.loop = false;
        _sourceItem.outputAudioMixerGroup = soundGroup;
    }

    private void Update()
    {
        if (!_canMove || !Input.anyKeyDown) return;
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (!Input.GetKeyDown(vKey) || !GameManager.Instance.MappingCreator.mapping.ContainsKey(vKey)) continue;
            Action currentAction = GameManager.Instance.MappingCreator.mapping[vKey].Item1;
            if (GameManager.Instance.MappingCreator.mapping[vKey].Item1 == Action.Null) continue;
            if (currentAction.ToString().StartsWith("Move"))
            {
                Move(currentAction, vKey);
            }
            else if (currentAction == Action.Remap)
            {
                Remap();
                GameManager.Instance.MappingCreator.ConsumeKey(vKey);
            }
            else if (currentAction == Action.Reset)
            {
                if (_resetCoroutine != null)
                {
                    StopCoroutine(_resetCoroutine);
                }

                _resetCoroutine = StartCoroutine(Resetting(vKey));
            }
        }
    }

    private void Move(Action action, KeyCode key)
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

    private IEnumerator Resetting(KeyCode key)
    {
        for (float i = 0f; i < hardResetThreshold; i+=Time.deltaTime)
        {
            if (!Input.GetKey(key) || Input.GetKeyUp(key))
            {
                //softreset
                GameManager.Instance.MappingCreator.Copy();
                GameManager.Instance.LoadLevel();
                yield break;
            }

            yield return null;
        }
        //hardreset
        GameManager.Instance.MappingCreator.Setup();
        GameManager.Instance.LoadLevel("MainMenu");
    }

    private void Remap()
    {
        // Call the remap menu
        _pauseMenu.ToggleRemap(true);
    }

    IEnumerator Moving(Action action, KeyCode key)
    {
        Vector2 input = new Vector2(action == Action.MoveRight ? 1 : action == Action.MoveLeft ? -1 : 0,
            action == Action.MoveUp ? 1 : action == Action.MoveDown ? -1 : 0);

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
        transform.position = nextPos;
        if (spriteBoxObj.gameObject.activeSelf)
        {
            _levelManager.Map.SetTile(Vector3Int.FloorToInt(nextPos + move), nextTile);
            spriteBoxObj.gameObject.SetActive(false);
            if (_levelManager.CheckFlags())
            {
                Debug.Log("omedetou");
                // TODO
                _pauseMenu.ToggleWin(true);
            }
        }

        _canMove = true;
    }
}