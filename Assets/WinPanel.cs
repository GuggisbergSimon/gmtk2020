using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
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
        string[] scenename = scene.name.Split('_');
        GameManager.Instance.LoadLevel(scenename[0] + '_' + (int.Parse(scenename[1]) + 1));
    }
}
