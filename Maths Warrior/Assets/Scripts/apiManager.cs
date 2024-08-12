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
        //if (Input.GetKeyDown(KeyCode.Space)){
            //StartCoroutine(SendDataToGAS(prompt));
        //}
    }

    public IEnumerator SendDataToGAS(string question)
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", question);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
        string response = "";

        if(www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Prompt was "+question);
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There was an error !";
        }

        DM.aiAnswer = response;
    }

    public IEnumerator setName()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", DM.aiQuestion);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
        string response = "";

        if (www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There was an error !";
        }

        DM.name = response;
    }

    public IEnumerator checkName()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", DM.aiQuestion);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
        string response = "";

        if (www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There was an error !";
        }
        DM.nameCheck = response;
    }

}
