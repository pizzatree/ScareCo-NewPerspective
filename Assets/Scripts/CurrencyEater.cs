using System;
using UnityEngine;

public class CurrencyEater : MonoBehaviour
{
    [SerializeField] private string currencyName = "Quarter";
    
    public event Action OnReceivedCurrency;

    private void OnCollisionEnter(Collision other)
    {
        var isProperCurrency = other.collider.tag.Equals(currencyName);
        if(!isProperCurrency)
            return;
        
        OnReceivedCurrency?.Invoke();
        other.collider.GetComponent<Destroyer>().Harakiri();
    }
}
