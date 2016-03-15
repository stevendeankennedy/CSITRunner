using UnityEngine;
//using System.Collections;

/**
    A Floaty moves around eratically based on a fixed coordinate of its parent object.
    Usage: put a bunch of these in an Empty GameObject and give them torque.
**/
public class Floaty : MonoBehaviour {

    [Tooltip("How to rotate")]
    public Vector3 torque;
    [Tooltip("Distance of wave movement")]
    public float amplitude;
    [Tooltip("Wave width")]
    public float frequency;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;
        Vector3 cRot = transform.rotation.eulerAngles;
        cRot += torque;
        transform.localRotation = Quaternion.Euler(cRot);
    }
}
