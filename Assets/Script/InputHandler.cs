using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    Runner p1;
    Runner p2;

    bool doInputP1;
    bool doInputP2;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Starting Input");
    }

    // Update is called once per frame
    void Update()
    {
        bool runLeft = false;
        bool runRight = false;
        float x = 0f;
        // player 1 -----------------------------
        if (doInputP1)
        {
            x = Input.GetAxisRaw("Horizontal");
            if (x < 0)
                runLeft = true;
            else if (x > 0)
                runRight = true;

            p1.Run(runLeft, runRight);
        }

        // player 2 ------------------------------
        if (doInputP2)
        {
            runLeft = false;
            runRight = false;
            x = Input.GetAxisRaw("p2Horz");
            if (x < 0)
                runLeft = true;
            else if (x > 0)
                runRight = true;
            p2.Run(runLeft, runRight);
        }
    }

    public void SetPlayers(Runner p1, Runner p2)
    {
        this.p1 = p1;
        this.p2 = p2;
        doInputP1 = true;
        doInputP2 = true;
    }

    /**
        player 1 is 1, player 2 is 2
        Turns on/off their input.  Ignores other values.
    **/
    public void SetInput(int player, bool b)
    {
        if (player == 1)
        {
            doInputP1 = b;
        }
        else if (player == 2)
        {
            doInputP2 = b;
        }
    }
}