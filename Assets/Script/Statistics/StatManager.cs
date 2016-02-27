using UnityEngine;
using System.Collections;

public class StatManager : MonoBehaviour {

    Stats[] stats;
    private int count;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool register(params Runner[] players)
    {
        // no room
        if (stats != null)
        {
            return false;
        }

        // room for players, get their statistics
        stats = new Stats[players.Length];
        for (int i=0; i<players.Length; i++)
        {
            stats[i] = players[i].stats();
        }
        return true;
    }
}
