using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {
    public float scroll_Speed = 0.3f;
    private string mainTexture = "_MainTex";

    // get a reference to the mesh renderer
    private MeshRenderer mesh_Renderer;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset(mainTexture);
        offset.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset(mainTexture, offset);
    }
} // class

























