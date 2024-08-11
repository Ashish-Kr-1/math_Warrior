using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class apiManager : MonoBehaviour
{
    [SerializeField] private string gasURL;
    [SerializeField] private string prompt;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(SendDataToGAS());
        }
    }

    private IEnumerator SendDataToGAS()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", prompt);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
        string response = "";

        if(www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Prompt was "+prompt);
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There was an error !";
        }

        Debug.Log(response);
    }
}
