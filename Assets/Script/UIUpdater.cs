using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUpdater : MonoBehaviour {

    private static UIUpdater _instance;

    public static UIUpdater instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIUpdater>();
            }
            return _instance;
        }
    }

    public Runner p1;
    public Runner p2;

    public Text p1Speed;
    public Text p2Speed;

    public Image winMessage;

    // Use this for initialization
    //void Start()
    //{

    //}

    // Update is called once per frame
    void FixedUpdate () {
        p1Speed.text = p1.speed.ToString();
        p2Speed.text = p2.speed.ToString();
	}

    public void ShowWinner(Vector3 pos)
    {
        winMessage.gameObject.SetActive(true);
    }
}
