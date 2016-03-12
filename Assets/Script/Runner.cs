using UnityEngine;
using System.Collections;

/**
    Basic runner.
**/
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

    // useful component references
    private Animator anim;
    private Rigidbody rb;

    // stats
    private Stats stats;

    // player number
    private int _player;
    public int player
    {
        get
        {
            return _player;
        }

        set
        {
            _player = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        stats = new Stats();

        // set up for running
        rb.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
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
        Step(IS_MOVING);
    }

    /**
        Handle triggers.  Crossing the finish line
    **/
    void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameManager.instance;
        if (other.CompareTag("Finish"))
            gm.CrossFinishLine(this);   
    }

    public Stats Stats()
    {
        return stats;
    }
}
