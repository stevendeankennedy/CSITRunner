using UnityEngine;
using System.Collections;

public class NumberFlier : MonoBehaviour {

    [Tooltip("How fast to fly")]
    public float speed;
    [Tooltip("Distance of wave movement")]
    public float amplitude;
    [Tooltip("Wave width")]
    public float frequency;

    private Rigidbody rb;

    void Start()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.forward;
	}
}
