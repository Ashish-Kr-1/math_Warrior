using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player, guessWindow, startScreen;
    public Animator anm;
    public TMP_Text answer, question, aiAnswer, countdown;
    public float timer, startTimer, timeWidth;
    public Image timeBar;
    public GameObject[] power = new GameObject[5];

    public Boolean stopDelay;
    Rigidbody rb;
    public float jumpForce;
    internal int turn = 0;
    internal int c = 8;
    internal float delay;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

        DM.inputAnswer = "";
        DM.level = 1;
        DM.answer = 0;
        DM.setBool(5);
        DM.powerIndex = -1;
        DM.aiAnswer = "Wow, a new visitor !";
        DM.aiQuestion = "";
        DM.collided = false;

        startScreen.SetActive(true);
        stopDelay = true;
        anm.SetBool("changeFall", true);
        c = 8;
        startTimer += 0.49f;
        delay = timer;
        setQuestion();
        DM.initializeQuestions();
    }

    // Update is called once per frame
    void Update()
    {

        answer.text = DM.inputAnswer;
        question.text = DM.question;
        aiAnswer.text = DM.aiAnswer;

        if (startTimer >= 0.51)
        {
            startTimer -= Time.deltaTime;
            countdown.text = "" + Math.Round(startTimer);
        }
        else
        {
            startScreen.SetActive(false);
            stopDelay = false;
        }

        if(guessWindow.activeInHierarchy)
            stopDelay = true;

        if(!stopDelay)
            delay -= Time.deltaTime;

        if (delay < 0)
        {
            //Debug.Log("Time out");
        }

        if (delay > 0) 
            timeBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,timeWidth * (delay/timer));
        else
            timeBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);

        if ((delay / timer) >= 0.8)
        {
            timeBar.color = new Color32(249, 7, 138, 255);
        }
        else if ((delay / timer) >= 0.2)
            timeBar.color = new Color32(7, 249, 95, 255);
        else
            timeBar.color = new Color32(249, 31, 7, 255);

        for (int i = 0; i < 5; i++)
        {
            power[i].SetActive(DM.powerMeter[i]);
        }
    }

    public void jump()
    {
        //Vector3 currentPos = player.transform.position;

        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

        if (anm.GetBool("isFalling"))
            anm.SetBool("isFalling", false);
        else
        {
            anm.SetBool("changeFall", !anm.GetBool("changeFall"));
            anm.SetBool("jumpRight", turn % 2 == 0);
        }


        turn++;
    }

    public void fall()
    {
        //Vector3 currentPos = player.transform.position;

        rb.AddForce(0, -jumpForce, 0, ForceMode.Impulse);

        if (anm.GetBool("isFalling"))
            anm.SetBool("changeFall", !anm.GetBool("changeFall"));
        else
            anm.SetBool("isFalling", true);

        turn++;
    }

    public void numClick(Button btn)
    {
        DM.inputAnswer = DM.inputAnswer + btn.gameObject.tag;
    }

    public void setQuestion()
    {
        Debug.Log("Level = "+DM.level);
        if (DM.level == 1)
        {
            int type = UnityEngine.Random.Range(0, 3);
            int x, y;
            switch(type)
            {
                case 0:
                    x = UnityEngine.Random.Range(1, 6);
                    y = UnityEngine.Random.Range(1, 6);

                    DM.question = x + "x" + y + "=?";
                    DM.answer = x * y;

                    break;
                case 1:
                    x = UnityEngine.Random.Range(4, 7);
                    y = UnityEngine.Random.Range(1, 6);

                    DM.question = (x*y) + "/" + x + "=?";
                    DM.answer = y;

                    break;
                case 2:
                    x = UnityEngine.Random.Range(1, 19);
                    y = UnityEngine.Random.Range(1, 19);

                    DM.question = x + "+" + y + "=?";
                    DM.answer = x + y;
                    break;
            }
        }
        else if (DM.level == 2)
        {
            int type = UnityEngine.Random.Range(0, 3);
            int x, y;
            switch (type)
            {
                case 0:
                    x = UnityEngine.Random.Range(6, 11);
                    y = UnityEngine.Random.Range(6, 11);

                    DM.question = x + "x" + y + "=?";
                    DM.answer = x * y;

                    break;
                case 1:
                    x = UnityEngine.Random.Range(8, 13);
                    y = UnityEngine.Random.Range(4, 9);

                    DM.question = (x * y) + "/" + y + "=?";
                    DM.answer = x;

                    break;
                case 2:
                    x = UnityEngine.Random.Range(12, 39);
                    y = UnityEngine.Random.Range(14, 39);

                    DM.question = x + "+" + y + "=?";
                    DM.answer = x + y;
                    break;
            }
        }
        else if (DM.level == 3)
        {
            int type = UnityEngine.Random.Range(0, 1);
            int x, y;
            switch (type)
            {
                case 0:
                    x = UnityEngine.Random.Range(11, 17);
                    y = UnityEngine.Random.Range(5, 12);

                    DM.question = x + "x" + y + "=?";
                    DM.answer = x * y;

                    break;
            }
        }
    }

    public void onSubmit()
    {
        if (Int32.Parse(DM.inputAnswer) == DM.answer) {
            Debug.Log("Correct answer");
            jump();

            if ((delay / timer) >= 0.8)
            {
                if (DM.powerIndex <= 4)
                {
                    DM.powerIndex++;
                    DM.powerMeter[DM.powerIndex] = true;
                }
                else
                {
                    PowerModeOn();
                }
            }
        }
        else
        {
            Debug.Log("Wrong answer");
            fall();
        }

        DM.inputAnswer = "";

        DM.level = c / 8; 
        setQuestion();
        delay = timer;
        c++;
    }

    public void PowerModeOn()
    {
        jumpForce += 25;
    }

    public void takeGuess()
    {
        guessWindow.SetActive(true);
        stopDelay = true;
    }

    public void failedAttempt()
    {
        guessWindow.SetActive(false);
        fall();
        stopDelay = false;
    }
}
