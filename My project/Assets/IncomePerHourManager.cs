using System;
using UnityEngine;

public class IncomePerHourManager : MonoBehaviour
{
    private int Income;
    void Start()
    {
        DateTime lastSaveTime = SaveData.GetDateTime(key: "LastSaveTime", DefaultValue: DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - lastSaveTime;
        int secondsPassed = (int)timePassed.TotalSeconds;
        secondsPassed = Mathf.Clamp(secondsPassed, min: 0, max: 7 * 24 * 60 * 60);
        //_moneyCount += secondsPassed * Income;
    }

    private void IncomeForHour()
    {
        SaveData.SetDateTime("LastSaveTime", DateTime.UtcNow);
    }
}
