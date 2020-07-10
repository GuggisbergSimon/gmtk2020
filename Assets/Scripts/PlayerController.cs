using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float coolDownMove = 0.5f;
    public bool canMove = true;
    
    private void Update()
    {
        if (canMove && (Mathf.Abs(Input.GetAxis("Vertical")) > 0f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0f))
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        canMove = false;
        transform.position += Vector3.right * (Input.GetAxisRaw("Horizontal") * GameManager.Instance.Grid.cellSize.x) + Vector3.up * (Input.GetAxisRaw("Vertical") * GameManager.Instance.Grid.cellSize.y);
        yield return new WaitForSeconds(coolDownMove);
        canMove = true;
    }
}
