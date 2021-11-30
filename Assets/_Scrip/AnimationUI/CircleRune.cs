using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRune : MonoBehaviour
{
    public float speed;
    public float Direction;
    private Vector3 circleEulers;
    void Start()
    {
        circleEulers = new Vector3(0, 0, Direction);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(circleEulers * speed * Time.deltaTime );
    }
}
