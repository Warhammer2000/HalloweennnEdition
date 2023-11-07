using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button CreateNewGameButton;
    [SerializeField] private Button LoadCurrentlevel;
    private string mainLevel = "Shop";
    private void Start()
    {
        CreateNewGameButton.onClick.AddListener(ClearPlayerPrefs);
        LoadCurrentlevel.onClick.AddListener(LoadNeededLevel);
    }
    private void ClearPlayerPrefs()
    {
        PlayerPrefsManager.ClearAllPlayerPrefs();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(mainLevel);
    }
    private void LoadNeededLevel() => SceneManager.LoadScene(mainLevel);
    
    
}
