using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public static class SaveData
{
    public static void SetDateTime(string key, DateTime DefaultValue)
    {
        string convertedToString = DefaultValue.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, convertedToString);
    }

    public static DateTime GetDateTime(string key, DateTime DefaultValue)
    {
        if(PlayerPrefs.HasKey(key))
        {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return DefaultValue;
        }
    }
}
