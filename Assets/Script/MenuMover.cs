using UnityEngine;
using System.Collections;


/**
    This is a trashy implementation of a mover, this is supposed to just move tiles forward to give the illusion of a running camera.
    USE: Get's added to some object and that object will move "forward"
*/
public class MenuMover : MonoBehaviour {


    public float SPEED = 9.8f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Using back, this is because we want it to go negative on the Z axis.
        this.GetComponentInParent<Transform>().Translate(Vector3.back * Time.deltaTime * SPEED);
	}
}
