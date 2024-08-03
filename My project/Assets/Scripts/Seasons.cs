using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/* Пори року тривають:

Зима - 90 днів
Весна - 92 дні
Літо - 92 дні
Осінь - 91 день

*/

public class Seasons : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private Image seasonIcon;
    [SerializeField] private List<SeasonsTypes> seasons;

    // Серіалізовано чисто для показу в інспекторі
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

    void Start()
    {
        seasonMapping = new Dictionary<int, string>
        {
            { 0, "winter" },
            { 90, "spring" },
            { 152, "summer" },
            { 274, "autumn" }
        };
    }

    void FixedUpdate()
    {
        UpdateSeason(time);

        second += Time.deltaTime;

        if (second > 1)
        {
            time++;
            second = 0;
        }

        if (time == 365)
        {
            time = 0;
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
}
