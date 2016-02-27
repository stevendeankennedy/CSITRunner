using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Runner player1;
    public Runner player2;

	// Use this for initialization
	void Start () {
        InputHandler ih = gameObject.AddComponent<InputHandler>();
        ih.SetPlayers(player1, player2);

        StatManager sm = gameObject.AddComponent<StatManager>();
        sm.Register(player1, player2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
