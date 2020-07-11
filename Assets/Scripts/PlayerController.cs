using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private bool _canMove = true;
    private LevelManager _levelManager;
    private Animator _animator;

    private void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //todo check remaining controls and decrease them
        //todo rework how input is check/handled
        if (_canMove && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        Vector3 move =
            Vector3.right * (Input.GetAxisRaw("Horizontal") * _levelManager.Map.cellSize.x) +
            Vector3.up * (Input.GetAxisRaw("Vertical") * _levelManager.Map.cellSize.y);
        
        //Handles animation triggers
        _animator.ResetTrigger("Up");
        _animator.ResetTrigger("Down");
        _animator.ResetTrigger("LR");
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _animator.SetTrigger("LR");
            transform.right = Vector3.right * (Input.GetKeyDown(KeyCode.RightArrow) ? 1 : -1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _animator.SetTrigger("Down");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _animator.SetTrigger("Up");
        }
        
        Vector3 nextPos = transform.position + move;

        if (_levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos)) != null)
        {
            if (_levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos)).name.Equals("wall"))
            {
                yield break;
            }

            if (_levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos)).name.Equals("box"))
            {
                //the player can only push if no wall or box behind the box
                if (_levelManager.Map.HasTile(Vector3Int.FloorToInt(nextPos + move)))
                {
                    yield break;
                }

                //pushes the box
                TileBase box = _levelManager.Map.GetTile(Vector3Int.FloorToInt(nextPos));
                _levelManager.Map.SetTile(Vector3Int.FloorToInt(nextPos), null);
                _levelManager.Map.SetTile(Vector3Int.FloorToInt(nextPos + move), box);
                if (_levelManager.CheckFlags())
                {
                    Debug.Log("omedetou");
                    //todo win
                }
            }
        }

        _canMove = false;
        Vector3 pos = transform.position;
        float t = Time.deltaTime * moveSpeed;
        for (; t < 1f; t += Time.deltaTime * moveSpeed) {
            transform.position = pos + Vector3.Lerp(Vector3.zero, move, t);
            yield return null;
        }

        transform.position = nextPos;
        _canMove = true;
    }
}