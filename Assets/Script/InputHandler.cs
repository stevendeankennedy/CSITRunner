using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    public Runner player;


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
        float x = Input.GetAxisRaw("Horizontal");
        if (x < 0)
            runLeft = true;
        else if (x > 0)
            runRight = true;

        player.run(runLeft, runRight);
    }
}