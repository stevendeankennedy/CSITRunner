using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
    Ground Manager handles loading and setting up ground tiles.
**/
public class GroundManager : MonoBehaviour {

    public static int cacheSize = 100;
    public static int nActives = 50;

    public int tileSize = 10;

    public Transform[] groundPrefabs = new Transform[1];

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
            //TODO: Currently only uses first prefab from collection.
            //  Add randomizer when more prefabs are created
            Transform t = Instantiate<Transform>(groundPrefabs[0]);
            t.SetParent(transform); // keep tiles as children of this
            t.gameObject.SetActive(false);
            cache.AddLast(t);
        }
        Debug.Log("GroundManager Ready");
    }

	// initialization
	void Start () {
        // activate starting tiles
	    for (int i=0; i<nActives; i++)
        {
            Transform t = cache.First.Value;
            Vector3 pos = new Vector3(0f, 0f, i * tileSize);
            t.localPosition = pos;
            t.gameObject.SetActive(true);
            cache.RemoveFirst();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
