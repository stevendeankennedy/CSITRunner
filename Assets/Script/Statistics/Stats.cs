public class Stats {

    private float stepSize;

    int steps;

    public Stats()
    {
        steps = 0;
        stepSize = 2.5f;
    }

    public void addStep()
    {
        steps++;
    }

    public float getDistance()
    {
        return steps * stepSize;
    }
}
