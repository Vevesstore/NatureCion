using UnityEngine;
using UnityEngine.UI;

public class UserIDManager : MonoBehaviour
{
    public Text userIdText;  // Посилання на текстовий елемент UI, куди ви хочете відобразити ID
    public Text urlText;  // Посилання на текстовий елемент UI, куди ви хочете відобразити URL

    void Start()
    {
        // Отримання значення параметра user_id з URL
        string userId = GetUserIDFromURL();

        // Відображення ID користувача в текстовий елемент UI
        if (!string.IsNullOrEmpty(userId))
        {
            userIdText.text = "User ID: " + userId;
            Debug.Log("Received user ID: " + userId);
        }
        else
        {
            Debug.LogWarning("User ID not found in URL.");
        }

        // Відображення повного URL в текстовий елемент UI
        string gameUrl = Application.absoluteURL;
        if (urlText != null)
        {
            urlText.text = "Game URL: " + gameUrl;
            Debug.Log("Game URL: " + gameUrl);
        }
    }

    // Функція для отримання значення параметра user_id з URL
    string GetUserIDFromURL()
    {
        // Отримання повного URL
        string url = Application.absoluteURL;
        Debug.Log("URL: " + url);

        // Перевірка, чи URL містить параметри
        if (url.Contains("?"))
        {
            // Виділення параметрів з URL
            string queryString = url.Split('?')[1];
            string[] parameters = queryString.Split('&');

            foreach (string param in parameters)
            {
                string[] keyValue = param.Split('=');

                if (keyValue[0] == "user_id")
                {
                    return keyValue[1];  // Повертаємо значення параметра user_id
                }
            }
        }
        return null;  // Повертає null, якщо параметр не знайдено
    }
}
