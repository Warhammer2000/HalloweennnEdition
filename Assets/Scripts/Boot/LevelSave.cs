using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSave : MonoBehaviour
{
    private const string CurrentLevelSaveKey = nameof(CurrentLevelSaveKey);
    private string MainlevelKey = "Shop";
    private LevelLoader _levelLoader;

    private void OnEnable()
    {
        _levelLoader = Singleton<LevelLoader>.Instance;
        _levelLoader.Loaded += OnLevelLoaded;
    }

    private void OnDisable()
    {
        if (_levelLoader)
            _levelLoader.Loaded -= OnLevelLoaded;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        LevelLoader.Level currentLevel = (LevelLoader.Level)PlayerPrefs.GetInt(CurrentLevelSaveKey, 0);
        _levelLoader.LoadLevel(currentLevel, "Loading");
    }

    private void OnLevelLoaded(LevelLoader.Level level)
    {
        PlayerPrefs.SetInt(CurrentLevelSaveKey, (int)level);
    }
    public void CreateNewGame()
    {
        PlayerPrefs.DeleteKey(CurrentLevelSaveKey);
        PlayerPrefs.Save();

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
