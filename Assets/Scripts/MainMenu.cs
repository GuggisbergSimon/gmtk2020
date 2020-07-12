using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void LoadLevel(string level)
    {
        GameManager.Instance.LoadLevel(level);
    }

    public void ValidateMapping()
    {
        GameManager.Instance.ValidateMapping();
    }
}