using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShakeManager : MonoBehaviour
{
    [SerializeField] private float _shakeThreshold = 2.0f;
    [SerializeField] private float _shakeInterval = 0.25f;
    [SerializeField] private int _income = 1;
     
    private float timeSinceLastShake = 0f;
    private Vector3 acceleration;
    private Vector3 lastAcceleration;

    private void Start()
    {
        lastAcceleration = Input.acceleration;
    }

    private void Update()
    {
        acceleration = Input.acceleration;
        float shakeMagnitude = (acceleration - lastAcceleration).magnitude;

        if (shakeMagnitude > _shakeThreshold)
        {
            timeSinceLastShake += Time.deltaTime;

            if (timeSinceLastShake >= _shakeInterval)
            {
                timeSinceLastShake = 0f;
                GiveMoney();
            }
        }
        else
        {
            timeSinceLastShake = 0f;
        }

        lastAcceleration = acceleration;
    }

    private void GiveMoney()
    {
        MoneyManager.moneyManager.ChangeMoneyCount(_income);
    }
}

