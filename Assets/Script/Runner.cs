using UnityEngine;
using System.Collections;

/**
    Basic runner.

    TODO: Instead of forcing alternating steps, maybe just treat all steps the same.
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

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
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
            anim.SetTrigger("doStepLeft");
            speed += accelFactor;

        }
        else if (isR)
        {
            anim.SetTrigger("doStepRight");
            speed += accelFactor;

        }

        isL = false;
        isR = false;

        // move ---------------------------------------------
        // don't go backwards...
        if (speed > 0) {
            speed -= decelFactor;
            if (speed < 0)
                speed = 0f;
        }
        // don't go over max speed
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
        Debug.Log("Finish!");
    }
}
