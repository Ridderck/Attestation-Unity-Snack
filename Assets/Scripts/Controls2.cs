using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls2 : MonoBehaviour
{
    public Vector3 Velocity;
    public float Sensitivity;
    private void FixedUpdate()
    {
        Vector3 motion = Velocity * Time.deltaTime;
        transform.position += motion;

        

    }
}
