using UnityEngine;
using System.Collections;

public class MenuSpawner : MonoBehaviour {

    public GameObject[] groundTiles = new GameObject[1];
    public float timeBetweenBuilds;
    private float lastBuild;
    private int randomHolder;

	// Use this for initialization
	void Start () {
        lastBuild = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        // It it's been 1 second since the last build we grab another random tile and build it.
        if (Time.time >= lastBuild + timeBetweenBuilds) {
            randomHolder = Random.Range(0, groundTiles.Length);
            GameObject x = (GameObject) Instantiate(groundTiles[randomHolder], new Vector3(0.0f, 0.0f, this.transform.position.z), Quaternion.identity);
            x.AddComponent<MenuMover>();
            
            lastBuild = Time.time;
        }
           
        
	}
}
