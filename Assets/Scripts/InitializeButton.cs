using UnityEngine;
using UnityEngine.EventSystems;

public class InitializeButton : MonoBehaviour
{
    private GameObject _lastSelect;

    private void Start()
    {
        _lastSelect = new GameObject();
    }

    private void Update()
    {
        if (!EventSystem.current.currentSelectedGameObject)
        {
            EventSystem.current.SetSelectedGameObject(_lastSelect);
        }
        else
        {
            _lastSelect = EventSystem.current.currentSelectedGameObject;
        }
    }
}