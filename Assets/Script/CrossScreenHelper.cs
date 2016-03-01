﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CrossScreenHelper : MonoBehaviour {

    //int corrasponding to what the plater will choose. The assumption is that when the characters are created in the next scene they can just take this number, instantiate, and associate with P1, P2.
    public GameObject Player1Char;
    public GameObject Player2Char;

    //The character prefabs that we will use for characters.
    public GameObject LINK, LAN;

    //An enum to make selecting characters easier.
    public enum Characters {
        LINK,
        LAN
    }

    void Awake() {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPlayer1Char(int selection) {
        //we pass an int that corrisponds to the character chosen by the player
        if ((Characters)selection == Characters.LINK)
        {
            this.Player1Char = LINK;
        }
        //did an if else due to the fact that we may have multiple characters in teh game before launch.
        else if ((Characters)selection == Characters.LAN) {
            this.Player1Char = LAN;
        }
    }

    //TODO[Matt] this whole passing an int thing and casting to a character is terrible, figure out how the static thing works so that I can actually make it the correct way.
    public void setPlayer2Char(int selection) {

        if ((Characters)selection == Characters.LINK)
        {

            this.Player2Char = LINK;
        }
        //did an if else due to the fact that we may have multiple characters in teh game before launch.
        else if ((Characters)selection == Characters.LAN)
        {
            this.Player2Char = LAN;
        }
    }

    //Called on Arcade button press. Will load the arcade mode of the game. I.E no character select. TODO[Matt] Make sure this isn't pointing at your test scene before pushing. Watch this not happen.
    public void ChangeLevelArcade() {
        SceneManager.LoadScene("SplitScreenTest-Matt");
    }
}
