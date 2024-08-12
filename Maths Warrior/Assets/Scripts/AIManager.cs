using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIManager : MonoBehaviour
{
    static apiManager AM;
    public string question;

    private string celebName = "";

    public string question1 = "" ;
    void Start()
    {
        AM = GetComponent<apiManager>();

        //question1 = "give me a name of a random public figure from 1950s to 2020s. He must be popular.";

        //DM.aiQuestion = question1;
        //StartCoroutine(AM.setName());

        DM.name = "Tom Cruise"; //For demo purposes, we fix the name
    }


    void Update()
    {
        if (DM.collided)
        {
            int ran = UnityEngine.Random.Range(0, DM.setQuestions.Length);

            while (!DM.quesIndexs.Contains(ran))
            {
                ran = UnityEngine.Random.Range(0, DM.setQuestions.Length);
            }
            
            DM.quesIndexs.Remove(ran);

            askQuestion("Stay in character as "+DM.name+ " and answer in one short proper sentence without mentioning your name and start you sentence with I. " + DM.setQuestions[ran]); 

            DM.collided = false;
        }
    }

    void askQuestion(string ques)
    {
        StartCoroutine(AM.SendDataToGAS(ques));
    }

    public void checkName(TMP_InputField txt)
    {
        DM.aiQuestion = "Stay in character as "+DM.name+ " and answer in one word without mentioning your name. Are you " + txt.text+" ? Answer only in YES or NO.";
        StartCoroutine(AM.checkName());

        if (DM.nameCheck.Equals("YES"))
        {
            Debug.Log("YOU WON");
            SceneManager.LoadScene("winScreen");
        }
        else
        {
            this.GetComponent<GameManager>().failedAttempt();
        }

    }
}
