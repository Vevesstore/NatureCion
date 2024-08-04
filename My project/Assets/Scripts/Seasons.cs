using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Seasons : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private Image seasonIcon;
    [SerializeField] private List<SeasonsTypes> seasons;

    [SerializeField, Range(0, 365)] private int time;

    [Serializable]
    struct SeasonsTypes
    {
        public string seasonName;
        public float whenTime;
        public Sprite icon;
        public Color bgColor;
    }

    private float second = 0;
    private string currentSeason;
    private Dictionary<int, string> seasonMapping;

    private const string LastSaveKey = "LastSaveTime";
    private DateTime lastSaveTime;

    void Start()
    {
        // Initialize the season mapping
        seasonMapping = new Dictionary<int, string>
        {
            { 0, "winter" },
            { 90, "spring" },
            { 152, "summer" },
            { 274, "autumn" }
        };

        // Load the last saved time
        LoadTime();

        // Calculate the elapsed time
        UpdateElapsedTime();

        // Update the season based on the current time
        UpdateSeason(time);
    }

    void FixedUpdate()
    {
        second += Time.deltaTime;

        if (second > 1)
        {
            time++;
            second = 0;

            if (time >= 365)
            {
                time = 0;
            }

            // Update the season if necessary
            UpdateSeason(time);

            // Save the current time
            SaveTime();
        }
    }

    void UpdateSeason(float time)
    {
        var orderedKeys = seasonMapping.Keys.OrderBy(t => t).ToList();
        int seasonStartTime = orderedKeys.LastOrDefault(key => time >= key);

        string newSeason = seasonMapping[seasonStartTime];

        if (newSeason != currentSeason)
        {
            currentSeason = newSeason;

            SeasonsTypes s = seasons.FirstOrDefault(item => item.seasonName == currentSeason);
            seasonIcon.sprite = s.icon;
            bg.color = s.bgColor;
        }
    }

    void SaveTime()
    {
        PlayerPrefs.SetInt("Time", time);
        PlayerPrefs.SetString(LastSaveKey, DateTime.UtcNow.ToString("o")); // Save current time as ISO 8601
        PlayerPrefs.Save();
    }

    void LoadTime()
    {
        time = PlayerPrefs.GetInt("Time");
        string lastSaveTimeStr = PlayerPrefs.GetString(LastSaveKey, DateTime.UtcNow.ToString("o"));
        lastSaveTime = DateTime.Parse(lastSaveTimeStr, null, System.Globalization.DateTimeStyles.RoundtripKind);
    }

    void UpdateElapsedTime()
    {
        DateTime now = DateTime.UtcNow;
        TimeSpan elapsed = now - lastSaveTime;
        int elapsedDays = (int)elapsed.TotalSeconds;

        time = (time + elapsedDays) % 365;

        lastSaveTime = now;
    }
}