using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject remapPanel = null;
    [SerializeField] private GameObject winPanel = null;

    public void ToggleRemap(bool toggle)
    {
        GameManager.Instance.Player.CanMove = !toggle;
        remapPanel.SetActive(toggle);
    }

    public void ToggleWin(bool toggle)
    {
        GameManager.Instance.Player.CanMove = !toggle;
        winPanel.SetActive(toggle);
    }
}
