using UnityEngine;

public class SaveDataSwitch : MonoBehaviour
{
    private static SaveDataSwitch instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        PlayerPrefsSwitch.PlayerPrefsSwitch.Init();
    }


    

    private void OnApplicationQuit()
    {
        PlayerPrefsSwitch.PlayerPrefsSwitch.Term();
    }
}
