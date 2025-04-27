using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    private float currentPositionX;
    private float currentPositionY;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.5f;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, currentPositionY, transform.position.z), ref velocity, smoothTime);
    }
    public void ChangeCameraPosition(Transform newRoom)
    {
        currentPositionX = newRoom.position.x;
        currentPositionY = newRoom.position.y;
    }
}
