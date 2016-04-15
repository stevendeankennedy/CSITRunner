using UnityEngine;
//using System.Collections;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour {
    public Color color = Color.white;

    private SpriteRenderer spriteRenderer;
    MaterialPropertyBlock mpb;

    void Awake()
    {
        mpb = new MaterialPropertyBlock();
    }

    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateOutline(true);
    }
    
    void OnDisable()
    {
        UpdateOutline(false);
    }

	// Update is called once per frame
	void Update () {
        UpdateOutline(true);
	}

    void UpdateOutline(bool outline)
    {
        //MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        spriteRenderer.SetPropertyBlock(mpb);
    }
}
