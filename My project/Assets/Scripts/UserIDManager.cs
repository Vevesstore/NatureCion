using UnityEngine;
using UnityEngine.UI;

public class UserIDManager : MonoBehaviour
{
    public Text userIdText;  // ��������� �� ��������� ������� UI, ���� �� ������ ���������� ID
    public Text urlText;  // ��������� �� ��������� ������� UI, ���� �� ������ ���������� URL

    void Start()
    {
        // ��������� �������� ��������� user_id � URL
        string userId = GetUserIDFromURL();

        // ³���������� ID ����������� � ��������� ������� UI
        if (!string.IsNullOrEmpty(userId))
        {
            userIdText.text = "User ID: " + userId;
            Debug.Log("Received user ID: " + userId);
        }
        else
        {
            Debug.LogWarning("User ID not found in URL.");
        }

        // ³���������� ������� URL � ��������� ������� UI
        string gameUrl = Application.absoluteURL;
        if (urlText != null)
        {
            urlText.text = "Game URL: " + gameUrl;
            Debug.Log("Game URL: " + gameUrl);
        }
    }

    // ������� ��� ��������� �������� ��������� user_id � URL
    string GetUserIDFromURL()
    {
        // ��������� ������� URL
        string url = Application.absoluteURL;
        Debug.Log("URL: " + url);

        // ��������, �� URL ������ ���������
        if (url.Contains("?"))
        {
            // �������� ��������� � URL
            string queryString = url.Split('?')[1];
            string[] parameters = queryString.Split('&');

            foreach (string param in parameters)
            {
                string[] keyValue = param.Split('=');

                if (keyValue[0] == "user_id")
                {
                    return keyValue[1];  // ��������� �������� ��������� user_id
                }
            }
        }
        return null;  // ������� null, ���� �������� �� ��������
    }
}
