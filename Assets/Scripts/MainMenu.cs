using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string targetLevel;

    public void StartLevel()
    {
        if(GameManager.Instance.tutorial)
        {
            GameManager.Instance.tutorial = false;
            LoadLevel("tutorial_1");
        } else
        {
            LoadLevel("level_0");
        }
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void LoadLevel(string level)
    {
        GameManager.Instance.LoadLevel(level);
    }
}