using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockIn : MonoBehaviour
{
    [SerializeField] private float tolerance = 3f;

    private Vector3    startingPos;
    private Quaternion startingRot;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        startingRot = transform.rotation;
    }

    public void CheckLockin()
    {
        if(Vector3.Distance(startingPos, transform.position) >= tolerance)
            return;

        transform.position = startingPos;
        transform.rotation = startingRot;
    }
}