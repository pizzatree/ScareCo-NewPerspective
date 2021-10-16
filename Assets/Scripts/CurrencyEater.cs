using System;
using UnityEngine;

public class CurrencyEater : MonoBehaviour, IDispenserGateway
{
    [SerializeField] private string currencyName = "Quarter";
    
    public event Action OnGatewayCleared;

    private void OnCollisionEnter(Collision other)
    {
        var isProperCurrency = other.collider.tag.Equals(currencyName);
        if(!isProperCurrency)
            return;
        
        OnGatewayCleared?.Invoke();
        other.collider.GetComponent<Destroyer>().Harakiri();
    }
}
