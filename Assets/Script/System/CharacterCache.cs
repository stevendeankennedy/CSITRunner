using UnityEngine;
//using System.Collections;


public class CharacterCache : MonoBehaviour {

    public Runner[] prefabs;
    private Runner[] cache;
    private int count = 0;

	// Use this for initialization
	void Awake () {

        
	}

    public void startUp() {
        cache = new Runner[prefabs.Length];
        // instantiate all prefabs;
        for (int i = 0; i < prefabs.Length; i++)
        {
            cache[i] = Instantiate<Runner>(prefabs[i]);
            cache[i].gameObject.SetActive(false);
        }
    }
	
    public Runner GetRunner()
    {
        if (count >= cache.Length)
        {
            return null; // bad get
        }

        return cache[count++];
    }

}
