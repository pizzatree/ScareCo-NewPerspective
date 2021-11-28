using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotationChanger : MonoBehaviour
{
    [SerializeField] private GameObject pseudoBody;
    
    private readonly (Vector3 axis, char axisChar)[] axes =
    {
        (Vector3.right, 'x'),
        (Vector3.up, 'y'),
        (Vector3.forward, 'z')
    };

    private int curAxis = 0;

    public char ToggleAxis()
    {
        curAxis = (curAxis + 1) % 3;
        return axes[curAxis].axisChar;
    }

    [ContextMenu("Rotate")]
    public void TestRotate()
        => RotateWorld(90f);
    public void RotateWorld(float value)
    {
        pseudoBody.SetActive(false);
        transform.rotation *= Quaternion.Euler(axes[curAxis].axis * 90f);
        pseudoBody.SetActive(true);
    }

    public void ResetWorld()
    {
        curAxis = 0;
        pseudoBody.SetActive(false);
        transform.rotation = Quaternion.Euler(axes[curAxis].axis);
        pseudoBody.SetActive(true);
    }
}