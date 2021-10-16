using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSizeIncreaser : MonoBehaviour
{
    [SerializeField] private float increaseRate = 1.05f;

    private void Start()
        => GetComponent<CurrencyEater>().OnGatewayCleared += () => transform.localScale *= increaseRate;
}