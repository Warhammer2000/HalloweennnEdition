using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsPresenter : MonoBehaviour
{
    [SerializeField] private MenuView _settings;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private JoystickInput _joystickInput;
    [SerializeField] private Canvas _joystickCanvas;
    [SerializeField] private InputAction _onMenuClicked;
    [SerializeField] private GameObject MenuPanel;
    [Space(10)]
    [SerializeField] private List<GameObject> _disabledUIObjects;
    private bool isButtonClicked = false;
    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _settings.CloseButtonClicked += OnCloseButtonClicked;
        _onMenuClicked.Enable();
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _settings.CloseButtonClicked -= OnCloseButtonClicked;
        _onMenuClicked.Disable();
    }
    private void Update()
    {
        if (_onMenuClicked.triggered)
        {
            isButtonClicked = !isButtonClicked;
            MenuPanel.SetActive(isButtonClicked);
        }
    }
    private void OnSettingsButtonClick()
    {
        _settings.gameObject.SetActive(true);
        _disabledUIObjects.ForEach(item => item.SetActive(false));
        _joystickInput.enabled = false;
        _joystickCanvas.enabled = false;
    }

    private void OnCloseButtonClicked()
    {
        _settings.gameObject.SetActive(false);
        _disabledUIObjects.ForEach(item => item.SetActive(true));
        _joystickInput.enabled = true;
        _joystickCanvas.enabled = true;
    }
}
