using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
    Ground Manager handles loading and setting up ground tiles.
**/
public class GroundManager : MonoBehaviour {

    public int numberOfMapTiles;

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

        finishPrefab.gameObject.SetActive(false);

        // fill up cache with instantiated tiles from prefabs
        for (int i=0; i < numberOfMapTiles; i++)
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
        cache.AddLast(last); // there is at least a finish line
        Debug.Log("GroundManager Ready");
    }

	// initialization
	void Start () {
        // activate starting tiles
	    for (int i=0; i<numberOfMapTiles + 1; i++) // +1 since the finish line is also in there
        {
            Transform t = cache.First.Value;
            Vector3 pos = new Vector3(0f, 0f, i * tileSize);
            t.localPosition = pos;
            t.gameObject.SetActive(true);
            cache.RemoveFirst();
            actives.AddLast(t);
        }
	}

#if UNITY_EDITOR
    /**
        Useful help in Unity editor.  Don't do this at runtime.
    **/
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < numberOfMapTiles + 1; i++) // +1 to leave room for finish line
        {
            Vector3 pos = new Vector3(0, 0, i * tileSize);
            Gizmos.DrawWireCube(pos, new Vector3(tileSize, 0.2f, tileSize));
        }
    }
#endif
}
