using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text userIdText;

    void Start()
    {
        // Отримання параметрів з URL
        string userId = GetQueryStringValue("user_id");
        if (!string.IsNullOrEmpty(userId))
        {
            // Встановлення ID користувача в текстовий елемент
            userIdText.text = "User ID: " + userId;

            // Виконання додаткових дій з userId
            Debug.Log("Received user ID: " + userId);
        }
    }

    string GetQueryStringValue(string key)
    {
        // Отримання параметрів з URL
        var queryString = new System.Uri(Application.absoluteURL).Query;
        var queryParams = System.Web.HttpUtility.ParseQueryString(queryString);
        return queryParams[key];
    }
}
