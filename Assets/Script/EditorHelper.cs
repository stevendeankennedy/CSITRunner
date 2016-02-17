using UnityEngine;
using System.Collections;

public class EditorHelper : MonoBehaviour {

    public GroundManager gm;
	
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i=0; i<GroundManager.nActives; i++)
        {
            Vector3 pos = new Vector3(0, 0, i * gm.tileSize);
            Gizmos.DrawWireCube(pos, new Vector3(gm.tileSize, 0.2f, gm.tileSize));
        }
    }
}
