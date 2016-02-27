using UnityEngine;
using System.Collections;

/**
    Basic runner.
**/
public class Runner : MonoBehaviour
{
    public float speed;
    public float accelFactor;
    public float decelFactor;
    public float maxSpeed;

    private bool isL;
    private bool isR;

    private Animator anim;
    private Stats myStats;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myStats = new Stats();
    }

    // Update is called once per frame
    void Update()
    {
        // animate ------------------------------------------
        if (!isL && !isR)
        {
            //anim.SetTrigger("doNothing");
        }
        else if (isL)
        {
            step("doStepLeft");

        }
        else if (isR)
        {
            step("doStepRight");
        }

        isL = false;
        isR = false;

        // move ---------------------------------------------
        // don't go backwards...
        if (speed > 0) {
            anim.SetBool("Moving", true);
            speed -= decelFactor;
            if (speed < 0) {
                speed = 0f;
                anim.SetBool("Moving", false);
            }
                
        }
        // don't go over max speed
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void step(string animTrigger)
    {
        anim.SetTrigger(animTrigger);
        speed += accelFactor;
        myStats.addStep();
    }

    public void runLeft()
    {
        isL = true;
    }

    public void runRight()
    {
        isR = true;
    }

    public void run(bool L, bool R)
    {
        if (L)
            isL = true;
        if (R)
            isR = true;
    }

    void OnTriggerEnter()
    {
        Debug.Log(name + " wins!");
        UIUpdater ui = UIUpdater.instance;
        ui.showWinner(transform.position);
    }

    public Stats stats()
    {
        return myStats;
    }
}
