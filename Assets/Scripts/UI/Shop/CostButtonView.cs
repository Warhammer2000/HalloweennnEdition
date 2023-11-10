using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CostButtonView : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private InputAction _buyAction;
    private int _cost;

    public event Action Clicked;

    [SerializeField] private int Balance;

   
    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClicked);
        _buyAction.Enable();
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
        _buyAction.Disable();
    }

    public void Init(int cost, int balance)
    {
        _cost = cost;
        DisplayForBalance(balance);
    }
    private void FixedUpdate()
    {
        Debug.Log(Balance);
        if (_buyAction.triggered && Balance >= _cost)
        {
            OnBuyButtonClicked();
        }
    }
    public void DisplayForBalance(int balance)
    {
        _price.text = _cost.ToString();
        _buyButton.interactable = balance >= _cost;
        Balance = balance;
    }

    private void OnBuyButtonClicked()
    {
        Clicked?.Invoke();
    }
}