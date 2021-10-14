using System;
using UnityEngine;

public class QuarterEater : MonoBehaviour
{
    public event Action OnReceivedQuarter;

    private void OnCollisionEnter(Collision other)
    {
        var isQuarter = other.collider.tag.Equals("Quarter");
        if(!isQuarter)
            return;
        
        OnReceivedQuarter?.Invoke();
        Destroy(other.collider.gameObject);
    }
}
