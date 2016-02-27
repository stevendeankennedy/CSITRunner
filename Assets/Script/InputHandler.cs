﻿using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    Runner p1;
    Runner p2;

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

        p1.Run(runLeft, runRight);

        // player 2 ------------------------------
        runLeft = false;
        runRight = false;
        x = Input.GetAxisRaw("p2Horz");
        if (x < 0)
            runLeft = true;
        else if (x > 0)
            runRight = true;
        p2.Run(runLeft, runRight);
    }

    public void SetPlayers(Runner p1, Runner p2)
    {
        this.p1 = p1;
        this.p2 = p2;
    }
}