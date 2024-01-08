using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public float rotationSpeed = 90f;
    void Update()
    {
        float z = Mathf.Sin(Time.time) * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
