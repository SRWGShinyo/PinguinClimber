using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRotate : MonoBehaviour
{
    float rotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate += Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 + rotate));
    }
}
