using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

}