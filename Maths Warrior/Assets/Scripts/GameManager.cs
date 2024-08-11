using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Animator anm;

    Rigidbody rb;
    public float speed;
    internal int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        //Vector3 currentPos = player.transform.position;

        rb.AddForce(0, speed, 0, ForceMode.Impulse);

        anm.SetBool("jumpRight", turn%2==0);

        turn++;
    }
}
