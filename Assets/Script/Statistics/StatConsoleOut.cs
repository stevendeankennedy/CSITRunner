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

    public void Display(Stats[] stats)
    {
        foreach(Stats S in stats)
        {
            print(S.Name);
            print("Steps:" + S.Steps);
            print("Average Speed:" + S.AverageSpeed);
            print("Maximum Speed:" + S.MaximumSpeed);
            print("Time Taken:" + S.TimeTaken);
        }
    }
}
