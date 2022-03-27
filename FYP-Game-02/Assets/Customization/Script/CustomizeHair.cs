using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeHair : MonoBehaviour
{
    public SkinnedMeshRenderer hair;
    public SkinnedMeshRenderer[] hairs;

    public void ChangeHair(int hairIndex)
    {
        hair.sharedMesh = hairs[hairIndex].sharedMesh;
    }
}
