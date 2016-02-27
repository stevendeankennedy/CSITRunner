using UnityEngine;
using System.Collections;

public class StatManager : MonoBehaviour {

    Stats[] stats;
    private int count;

    private StatOut statOutput;

    void Awake()
    {
        statOutput = gameObject.AddComponent<StatConsoleOut>();
    }

    public bool Register(params Runner[] players)
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
            stats[i] = players[i].Stats();
        }
        return true;
    }

    public void DisplayAll()
    {
        for (int i=0; i<stats.Length; i++)
        {
            statOutput.Display("p" + i + ":" + stats[i].GetDistance());
        }
    }
}
