using UnityEngine;
using System.Collections;

public class RunnerCam : MonoBehaviour {

    public Transform runner;
    public float followDistance;

	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, runner.position.z - followDistance);
        transform.position = pos;
	}
}
