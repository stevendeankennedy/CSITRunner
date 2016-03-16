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

	[Tooltip("Color swap frequency")]
	public float colorSwapTime;

	private SpriteRenderer spRend;
	private Color randomColor;
	public float timer;
	void Start(){
		spRend = GetComponent<SpriteRenderer>();
		randomColor = new Color (Random.value, Random.value, Random.value);
        spRend.color = randomColor;
	}

	// Update is called once per frame
	void Update () {
        transform.localPosition += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;
        Vector3 cRot = transform.rotation.eulerAngles;
        cRot += torque;
        transform.localRotation = Quaternion.Euler(cRot);

		timer += Time.deltaTime;

		if (timer >= colorSwapTime) {
			
			randomColor = new Color (Random.value, Random.value, Random.value);
			spRend.color = randomColor;
			timer -= colorSwapTime;
		} else {
			
		}

    }
}
