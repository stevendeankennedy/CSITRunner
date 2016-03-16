using UnityEngine;
//using System.Collections;

public class FloatyFactory : MonoBehaviour {

    public Floaty FloatyPrefab;
    [Tooltip("How many Floaties to load at Start")]
    public int FloatyCacheSize;
    private Floaty[] cache;
    private int nUsed; // number of Floaties out there

    // Filter
    private FloatyFilter filter;

    [Header("Filter Values")]
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public Vector3 maxTorque;

    void Awake() {
#if UNITY_EDITOR
        if (FloatyPrefab == null)
        {
            Debug.Log("Missing Floaty Prefab");
        }
#endif
        // create a cache
        cache = new Floaty[FloatyCacheSize];
        for (int i=0; i<cache.Length; i++)
        {
            cache[i] = Instantiate(FloatyPrefab);
            cache[i].gameObject.SetActive(false);
        }
        nUsed = 0;

        // TODO:  Currently, only using Random Filter
        FloatyRandomFilter FR = gameObject.AddComponent<FloatyRandomFilter>();
        FR.SetValues(minPosition, maxPosition, maxTorque);
        filter = FR;

        Debug.Log("FloatyFactory ready with cache size: " + FloatyCacheSize);
    }

    // return a Floaty
    public Floaty GetFloaty()
    {
        if (nUsed == cache.Length)
        {
            Debug.Log("No more floaties to load");
            return null;
        }
        Floaty F = cache[nUsed++];
        filter.Filter(F);
        F.gameObject.SetActive(true);

        return F;
    }

    // Get all unused Floaties.  Factory will be useless until Floaties are recycled
    public Floaty[] GetAllFloaties()
    {
        Floaty[] R = new Floaty[FloatyCacheSize - nUsed]; // is this number right?

        for (int i=0; i<R.Length; i++)
        {
            R[i] = GetFloaty();
        }
        return R;
    }

    // TODO: Recycle Floaties
}
