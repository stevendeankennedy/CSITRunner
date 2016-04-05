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

    private Runner p1;
    private Runner p2;

    public Text p1Speed;
    public Text p2Speed;

    public Image winMessage;


    // FixedUpdate is called less often
    void FixedUpdate () {
        if (p1 == null || p2 == null)
            return;
        p1Speed.text = p1.speed.ToString();
        p2Speed.text = p2.speed.ToString();
	}

    public void ShowWinner(Vector3 pos)
    {
        winMessage.gameObject.SetActive(true);
    }

    public void SetRunners(Runner one, Runner two)
    {
        p1 = one;
        p2 = two;
    }
}
