using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraPlayerPosition;

    void FixedUpdate()
    {
        transform.position = new Vector3(cameraPlayerPosition.transform.position.x,
                                         cameraPlayerPosition.transform.position.y,
                                         transform.position.z);
    }
}
