using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DM : MonoBehaviour
{
    public static string inputAnswer = "";

    public static string question = "";

    public static string aiAnswer = "", aiQuestion = "", name = "", nameCheck = "";

    public static string[] setQuestions;

    public static HashSet<int> quesIndexs = new HashSet<int>();

    public static Boolean collided = false;

    public static int answer ;

    public static int level ;

    public static int powerIndex ;

    public static Boolean[] powerMeter;

    public static void setBool(int n)
    {
        powerMeter = new Boolean[n];
        for(int i=0;i<n;i++)
            powerMeter[i] = false;
    }

    public static void initializeQuestions()
    {

        setQuestions = new string[]{ 
            "What are you famous for ?",
            "What was your nickname ?",
            "What century are you from ?",
            "Give me hint to as who you are",
            "Give me hint to as who you are",
            "Tell me something about yourself",
            "What would your age be in 2024 ?"};

        int num = setQuestions.Length;
        for(int i=0;i<num;i++)
            quesIndexs.Add(i);
    }
}
