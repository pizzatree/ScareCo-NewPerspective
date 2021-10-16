using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingValue = 100f;
    [SerializeField] private bool  allowRevive   = false;

    private bool  dead;
    private float currentValue;

    public event Action<float> OnHealthChanged;
    public event Action        OnDeath;
    public event Action        OnRevive;

    private void Start()
    {
        dead         = false;
        currentValue = startingValue;
    }

    public void ChangeHealth(float amount)
    {
        if(dead && !ValidDeadHealthChange(amount))
            return;

        currentValue = Mathf.Min(currentValue + amount, startingValue);
        OnHealthChanged?.Invoke(currentValue / startingValue);

        if(currentValue <= 0f)
        {
            dead = true;
            OnDeath?.Invoke();
        }
    }

    private bool ValidDeadHealthChange(float amount)
    {
        if(!allowRevive || amount < 1f)
            return false;

        dead = false;
        OnRevive?.Invoke();
        return true;
    }

    [ContextMenu("Reduce Health")]
    private void DemoReduce() => ChangeHealth(-5f);

    [ContextMenu("Increase Health")]
    private void DemoIncrease() => ChangeHealth(5f);
}