using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    void Update()
    {
        Vector2 textureOffset = new Vector2(Time.time * scrollSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = textureOffset;
    }
}
