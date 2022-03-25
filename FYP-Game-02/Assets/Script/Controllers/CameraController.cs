using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    //set Camera position
    public Vector3 offset;

    public float pitch = 2f;

    //zoom in & zoom out
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float currentZoom = 10f;

    //rota with player
    public float yawSpeed = 100f;
    private float currentYaw = 10f;

    void Update()
    {
        //zoom in & zoom out
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //rota with player
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        //zoom in & zoom out
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //rota with player
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
