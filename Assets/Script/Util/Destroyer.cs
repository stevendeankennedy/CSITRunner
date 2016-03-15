using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //For whatever reason, if we want to use this, we have to keep a rigid body attached to the destroyer prefab.
    void OnTriggerEnter(Collider foreignObject) {
        Destroy(foreignObject.gameObject);
   
    }
}
