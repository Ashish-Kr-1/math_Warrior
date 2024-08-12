using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class startScreenManager : MonoBehaviour
{
    public TMP_Text txt;

    private void Start()
    {
        txt.text = "Yes, you got it. I am " + DM.name;
    }

    public void BtnCaller(int index)
    {
        if (index == 0)
        {
            SceneManager.LoadScene("Game");
        }
        else if (index == 1)
        {
            Application.Quit();
        }
    }
}
