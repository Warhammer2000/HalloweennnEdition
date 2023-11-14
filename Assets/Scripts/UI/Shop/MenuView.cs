using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _reloadButton;
    public event Action CloseButtonClicked;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
        if (_reloadButton != null)
        {
            _reloadButton.onClick.AddListener(Restart);
        }
        else return;
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        if (_reloadButton != null)
        {
            _reloadButton.onClick.RemoveListener(Restart);
        }
        else return;

    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCloseButtonClicked()
    {
        CloseButtonClicked?.Invoke();
    }
}
