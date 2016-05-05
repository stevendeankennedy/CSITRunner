using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    [HideInInspector]
    public Runner player1;
    [HideInInspector]
    public Runner player2;

    public AudioSource StepAudio;

    public CrossScreenHelper crossScreenPrefab;

    private GameObject[] G;
    private bool hasWinner;
    private int finishCount = 0;
    private bool displayStats = true;

    private UIUpdater uiUpdater;
    private StatManager sm;
    private InputHandler ih;
    private CharacterCache characterCache;

	// Use this for initialization
	void Start () {
        Debug.Log("Game Manager Starting...");

        //Make sure our cross screen exists, and make it usable
        G = GameObject.FindGameObjectsWithTag("CrossScreenHelper");
        //Cross Scene stuff
        if (G.Length == 0)
        {
            Instantiate(crossScreenPrefab);
            // Lazy way.
            G = GameObject.FindGameObjectsWithTag("CrossScreenHelper");
        }
        else{
            GetComponent<CharacterCache>().prefabs[0] = G[0].GetComponent<CrossScreenHelper>().getPlayer1();
            GetComponent<CharacterCache>().prefabs[1] = G[0].GetComponent<CrossScreenHelper>().getPlayer2();
        }



        // Load default characters
        characterCache = GetComponent<CharacterCache>();
        // Instantiate the objects
        characterCache.startUp();
        player1 = characterCache.GetRunner();
        player2 = characterCache.GetRunner();
        RunnerCam[] cams = GetComponentsInChildren<RunnerCam>();
        cams[0].runner = player1.transform;
        cams[1].runner = player2.transform;
        // set starting positions
        player1.transform.position = new Vector3(-1.5f, player1.preferredY, 0f);
        player2.transform.position = new Vector3(1.5f, player2.preferredY, 0f);
        // activate
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
        // set numbers
        player1.Player = 1;
        player2.Player = 2;
        ih = gameObject.AddComponent<InputHandler>();
        ih.SetPlayers(player1, player2);
        ih.SetAudio(StepAudio);

        sm = gameObject.AddComponent<StatManager>();

        uiUpdater = FindObjectOfType<UIUpdater>(); // TODO: Change this load...
        uiUpdater.SetRunners(player1, player2);

        CountdownStart countdown = GetComponent<CountdownStart>();
        countdown.InputHandler = ih; // register ih

        FloatyFactory fFact = gameObject.GetComponent<FloatyFactory>();
        GameObject floatyContainer = new GameObject("AllFloaties");
        Floaty[] Fs = fFact.GetAllFloaties();
        for (int i=0; i<Fs.Length; i++)
        {
            Fs[i].transform.SetParent(floatyContainer.transform);
        }
        floatyContainer.transform.SetParent(gameObject.transform);


        

        

        Debug.Log("Game Manager done with Start()");
	}
    
    public void CrossFinishLine(Runner r)
    {
        Debug.Log(r.name + " has crossed the finish line.");
        if (!hasWinner) {
            hasWinner = true;
            // TODO: Move this to updates
            Debug.Log(r.name + " wins!");
            uiUpdater.ShowWinner(transform.position);
            sm.Register(player1, player2);
            Animator a = r.GetComponent<Animator>();
            a.SetBool("didWin", true);
        }
        finishCount = finishCount + 1;
        ih.SetInput(r.Player, false); // turn off input
    }

    void FixedUpdate()
    {
        // wait a while
        if (!hasWinner)
            return;

        if (displayStats && finishCount >= 2)
        {
            displayStats = false;
            sm.CalculateValues();
            sm.DisplayAll();
        }
    }

    public void ChangeLevel(int level) {
        if (level == 0)
        {
            G[0].GetComponent<CrossScreenHelper>().ChangeLevelMenu();
        }
        else {
            G[0].GetComponent<CrossScreenHelper>().ChangeLevelArcade();
        }
    }
}
