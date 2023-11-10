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
        _reloadButton.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        _reloadButton.onClick.RemoveListener(Restart);
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
