using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : Singleton<LevelLoader>
{
    private const string ScreenTemplatePath = "Boot/LoadingSceneScreen";
    [SerializeField] private LevelLoadingScreen levelloading;
    private Dictionary<Level, string> _levels = new Dictionary<Level, string>()
    {
        //{LevelLoader.Level.HospitalManger, "Level1" },
        {LevelLoader.Level.Shop, "Shop" },
    };

    public event UnityAction<Level> Loaded;

    public void LoadLevel(Level level, string loadingText = "Loading")
    {
        Debug.Log(levelloading);

       
      //  var loadingScreen = Instantiate(levelloading);

        levelloading.LoadScene(_levels[level], loadingText, () =>
        {
            Loaded?.Invoke(level);
            Destroy(levelloading.gameObject);
        });
    }

    public enum Level
    {
        //HospitalManger,
        Shop,
        SchoolBar,
    }
}
