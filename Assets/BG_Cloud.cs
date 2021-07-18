using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Cloud : MonoBehaviour
{
    Vector3 cloudPos;
    float cloudPosX ;
    float cloudPosY ;
    void Start()
    {
        cloudPosX = transform.position.x;
        cloudPosY = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        cloudPosX += 0.03f;
        transform.position = new Vector3(cloudPosX, cloudPosY);
        if (cloudPosX > 1600f)
        {
            Debug.Log(cloudPosX);
            cloudPosX = -1406f;
        }
    }
}
