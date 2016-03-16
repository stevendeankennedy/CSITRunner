using UnityEngine;
//using System.Collections;


public class FloatyRandomFilter : FloatyFilter
{
    private Vector3 minPosition;
    private Vector3 maxPosition;
    private Vector3 maxTorque;

    public override Floaty Filter(Floaty F)
    {
        if ((minPosition == null) || (maxPosition == null) || (maxTorque == null))
            SetTestValues();
        float x = Random.Range(minPosition.x, maxPosition.x);
        float y = Random.Range(minPosition.y, maxPosition.y);
        float z = Random.Range(minPosition.z, maxPosition.z);
        F.transform.position = new Vector3(x, y, z);

        float tx = Random.Range(0f, maxTorque.x);
        float ty = Random.Range(0f, maxTorque.y);
        float tz = Random.Range(0f, maxTorque.z);

        Vector3 rTorque = new Vector3(tx, ty, tz);
        F.torque = rTorque;
        return F;
    }

    // set vector ranges
    public void SetValues(Vector3 minPos, Vector3 maxPos, Vector3 maxTorque)
    {
        minPosition = minPos;
        maxPosition = maxPos;
        this.maxTorque = maxTorque;
    }

    // this should never be called...
    private void SetTestValues()
    {
        minPosition = new Vector3(-20f, -5f, 0f);
        maxPosition = new Vector3(20f, 50f, 1000f);
        maxTorque = new Vector3(0f, 3f, 2f);
    }
}
