using UnityEngine;
using System.Collections;
using System;

public class StatConsoleOut : MonoBehaviour, StatOut {


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
