using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
    Ground Manager handles loading and setting up ground tiles.
**/
public class GroundManager : MonoBehaviour {

    public static int cacheSize = 20;
    public static int nActives = 20;

    public int tileSize = 10;

    public Transform[] groundPrefabs = new Transform[1];
    public Transform finishPrefab;

    LinkedList<Transform> cache;    // inactive tiles
    LinkedList<Transform> actives;  // active tiles

    // load stuff
    void Awake()
    {
        Debug.Log("GroundManager Awake");
        cache = new LinkedList<Transform>();
        actives = new LinkedList<Transform>();

        // fill up cache with instantiated tiles from prefabs
        for(int i=0; i<cacheSize; i++)
        {
            //Randomize tiles
            int R = Random.Range(0, groundPrefabs.Length);
            Transform t = Instantiate<Transform>(groundPrefabs[R]);
            t.SetParent(transform); // keep tiles as children of this
            t.gameObject.SetActive(false);
            cache.AddLast(t);
        }
        Transform last = Instantiate<Transform>(finishPrefab);
        last.SetParent(transform);
        finishPrefab.gameObject.SetActive(false);
        cache.AddLast(last);
        Debug.Log("GroundManager Ready");
    }

	// initialization
	void Start () {
        // activate starting tiles
	    for (int i=0; i<nActives + 1; i++) // nActives + 1 due to finish line.
        {
            Transform t = cache.First.Value;
            Vector3 pos = new Vector3(0f, 0f, i * tileSize);
            t.localPosition = pos;
            t.gameObject.SetActive(true);
            cache.RemoveFirst();
            actives.AddLast(t);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
