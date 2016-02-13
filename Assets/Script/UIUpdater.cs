using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUpdater : MonoBehaviour {

    public Runner p1;
    public Runner p2;

    private Text speedText;
    // Use this for initialization
    void Start()
    {
        // TODO: Update this find objects better... this is a temp solution
        speedText = GameObject.FindGameObjectWithTag("UI").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        speedText.text = p1.speed.ToString();
	}
}
