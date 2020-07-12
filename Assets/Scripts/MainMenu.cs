using UnityEngine;

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
        //GameManager.Instance.ValidateMapping();
    }
}