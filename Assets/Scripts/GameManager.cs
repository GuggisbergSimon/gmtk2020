using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelManager _levelManager;
    private MappingCreator _mappingCreator;
    private Player _player;
    private AudioSource _source;
    public LevelManager LevelManager => _levelManager;

    public MappingCreator MappingCreator => _mappingCreator;

    public Player Player => _player;

    public static GameManager Instance { get; private set; }

    public bool tutorial;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoadingScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoadingScene;
    }

    //this function is activated every time a scene is loaded
    private void OnLevelFinishedLoadingScene(Scene scene, LoadSceneMode mode)
    {
        Setup();
        _mappingCreator.Save();
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
        tutorial = true;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _source = GetComponent<AudioSource>();
        Setup();
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

    public void PlayMusic(bool toggle)
    {
        if (toggle)
        {
            _source.Play();
        }
        else
        {
            _source.Stop();
        }
    }
}