using System;
using System.Collections;
using System.Collections.Generic;
using Tilia.Locomotors.Teleporter;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    [SerializeField] private GameObject pseudoBody;
    private                  Transform  spawnPoint;

    [SerializeField]
    private Vector2 xBounds, yBounds, zBounds;

    private int fallCount;
    
    private void Start()
    {
        fallCount  = 0;
        spawnPoint = GameObject.Find("Spawn Point").transform;
    }

    private void Update()
    {
        if(transform.position.x >= xBounds.y || transform.position.x <= xBounds.x)
            ResetPos();
        if(transform.position.y >= yBounds.y || transform.position.y <= yBounds.x)
            ResetPos();
        if(transform.position.z >= zBounds.y || transform.position.z <= zBounds.x)
            ResetPos();
    }

    [ContextMenu("Reset Pos")]
    public void ResetPos()
    {
        CancelInvoke(nameof(ResetFallcount));
        Invoke(nameof(ResetFallcount), 5f);
        
        if(++fallCount >= 3)
        {
            FindObjectOfType<WorldRotationChanger>().ResetWorld();
            fallCount = 0;
        }
        
        pseudoBody.SetActive(false);
        transform.position = spawnPoint.position;
        pseudoBody.SetActive(true);
    }

    private void ResetFallcount()
    {
        fallCount = 0;
    }
}