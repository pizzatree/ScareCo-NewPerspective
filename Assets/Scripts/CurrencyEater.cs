using System;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyEater : MonoBehaviour, IDispenserGateway
{
    [SerializeField] private string currencyName = "Quarter";
    
    public event Action OnGatewayCleared;
    public UnityEvent   OnGatewayClearedVisual;

    private void OnCollisionEnter(Collision other)
    {
        var isProperCurrency = other.collider.tag.Equals(currencyName);
        if(!isProperCurrency)
            return;
        
        OnGatewayCleared?.Invoke();
        OnGatewayClearedVisual?.Invoke();
        other.collider.GetComponent<Destroyer>().Harakiri();
    }
}
