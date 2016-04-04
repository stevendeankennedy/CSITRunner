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
            LinkedList<float> speeds = S.Speeds;
            for (int i = 0; i < speeds.Count; i++)
            {
                float f = speeds.First.Value;
                speeds.RemoveFirst();
                avg += f;

                if (f > max)
                {
                    max = f;
                }
            }

            avg = avg / speeds.Count;

            S.AverageSpeed = avg;
            S.MaximumSpeed = max;
        }
    }

    public void DisplayAll()
    {
        print("Display -------------");
        StatUI statUI = GameObject.FindGameObjectsWithTag("Canvas")[0].GetComponent<StatUI>();
        statUI.activateStatsScreen();
        statUI.populateStatsScreen(stats);
        statOutput.Display(stats);
        
    }
}
