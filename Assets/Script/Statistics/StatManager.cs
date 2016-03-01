using UnityEngine;
using System.Collections;

public class StatManager : MonoBehaviour {

    Stats[] stats;
    private int count;

    private StatOut statOutput;

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

        return true;
    }

    public void DisplayAll()
    {
        print("Display -------------");
        for (int i=0; i<stats.Length; i++)
        {
            statOutput.Display("p" + (i+1) + ":" + stats[i].GetDistance());
        }
    }
}
