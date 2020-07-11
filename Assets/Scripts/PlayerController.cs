using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float coolDownMove = 0.5f;
    private bool _canMove = true;
    private LevelManager _levelManager;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
    }

    private void Update()
    {
        //todo check remaining controls
        if (_canMove && (Mathf.Abs(Input.GetAxis("Vertical")) > 0f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0f))
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        Vector3 move =
            Vector3.right * (Input.GetAxisRaw("Horizontal") * _levelManager.Map.cellSize.x) +
            Vector3.up * (Input.GetAxisRaw("Vertical") * _levelManager.Map.cellSize.y);
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            transform.right = Vector3.right * Input.GetAxisRaw("Horizontal");
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
        transform.position += move;
        yield return new WaitForSeconds(coolDownMove);
        _canMove = true;
    }
}