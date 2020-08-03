using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables & References
    public Transform target;
    public Vector3 cameraOffset;
    public float followSpeed = 10f;

    private void FixedUpdate()
    {
        transform.position = target.position + cameraOffset;

    }

}
