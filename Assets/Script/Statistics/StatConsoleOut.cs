using UnityEngine;
using System.Collections;
using System;

public class StatConsoleOut : MonoBehaviour, StatOut {

    /** StatOut Interface methods ------------------ **/
    //public void add(Stats stats)
    //{
    //    Debug.Log("Stat printing");
    //    print(stats.getDistance());
    //}

    public void Display(string msg)
    {
        print(msg);
    }
}
