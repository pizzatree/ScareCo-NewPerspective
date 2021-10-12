using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingValue = 100f;
    [SerializeField] private bool  allowRevive   = false;
    
    private float currentValue;

    public event Action<float> OnHealthChanged;
    public event Action        OnDeath;

    private void Start()
    {
        currentValue = startingValue;
    }

    public void ChangeHealth(float amount)
    {
        if(!allowRevive && currentValue <= 0f)
            return;

        currentValue = Mathf.Min(currentValue + amount, startingValue);
        OnHealthChanged?.Invoke(currentValue / startingValue);
        
        if(currentValue <= 0f)
            OnDeath?.Invoke();
    }
}