using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections.Generic;

public class StatUI : MonoBehaviour {

    public GameObject statsScreen;
    public GameObject player1Line, player2Line;

    //TODO [Matt] I'm not a fan, look at this system before pushing.
    // I was debating whether or not to use the parent object and make all calls or to just explicitly state all the text object.
    // These are the text boxes for each players stats.
    public Text player1Steps, player1AvgSpeed, player1MaxSpeed, player1TimeTaken;
    private int player1Stepsint;
    private float player1AvgSpeedfloat, player1MaxSpeedfloat, player1TimeTakenfloat;

    public Text player2Steps, player2AvgSpeed, player2MaxSpeed, player2TimeTaken;
    private int player2Stepsint;
    private float player2AvgSpeedfloat, player2MaxSpeedfloat, player2TimeTakenfloat;

    public Text upperSpeedTxt, upperStepTxt;

    //Actual line renderer scripts that will get changed.
    private UILineRenderer player1LR, player2LR;

    private bool animateStats = false;
    float updateCounter = 0;
    //Using this to try and do a count up for when the other stats are displayed.
    void FixedUpdate()
    {
        
        if (animateStats) {
            updateCounter += 0.5f;

            if (updateCounter < player1Stepsint) {
                if (updateCounter + 1 > player1Stepsint) {
                    player1Steps.text = "steps: " + (int)player1Stepsint;
                }
                player1Steps.text = "steps: " + (int)updateCounter;
            }

            if (updateCounter < player2Stepsint)
            {
                if (updateCounter + 1 > player2Stepsint)
                {
                    player2Steps.text = "steps: " + (int)player2Stepsint;
                }
                player2Steps.text = "steps: " + (int)updateCounter;
            }

            // Average speed
            if (updateCounter < player1AvgSpeedfloat)
            {
                if (updateCounter + .01 > player1AvgSpeedfloat)
                {
                    player1AvgSpeed.text = "Average Speed: " + player1AvgSpeedfloat;
                }
                player1AvgSpeed.text = "Average Speed: " + updateCounter;
            }

            if (updateCounter < player2AvgSpeedfloat)
            {
                if (updateCounter + .01 > player2AvgSpeedfloat)
                {
                    player2AvgSpeed.text = "Average Speed: " + player2AvgSpeedfloat;
                }
                player2AvgSpeed.text = "Average Speed: " + updateCounter;
            }

            // Max speed
            if (updateCounter < player1MaxSpeedfloat)
            {
                if (updateCounter + .01 > player1MaxSpeedfloat)
                {
                    player1MaxSpeed.text = "Maximum Speed:: " + player1MaxSpeedfloat;
                }
                player1MaxSpeed.text = "Maximum Speed:: " + updateCounter;
            }

            if (updateCounter < player2MaxSpeedfloat)
            {
                if (updateCounter + .01 > player2MaxSpeedfloat)
                {
                    player2MaxSpeed.text = "Maximum Speed:: " + player2MaxSpeedfloat;
                }
                player2MaxSpeed.text = "Maximum Speed:: " + updateCounter;
            }

            // Time Taken
            if (updateCounter < player1TimeTakenfloat)
            {
                if (updateCounter + .01 > player1TimeTakenfloat)
                {
                    player1TimeTaken.text = "Time Taken: : " + player1TimeTakenfloat;
                }
                player1TimeTaken.text = "Time Taken: : " + updateCounter;
            }

            if (updateCounter < player2TimeTakenfloat)
            {
                if (updateCounter + .01 > player2TimeTakenfloat)
                {
                    player2TimeTaken.text = "Time Taken: : " + player2TimeTakenfloat;
                }
                player2TimeTaken.text = "Time Taken: : " + updateCounter;
            }
        }
    }


    public void activateStatsScreen() {

        statsScreen.SetActive(true);
        player1LR = player1Line.GetComponent<UILineRenderer>();
        player2LR = player2Line.GetComponent<UILineRenderer>();
        animateStats = true;
    }

    //We do all the stuff to populate the UI with stats information
    public void populateStatsScreen(Stats[] stats) {

        //We need to store a bunch of information for numbered stats
        player1Stepsint = stats[0].Steps;
        player1AvgSpeedfloat = stats[0].AverageSpeed;
        player1MaxSpeedfloat = stats[0].MaximumSpeed;
        player1TimeTakenfloat = stats[0].TimeTaken;

        player2Stepsint = stats[1].Steps;
        player2AvgSpeedfloat = stats[1].AverageSpeed;
        player2MaxSpeedfloat = stats[1].MaximumSpeed;
        player2TimeTakenfloat = stats[1].TimeTaken;


        int upper = stats[0].Speeds.Count;
        LinkedListNode<float> p1 = stats[0].Speeds.First;
        LinkedListNode<float> p2 = stats[1].Speeds.First;

        float xPoint = 0;
        float max = 0;
        //This alows us to make the points as big as we want. No documentation to support this method I just kinda eyeballed the way it worked from source and did this. hope it works. . .
        player1LR.Points = new Vector2[upper + 2];
        player2LR.Points = new Vector2[upper + 2];

        //first point 0, 0
        player1LR.Points[0].x = 0;
        player1LR.Points[0].y = 0;

        player2LR.Points[0].x = 0;
        player2LR.Points[0].y = 0;

        if (player1MaxSpeedfloat > player2MaxSpeedfloat)
        {
            int s = (int)player1MaxSpeedfloat;
            upperSpeedTxt.text = s.ToString();
            max = player1MaxSpeedfloat;
        }
        else {
            int s = (int)player2MaxSpeedfloat;
            upperSpeedTxt.text = s.ToString();
            max = player2MaxSpeedfloat;
        }

        if (player1Stepsint > player2Stepsint)
        {
            upperStepTxt.text = player1Stepsint.ToString();
           
        }
        else {
            upperStepTxt.text = player2Stepsint.ToString();
        }

        //TODO[Matt] The top speed constraint isn't working. For whatever reason it isn't staying consistant
        for (int i = 1; i <= upper; i++) {

            //We use the same value for player 1 and 2 so we just do one calculation.
            xPoint = (float)i / upper * 100;
           

            player1LR.Points[i].x = xPoint;
            player1LR.Points[i].y = (float)p1.Value / max * 50;

            player2LR.Points[i].x = xPoint;
            player2LR.Points[i].y = (float)p2.Value / max * 50;

            if (i != upper - 1) {
                p1 = p1.Next;
                p2 = p2.Next;
            }
           
        }

        //Because of the way the render works, we need to make one last point that is the same as the last point.
        //This is because if you don't it tries to cutoff the line by fading off into the distance or something.
        //In short, it looks bad. - My great american novel.
        player1LR.Points[upper + 1].x = xPoint;
        player1LR.Points[upper + 1].y = player1LR.Points[upper].y;

        player2LR.Points[upper + 1].x = xPoint;
        player2LR.Points[upper + 1].y = player2LR.Points[upper].y;


       
        

    }
}
