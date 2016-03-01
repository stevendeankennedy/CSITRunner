﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    public Runner player1;
    public Runner player2;

    private bool hasWinner;
    private int finishCount = 0;
    private bool displayStats = true;

    private UIUpdater uiUpdater;
    private StatManager sm;
    private InputHandler ih;

	// Use this for initialization
	void Start () {
        player1.player = 1;
        player2.player = 2;
        ih = gameObject.AddComponent<InputHandler>();
        ih.SetPlayers(player1, player2);

        sm = gameObject.AddComponent<StatManager>();

        uiUpdater = FindObjectOfType<UIUpdater>(); // confirm: this better than static call?
	}
    
    public void CrossFinishLine(Runner r)
    {
        Debug.Log(r.name + " has crossed the finish line.");
        if (!hasWinner) {
            hasWinner = true;
            // TODO: Move this to updates
            Debug.Log(r.name + " wins!");
            uiUpdater.ShowWinner(transform.position);
            sm.Register(player1, player2);
        }
        finishCount = finishCount + 1;
        ih.SetInput(r.player, false); // turn off input
    }

    void FixedUpdate()
    {
        // wait a while
        if (!hasWinner)
            return;

        if (displayStats && finishCount >= 2)
        {
            displayStats = false;
            sm.DisplayAll();
        }
    }
}