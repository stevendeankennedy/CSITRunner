using UnityEngine;
using System.Collections;
using System;

public class StatConsoleOut : MonoBehaviour, StatOut {


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /** StatOut Interface methods ------------------ **/
    public void add(Stats stats)
    {
        throw new NotImplementedException();
    }

    public void display(string msg)
    {
        print(msg);
    }
}
