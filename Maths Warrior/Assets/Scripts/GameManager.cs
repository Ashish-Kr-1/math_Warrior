using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Animator anm;
    public TMP_Text answer;

    Rigidbody rb;
    public float speed;
    internal int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

        DM.inputAnswer = "";
        DM.level = 1;
        DM.answer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        answer.text = DM.inputAnswer;
    }

    public void onClick()
    {
        //Vector3 currentPos = player.transform.position;

        rb.AddForce(0, speed, 0, ForceMode.Impulse);

        anm.SetBool("jumpRight", turn % 2 == 0);

        turn++;
    }

    public void numClick(Button btn)
    {
        DM.inputAnswer = DM.inputAnswer + btn.gameObject.tag;
    }

    public void setQuestion()
    {
        if (DM.level == 1)
        {
        }
        else if (DM.level == 2)
        {
        }
        else if (DM.level == 3)
        {
        }
    }
}
