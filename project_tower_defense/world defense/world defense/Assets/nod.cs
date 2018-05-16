using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nod : MonoBehaviour {
    public Color hoverColor;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void onMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    void onMouseExit()
    {
        rend.material.color = startColor;
    }
}
