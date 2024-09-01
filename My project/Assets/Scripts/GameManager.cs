using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text userIdText;

    void Start()
    {
        // ��������� ��������� � URL
        string userId = GetQueryStringValue("user_id");
        if (!string.IsNullOrEmpty(userId))
        {
            // ������������ ID ����������� � ��������� �������
            userIdText.text = "User ID: " + userId;

            // ��������� ���������� �� � userId
            Debug.Log("Received user ID: " + userId);
        }
    }

    string GetQueryStringValue(string key)
    {
        // ��������� ��������� � URL
        var queryString = new System.Uri(Application.absoluteURL).Query;
        var queryParams = System.Web.HttpUtility.ParseQueryString(queryString);
        return queryParams[key];
    }
}
