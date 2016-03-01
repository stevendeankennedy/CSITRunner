using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class menu : MonoBehaviour {
    public Button PLAY, ARCADE, STATS, CHARSELECT1, CHARSELECT2;
    public Text PROMPT;
    private LinkedListNode<Button> currentButton;
    private LinkedList<Button> mainMenuButtons, charSelectButtons;
    private bool player1Select = true;
    //0 is main menu, 1 is char select
    private ScreenState ScreenStateVariable;

    private enum ScreenState{
        MainMenu,
        CharSelect
    }

    // Use this for initialization
    void Start() {
        ScreenStateVariable = ScreenState.MainMenu;
        //there is no circualar linked list and I think this implementation would be cleaner.
        mainMenuButtons = new LinkedList<Button>();
        mainMenuButtons.AddFirst(STATS);
        mainMenuButtons.AddFirst(ARCADE);
        mainMenuButtons.AddFirst(PLAY);
        charSelectButtons = new LinkedList<Button> ();
        charSelectButtons.AddFirst(CHARSELECT2);
        charSelectButtons.AddFirst(CHARSELECT1);
 

        currentButton = mainMenuButtons.First;
        currentButton.Value.Select();

    }
	
	// Update is called once per frame
	void Update () {
        //player1 enter
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentButton.Value.onClick.Invoke();
        }
        //Player 1 back.
        else if (Input.GetKeyDown(KeyCode.Q)) {

        }
        //player1 down
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (ScreenStateVariable == ScreenState.MainMenu)
            {
                //move down
                //this is a fancy way to just pull back to the begining of the list since circular linked lists are not a built in data type.
                //Credit for this little hack is http://stackoverflow.com/a/7332084
                currentButton = currentButton.Next ?? currentButton.List.First;
                currentButton.Value.Select();
            }
            else {
                //move down
                //Shouldn't do anythign on the char menu
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (ScreenStateVariable == ScreenState.MainMenu)
            {
                //move up
                currentButton = currentButton.Previous ?? currentButton.List.Last;
                currentButton.Value.Select();
            }
            else {
                //move up
                //Shouldn't do anythign on the char menu
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (ScreenStateVariable == ScreenState.MainMenu)
            {
                //move right
                //won't do anything on the main menu buttons.

            }
            else {
                //move right
                currentButton = currentButton.Previous ?? currentButton.List.Last;
                currentButton.Value.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (ScreenStateVariable == ScreenState.MainMenu)
            {
                //move left
                //won't do anything on the main menu buttons.

            }
            else {
                //move left
                currentButton = currentButton.Previous ?? currentButton.List.Last;
                currentButton.Value.Select();
            }
        }
    }

    public void CharSelect() {

        //set up so we now are slecting blocks from the character select screen.
        currentButton = charSelectButtons.First;
        currentButton.Value.Select();
        ScreenStateVariable = ScreenState.CharSelect;
    }

    /*
    character was picked, now we can let P2 pick.
    TODO[Matt] Consider revising this system so that we can do siultanious picks/different colors during player picks.
    */
    public void CharacterChosen(int selection) {
        if (player1Select == true)
        {
            //The buttons in unity know what integer they corespond to.
           
            FindObjectOfType<CrossScreenHelper>().setPlayer1Char(selection);
            player1Select = false;
            PROMPT.text = "Player 2 Choose your character!";
        }
        else {
            //The buttons in unity know what integer they corespond to.
            FindObjectOfType<CrossScreenHelper>().setPlayer2Char(selection);

            //Logic to start the scene with the selected characters. currently tied to the arcade scene.
            //TODO [Matt] switch this so that it goes to the final game scene.
            FindObjectOfType<CrossScreenHelper>().ChangeLevelArcade();
        }
    }
}
