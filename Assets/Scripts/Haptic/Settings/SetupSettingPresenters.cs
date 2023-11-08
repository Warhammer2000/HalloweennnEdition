using UnityEngine;
using UnityEngine.UI;
using BabyStack.Settings;

public class SetupSettingPresenters : MonoBehaviour
{
    [SerializeField] private BackgroundMusic _music;

    [Header("Presenters")]
    [SerializeField] private SettingPresenter _audioPresenter;
    [SerializeField] private SettingPresenter _musicPresenter;
    [SerializeField] private SettingPresenter _vibrationsPresenter;

    [Header("Sounds controller")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource musicSource;

    [SerializeField] private bool isMainMenu;
    public void SetVolume(float volume)
    {
        volume = volumeSlider.value;
        musicSource.volume = volume;
    }
    private void Start()
    {
        _audioPresenter.Init(new Audio());
        _musicPresenter.Init(_music);
        _vibrationsPresenter.Init(new Vibration());
        if (isMainMenu) volumeSlider.value = musicSource.volume;
    }
}
