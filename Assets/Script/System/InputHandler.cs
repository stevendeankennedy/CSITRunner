using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    const string P1_BUTTON = "p1Step";
    const string P2_BUTTON = "p2Step";

    AudioSource stepAudio;

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
        // -- MAKEY compatible movement
        // player 1
        if (doInputP1)
        {
            bool step = Input.GetButtonDown(P1_BUTTON);
            if (step) {
                p1.Step();
                stepAudio.Play();
            }
                
                
        }

        // player 2 ------------------------------
        if (doInputP2)
        {
            bool step = Input.GetButtonDown(P2_BUTTON);
            if (step)
            {
                p2.Step();
                stepAudio.Play();
            }
        }

        //Hard coded back to menu key (esc)
        if (Input.GetKeyDown(KeyCode.Escape)) {
           GameObject[] G = GameObject.FindGameObjectsWithTag("CrossScreenHelper");
            G[0].GetComponent<CrossScreenHelper>().ChangeLevelMenu();
        }
    }

    public void SetPlayers(Runner p1, Runner p2)
    {
        this.p1 = p1;
        this.p2 = p2;
    }

    public void SetAudio(AudioSource StepAudio)
    {
        this.stepAudio = StepAudio;
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

    // Turn on all input
    public void SetInputOnForAll()
    {
        doInputP1 = true;
        doInputP2 = true;
    }
}