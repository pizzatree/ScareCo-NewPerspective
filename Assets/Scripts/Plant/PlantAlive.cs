using System;
using Lights;
using UnityEngine;

namespace Plant
{
    [SelectionBase, RequireComponent(typeof(Health))]
    public class PlantAlive : MonoBehaviour
    {
        [SerializeField] private float      rateOfDrying = 1f;
        [SerializeField] private GameObject ghostPlant;
        
        private Health         health;
        private SpriteRenderer uiHealth;
        
        private void Start()
        {
            health                 =  GetComponent<Health>();
            health.OnDeath         += HandleOnDeath;
            health.OnHealthChanged += HandleOnHealthChanged;

            uiHealth = GetComponentInChildren<SpriteRenderer>();

            if(uiHealth)
                return;
            
            Debug.LogError($"Add sprite renderer for Health UI on {name}");
            health.OnHealthChanged -= HandleOnHealthChanged;
        }

        private void OnDisable()
        {
            health.OnDeath         -= HandleOnDeath;
            health.OnHealthChanged -= HandleOnHealthChanged;
        }

        private void Update()
        {
            health.ChangeHealth(-rateOfDrying * Time.deltaTime);
        }

        private void OnParticleCollision(GameObject other)
        {
            Water(3f);        
        }

        public void Water(float amount)
        {
            health.ChangeHealth(amount);
        }

        private void HandleOnHealthChanged(float pct)
        {
            uiHealth.color = Color.Lerp(Color.red, Color.green, pct * pct); // pct^2 to accelerate going red
        }

        [ContextMenu("Harakiri")]
        private void HandleOnDeath()
        {
            LightsManager.Instance.ChangeFlickerInZone(transform.position, true);
            Instantiate(ghostPlant, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}