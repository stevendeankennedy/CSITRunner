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
            Step("doStepLeft");
        }
        else if (isR)
        {
            Step("doStepRight");
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

    void Step(string animTrigger)
    {
        anim.SetTrigger(animTrigger);
        speed += accelFactor;
        myStats.AddStep();
    }

    public void RunLeft()
    {
        isL = true;
    }

    public void RunRight()
    {
        isR = true;
    }

    public void Run(bool L, bool R)
    {
        if (L)
            isL = true;
        if (R)
            isR = true;
    }

    void OnTriggerEnter()
    {
        // TODO: This needs fleshed out a lot
        GameManager gm = GameManager.instance;
        gm.CrossFinishLine(this);   
    }

    public Stats Stats()
    {
        return myStats;
    }
}
