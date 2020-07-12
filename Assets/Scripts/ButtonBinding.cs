using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBinding : MonoBehaviour
{
    // UI elements
    private Button button;
    private TextMeshProUGUI text;

    public enum Inputs
    {
        MoveUp, MoveDown, MoveLeft, MoveRight, Reset, Remap
    }
    
    // Action that will be bound
    public Inputs inputRef;
    public Action action;

    // Action to rebind
    private Action actionToBind;

    public GameObject panel;

    private void Start()
    {
        // Action
        this.actionToBind = action;
        
        // UI
        this.button = this.GetComponent<Button>();
        this.text = this.GetComponentInChildren<TextMeshProUGUI>();
        text.text = action.ToString();
        
        // Process
        this.button.onClick.AddListener(delegate { AddNewKey(actionToBind); } );
    }

    private void AddNewKey(Action actionToBind)
    {
        panel.GetComponent<PanelManager>().actionToBind = actionToBind;
        panel.SetActive(true);
    }
}
