using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatManager : MonoBehaviour {



    Stats[] stats;
    private int count;

    private StatOut statOutput;
    private StatGUIOut statGuiOutput;
    /**
        Register the player who's stats we want to manage.
    **/
    public bool Register(params Runner[] players)
    {
        // no room
        if (stats != null)
        {
            Debug.Log("Could not register.");
            return false;
        }

        // room for players, get their statistics
        stats = new Stats[players.Length];
        for (int i=0; i<players.Length; i++)
        {
            stats[i] = players[i].Stats();
        }
        statOutput = gameObject.AddComponent<StatConsoleOut>();
        Debug.Log("Registered player stats");

        statGuiOutput = gameObject.AddComponent<StatGUIOut>();
        // TODO[matt] this is throwing a fit for never being used, IDK why but it will stop the game from running. . . 
        statGuiOutput.Equals("s");
        return true;
    }

    // Average speed
    // Do this all at once here at the end rather than while stepping, to minimize update time during gameplay
    public void CalculateValues()
    {
        for (int j = 0; j < stats.Length; j++)
        {
            float avg = 0;
            float max = 0;
            Stats S = stats[j];
            float[] speeds = new float[S.Speeds.Count];
            S.Speeds.CopyTo(speeds,0);

            for (int i = 0; i < speeds.Length; i++)
            {
                Debug.Log(i);
                float f = speeds[i];
                //speeds.RemoveFirst();
                avg += f;

                if (f > max)
                {
                    max = f;
                }
            }

            avg = avg / speeds.Length;

            S.AverageSpeed = avg;
            S.MaximumSpeed = max;
            //Quick fix to remove the first 15 that would have been removed given that the previous method of calculations worked.
            for (int k = 0; k < 15; k++) {
                S.Speeds.RemoveFirst();
            }
           
        }

    }

    public void DisplayAll()
    {
        print("Display -------------");
        StatUI statUI = GameObject.FindGameObjectsWithTag("Canvas")[0].GetComponent<StatUI>();
        statUI.Display(stats);
        statOutput.Display(stats);
        
    }
}
