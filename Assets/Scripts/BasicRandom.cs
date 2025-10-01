using AutoBattler.Utils;
using VContainer;

public class BasicRandom : IRandom
{
    private System.Random rnd;
    [Inject]
    public BasicRandom()
    {
        rnd = new System.Random();
    }
    public BasicRandom(int seed)
    {
        rnd = new System.Random(seed);
    }
    public IRandom CreateOtherInstance()
    {
        return new BasicRandom(rnd.Next());
    }

    public float GetRange(float min, float max)
    {
        return (float)(rnd.NextDouble() * (max - min) + min);
    }

    public int GetRange(int minInclusive, int maxExclusive)
    {
        return rnd.Next(minInclusive, maxExclusive);
    }
}
