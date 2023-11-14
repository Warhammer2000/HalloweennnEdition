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
    [SerializeField] private InputAction _onMenuClickedPlus;
    [SerializeField] private InputAction _onMenuClickedB;
    [SerializeField] private InputAction _onSettingsClickedMinus;
    [SerializeField] private GameObject MenuPanel;
    [Space(10)]
    [SerializeField] private List<GameObject> _disabledUIObjects;
    private bool isButtonClicked = false;
    private bool isButtonSettingsClicked = false;
    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClickUi);
        _settings.CloseButtonClicked += OnCloseButtonClicked;
        _onMenuClickedPlus.Enable();
        _onMenuClickedB.Enable();
        _onSettingsClickedMinus.Enable();
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClickUi);
        _settings.CloseButtonClicked -= OnCloseButtonClicked;
        _onMenuClickedPlus.Disable();
        _onMenuClickedB.Disable();
    }
    private void Update()
    {
        if (_onMenuClickedB.triggered || _onMenuClickedPlus.triggered)
        {
            isButtonClicked = !isButtonClicked;
            MenuPanel.SetActive(isButtonClicked);
        }
        if (_onSettingsClickedMinus.triggered)
        {
            isButtonSettingsClicked = !isButtonSettingsClicked;
            OnSettingsButtonClick();
        }
    }
    private void OnSettingsButtonClick()
    {
        _settings.gameObject.SetActive(isButtonSettingsClicked);
        _disabledUIObjects.ForEach(item => item.SetActive(false));
        _joystickInput.enabled = false;
        _joystickCanvas.enabled = false;
    }
    private void OnSettingsButtonClickUi()
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
