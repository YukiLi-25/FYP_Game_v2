using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeColor : MonoBehaviour
{
    // Head
    public Color[] headColor;
    public Material headMaterial;

    // Body
    public Color[] bodyColor;
    public Material bodyMaterial;

    public void ChangeHeadColor(int colorIndex)
    {
        headMaterial.color = headColor[colorIndex];
    }
    public void ChangeBodyColor(int colorIndex)
    {
        bodyMaterial.color = bodyColor[colorIndex];
    }
}
