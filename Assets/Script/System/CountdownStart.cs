using UnityEngine;
using UnityEngine.UI;

public class CountdownStart : MonoBehaviour {

    // Unity Editor data ----------------------
    [SerializeField, Tooltip("Every message displays. Last one starts")]
    private string[] countdown;
    [SerializeField, Range(0.5f, 5.0f)]
    private float tick;
    [SerializeField, Tooltip("Text field for output")]
    private Text textField;

    private InputHandler _inputHandler;
    public InputHandler InputHandler
    {
        get { return _inputHandler; }
        set { _inputHandler = value; }
    }

    // timer
    private float timer;
    private int count; // count holds index of the NEXT message
    private bool willEnd;
	
    void Start()
    {
        count = 0;
        timer = 0f;
        willEnd = false;
    }

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        // do stuff every tick
        if (timer >= tick)
        {
            if (willEnd) // check for ending this object
            {
                textField.gameObject.SetActive(false);
                enabled = false;
            }
            else // sow next message
            {
                textField.gameObject.SetActive(true);
                textField.text = countdown[count];
            }

            if (count == countdown.Length - 1) // last message
            {
                willEnd = true;
                InputHandler.SetInputOnForAll();
            }
            count++; // move to next message

            timer -= tick; // reset timer
        }
	}
}
