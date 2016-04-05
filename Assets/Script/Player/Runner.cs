using UnityEngine;
using System.Collections;

/**
    Basic runner.
**/
[RequireComponent( typeof (Rigidbody), typeof (BoxCollider))]
public class Runner : MonoBehaviour
{
    // constants
    private const string IS_MOVING = "isMoving";
    private const float ANIM_STOP = 0.05f;
    
    // Running stuff
    private float _speed;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    [Tooltip("Speeds runner up")]
    public float force; // speed up
    [Tooltip("Slows runner down")]
    public float drag; // slow down
    [Tooltip("This affects animation speed")]
    public float maxSpeed;
    bool willRun;

    [Tooltip("Adjust sprite to not clip floor")]
    public float preferredY;

    // useful component references
    private Animator anim;
    private Rigidbody rb;

    // stats
    private Stats stats;
    private bool shouldRegisterTime;

    // a timer
    private float timerTick;
    float timer;

    // player number
    private int _player;
    public int Player
    {
        get
        {
            return _player;
        }

        set
        {
            _player = value;
            //stats.Name = "Player " + _player;
        }
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        stats = new Stats();
        timerTick = stats.timeTick;
        shouldRegisterTime = false;

        // set up for running
        rb.drag = drag;
        Debug.Log(stats.Name + " ready!");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerTick) // tick
        {
            stats.RegisterSpeed(speed);

            timer -= timerTick;
        }

        // animate ------------------------------------------
        if (anim.GetBool(IS_MOVING) == true)
        {
            // proportional animation speed
            float animationSpeed = speed / maxSpeed;
            animationSpeed = Mathf.Clamp(animationSpeed, 0.2f, 1f);
            anim.speed = animationSpeed;
            //if (speed < ANIM_STOP)
            //    anim.SetBool(IS_MOVING, false);
        }

        // move ---------------------------------------------
        if (willRun)
        {
            rb.AddForce(0, 0, force);
            willRun = false;
        }
    }

    void FixedUpdate()
    {
        speed = rb.velocity.z;
    }

    /**
        Step forward and make sure to be animating
    **/
    void Step(string param)
    {
        anim.SetBool(param, true);
        stats.AddStep();

        willRun = true; // trigger movement on update
    }

    // Make a step forward
    public void Step()
    {
        if(shouldRegisterTime)
        {
            stats.RegisterStartTime(Time.timeSinceLevelLoad);
            shouldRegisterTime = false;
        }
        Step(IS_MOVING);
    }

    /**
        Handle triggers.  Crossing the finish line
    **/
    void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameManager.instance;
        if (other.CompareTag("Finish"))
        {
            stats.RegisterEndTime(Time.timeSinceLevelLoad);
            gm.CrossFinishLine(this);
        }
    }

    public Stats Stats()
    {
        return stats;
    }
}
