using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Law : MonoBehaviour
{
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            transform.position += new Vector3(0, 0.008f);
        } 
        if (transform.position.y > 620f)
        {
            up = !up;
            
        }
    }
}
