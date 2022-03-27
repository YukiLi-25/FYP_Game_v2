using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Drag : MonoBehaviour
{
    bool startDrag;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startDrag)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void StartDragUI()
    {
        startDrag = true;
    }

    public void StopDragUI()
    {
        startDrag = false;
    }
}
