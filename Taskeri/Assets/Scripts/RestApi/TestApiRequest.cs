using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class TestApiRequest : MonoBehaviour
{
    public Button sendRequestButton;
    public InputField inputField;
    public string apiUrl = "http://localhost:8080/api/someendpoint"; // Update the API endpoint URL

    private void Start()
    {
        sendRequestButton.onClick.AddListener(SendRequest);
    }

    private void SendRequest()
    {
        // Get the text from the InputField
        string inputText = inputField.text;

        // Create a simple JSON object with a single field
        string jsonData = "{\"inputText\": \"" + inputText + "\"}";

        StartCoroutine(PostDataToApi(jsonData));
    }

    private IEnumerator PostDataToApi(string jsonData)
    {
        WWWForm form = new WWWForm();
        form.AddField("data", jsonData);

        UnityWebRequest www = UnityWebRequest.Post(apiUrl, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            Debug.Log("Request sent successfully!");
        }
    }
}
