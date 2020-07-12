using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelManager _levelManager;
    private MappingCreator _mappingCreator;
    private InputMaster _controls;
    public LevelManager LevelManager => _levelManager;

    public MappingCreator MappingCreator => _mappingCreator;

    public InputMaster Controls => _controls;

    public static GameManager Instance { get; private set; }

    private void OnEnable()
    {
        _controls.Enable();
        SceneManager.sceneLoaded += OnLevelFinishedLoadingScene;
    }

    private void OnDisable()
    {
        _controls.Disable();
        SceneManager.sceneLoaded -= OnLevelFinishedLoadingScene;
    }

    //this function is activated every time a scene is loaded
    private void OnLevelFinishedLoadingScene(Scene scene, LoadSceneMode mode)
    {
        Setup();
    }

    private void Setup()
    {
        //alternative way to get elements. cons : if there is no element with such tag it creates an error
        _levelManager = FindObjectOfType<LevelManager>();
        _mappingCreator = FindObjectOfType<MappingCreator>();
        //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //_player = FindObjectOfType<PlayerController>();
        //_uiManager = FindObjectOfType<UIManager>();
    }

    private void Awake()
    {
        _controls = new InputMaster();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _controls = new InputMaster();
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Setup();
    }

    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}