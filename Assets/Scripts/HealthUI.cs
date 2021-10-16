using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private Health         health;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer         =  GetComponentInChildren<SpriteRenderer>();
        health                 =  GetComponent<Health>();
        health.OnHealthChanged += HandleOnHealthChanged;
        
        if(spriteRenderer)
            return;
            
        Debug.LogError($"Add sprite renderer for Health UI on {name}");
        health.OnHealthChanged -= HandleOnHealthChanged;
    }
    
    private void OnDisable()
    {
        health.OnHealthChanged -= HandleOnHealthChanged;
    }

    
    private void HandleOnHealthChanged(float pct)
    {
        spriteRenderer.color = Color.Lerp(Color.red, Color.green, pct * pct); // pct^2 to accelerate going red
    }
}