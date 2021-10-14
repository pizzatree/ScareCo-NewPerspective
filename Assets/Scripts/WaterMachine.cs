using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMachine : MonoBehaviour
{
    [Header("Water Spawn")] 
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private Transform  spawnPoint;

    [Header("Button")] 
    [SerializeField] private Transform button;
    [SerializeField] private float     buttonThreshold = 0.1f;

    private bool    isActivated;
    private Vector3 buttonStartPos;

    private void Start()
    {
        buttonStartPos = button.localPosition;
    }

    private void Update()
    {
        var pos = button.localPosition;
        pos.z                = Mathf.Clamp(pos.z, buttonStartPos.z - buttonThreshold, buttonStartPos.z);
        button.localPosition = pos;

        var buttonActuated = Mathf.Abs(Vector3.Distance(buttonStartPos, button.localPosition)) > buttonThreshold * 0.5f;

        if(isActivated && buttonActuated)
            return;

        if(buttonActuated)
        {
            isActivated = true;
            DispenseWater();
            return;
        }

        isActivated = false;
    }

    private void DispenseWater()
    {
        Instantiate(waterPrefab, spawnPoint.position, transform.rotation);
    }
}