using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 90f;
    [SerializeField] private float rotationSpeedChangeInterval = 5f;
    [SerializeField] private float rotationSpeedIncrement = 10f;

    void Start()
    {
        StartCoroutine(ChangeRotationSpeed());
    }

    void Update()
    {
        float z = Mathf.Sin(Time.time) * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    private IEnumerator ChangeRotationSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(rotationSpeedChangeInterval);
            rotationSpeed += rotationSpeedIncrement;
        }
    }
}