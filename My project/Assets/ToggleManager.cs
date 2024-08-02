using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ToggleManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button button;
    [SerializeField] private TextMeshProUGUI _holdingText;
    [SerializeField] private int _incomeMultiplicator;

    private float _holdStartTime;
    private bool _isHolding = false;
    

    private void Update()
    {
        if (_isHolding)
        {
            float time = MathF.Round((Time.time - _holdStartTime), 2);
            _holdingText.text = time.ToString()+"s";
            if (_holdingText.transform.localScale != new Vector3(5, 5, 5))
            {
                _holdingText.transform.localScale = new Vector3(time/4, time/4, time/4);
            }
        }
    }


    public void OnButtonClick()
    {
        _holdStartTime = Time.time;
        _isHolding = true;
        _holdingText.gameObject.SetActive(true);
    }

    public void OnButtonRelease()
    {
        if (_isHolding)
        {
            float holdDuration = Time.time - _holdStartTime;
            _holdingText.gameObject.SetActive(false);
            GiveMoney((int)(Time.time - _holdStartTime) * _incomeMultiplicator);
            _isHolding = false;
        }
    }

    private void GiveMoney(int count)
    {
        MoneyManager.moneyManager.ChangeMoneyCount(count);
    }
}
