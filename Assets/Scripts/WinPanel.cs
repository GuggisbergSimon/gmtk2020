using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = this.GetComponentInChildren<Button>();
        button.onClick.AddListener(delegate { ButtonClick(); });
    }

    private void ButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name.Equals("tuto_6"))
        {
            GameManager.Instance.LoadLevel("level_0");
            return;
        }

        if (scene.name.Equals("level_6"))
        {
            GameManager.Instance.LoadLevel("MainMenu");
            return;
        }

        string[] scenename = scene.name.Split('_');
        GameManager.Instance.LoadLevel(scenename[0] + '_' + (int.Parse(scenename[1]) + 1));
    }
}
