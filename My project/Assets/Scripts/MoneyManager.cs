using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager moneyManager;

    [SerializeField] private TextMeshProUGUI _moneyText;

    private int _moneyCount;

    private void Start()
    {
        SetMoneyManager();
        DowloandSavedMoneyCount();
        SetMoneyText();
    }
    private void SetMoneyManager()
    {
        moneyManager = this;
    }
    private void DowloandSavedMoneyCount()
    {
        _moneyCount = PlayerPrefs.GetInt("Money");
    }
    public void ChangeMoneyCount(int count)
    {
        _moneyCount += count;
        PlayerPrefs.SetInt("Money", _moneyCount);
        SetMoneyText();
    }
    private void SetMoneyText()
    {
        _moneyText.text = _moneyCount.ToString();
    }
}
