using UnityEngine;
//using System.Collections;


public class FloatyRandomFilter : FloatyFilter
{
    private float xClamp;
    private float yClamp;
    private float zClamp;

    public override Floaty Filter(Floaty F)
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(1f, 6f);
        float z = Random.Range(0f, 200f);
        F.transform.position = new Vector3(x, y, z);
        return F;
    }
}
