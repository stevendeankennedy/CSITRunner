

using System.Collections.Generic;

public class Stats {

    public float timeTick = 0.25f;
    private float stepSize;

    private LinkedList<float> _speeds;
    public LinkedList<float> Speeds
    {
        get { return _speeds; }
        set { _speeds = value; }
    }
    float startTime;
    float endTime;

    // stats
    private int steps;
    public int Steps
    {
        get { return steps;  }
        set { steps = value; }
    }
    private float averageSpeed;
    public float AverageSpeed
    {
        get { return averageSpeed; }
        set { averageSpeed = value; }
    }
    private float maximumSpeed;
    public float MaximumSpeed
    {
        get { return maximumSpeed; }
        set { maximumSpeed = value; }
    }
    private float timeTaken;
    public float TimeTaken
    {
        get { return timeTaken; }
        set { timeTaken = value; }
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Stats()
    {
        steps = 0;
        stepSize = 2.5f;
        Speeds = new LinkedList<float>();
        startTime = 0f;
        endTime = 0f;
    }

    public void AddStep()
    {
        steps++;
    }

    // add an instance of speed
    public void RegisterSpeed(float speed)
    {
        Speeds.AddLast(speed);
    }

    /**
        Number of steps * step size = est. distance travelled
    */
    public float GetDistance()
    {
        return steps * stepSize;
    }

    // Figure out time taken
    private void CalculateTimeTaken()
    {
        timeTaken = endTime - startTime;
    }

    public void RegisterStartTime(float t)
    {
        startTime = t;
    }

    public void RegisterEndTime(float t)
    {
        endTime = t;
        CalculateTimeTaken();
    }
    
    public override string ToString()
    {
        return "Didn't finish ToString...";
    }
}
