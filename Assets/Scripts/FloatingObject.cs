using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [SerializeField] private float speed    = 3f;
    [SerializeField] private float distance = .35f;

    private Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void Update()
    {
        transform.position = startingPos + new Vector3(0f, Mathf.Sin(Time.time * speed) * distance, 0f);
    }
}