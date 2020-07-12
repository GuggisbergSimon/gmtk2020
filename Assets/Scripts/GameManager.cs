using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelManager _levelManager;
    private MappingCreator _mappingCreator;
    private InputMaster _controls;
    private Player _player;
    public LevelManager LevelManager => _levelManager;

    public MappingCreator MappingCreator => _mappingCreator;

    public InputMaster Controls => _controls;

    public Player Player => _player;

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
        _player = FindObjectOfType<Player>();
        //_uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
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

    public void ValidateMapping()
    {
        if (_mappingCreator.mapping.Count == 0)
        {
            /*_mappingCreator.AddAction(InputSystem.GetDevice<Keyboard>().upArrowKey, _controls.Actions.Get().FindAction("MoveUp"));
            _mappingCreator.AddAction(InputSystem.GetDevice<Keyboard>().leftArrowKey, _controls.Actions.Get().FindAction("MoveLeft"));
            _mappingCreator.AddAction(InputSystem.GetDevice<Keyboard>().downArrowKey, _controls.Actions.Get().FindAction("MoveDown"));
            _mappingCreator.AddAction(InputSystem.GetDevice<Keyboard>().rightArrowKey, _controls.Actions.Get().FindAction("MoveRight"));
            _mappingCreator.AddAction(InputSystem.GetDevice<Keyboard>().rKey, _controls.Actions.Get().FindAction("Reset"));
            _mappingCreator.AddAction(InputSystem.GetDevice<Keyboard>().spaceKey, _controls.Actions.Get().FindAction("Remap"));
            _mappingCreator.ApplyInputBinding();*/
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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