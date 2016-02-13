using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    public Runner p1;
    public Runner p2;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Starting Input");
    }

    // Update is called once per frame
    void Update()
    {
        // player 1 -----------------------------
        bool runLeft = false;
        bool runRight = false;
        float x = Input.GetAxisRaw("Horizontal");
        if (x < 0)
            runLeft = true;
        else if (x > 0)
            runRight = true;

        p1.run(runLeft, runRight);

        // player 2 ------------------------------
        runLeft = false;
        runRight = false;
        x = Input.GetAxisRaw("p2Horz");
        if (x < 0)
            runLeft = true;
        else if (x > 0)
            runRight = true;
        p2.run(runLeft, runRight);
    }
}