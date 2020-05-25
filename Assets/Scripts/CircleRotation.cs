using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public float fors = 50;
    void Update()
    {
        transform.Rotate(0, 0, fors * Time.deltaTime);
    }
}
