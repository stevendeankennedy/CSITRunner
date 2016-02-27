public class Stats {

    private float stepSize;

    int steps;

    public Stats()
    {
        steps = 0;
        stepSize = 2.5f;
    }

    public void AddStep()
    {
        steps++;
    }

    /**
        Number of steps * step size = est. distance travelled
    */
    public float GetDistance()
    {
        return steps * stepSize;
    }
}
