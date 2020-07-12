using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBindingSub : MonoBehaviour
{
    // UI elements
    private Button button;
    public TextMeshProUGUI text;
    private string defaultText;

    // Rebind de tes morts
    public Action actionToBind;

    // State
    public KeyCode key;

    private void Start()
    {
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<TextMeshProUGUI>();

        this.defaultText = this.text.text;

        button.onClick.AddListener(delegate
        {
            DoAction();
        });
        enabled = false;
    }

    private void DoAction()
    {
        if (this.key != KeyCode.Escape)
        {
            RemoveKey(this.key);
        }
        else
        {
            AssignKey(this.name);
        }
    }

    private void RemoveKey(KeyCode key)
    {
        GameManager.Instance.MappingCreator.RemoveKey(key);
        Destroy(this.gameObject);
    }

    private void AssignKey(string name)
    {
        button.enabled = false;
        enabled = true;
        text.text = "Press button/stick for " + name;
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (!Input.GetKeyDown(vKey) || Input.GetKeyDown(KeyCode.Escape)) continue;
            key = vKey;
            enabled = false;
            Complete();
        }
    }

    private void Complete()
    {
        GameManager.Instance.MappingCreator.AddAction(key, actionToBind);
        Debug.Log(key);
        text.text = key.ToString();

        button.enabled = true;

        this.GetComponentInParent<PanelManager>().AddButton("Add new key", actionToBind, KeyCode.Escape);
    }
}
