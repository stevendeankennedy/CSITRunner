using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class menu : MonoBehaviour {
    public GameObject PLAY, ARCADE, STATS;
    private GameObject[] buttons;

	// Use this for initialization
	void Start () {
        buttons = new GameObject[] { PLAY, ARCADE, STATS };
        EventSystem.current.SetSelectedGameObject(PLAY, null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
