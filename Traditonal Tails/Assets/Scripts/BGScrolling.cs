using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2.0f;
    [SerializeField] private float tileSizeY = 10.0f;
    [SerializeField] private float scrollSpeedIncreaseInterval = 10f;
    [SerializeField] private float scrollSpeedIncrement = 0.1f;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(IncreaseScrollSpeed());
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector2.up * newPosition;
    }

    private IEnumerator IncreaseScrollSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(scrollSpeedIncreaseInterval);
            scrollSpeed += scrollSpeedIncrement;
        }
    }
}