using Lights;
using UnityEngine;

namespace Plant
{
    [SelectionBase, RequireComponent(typeof(Health))]
    public class PlantAlive : MonoBehaviour
    {
        [SerializeField] private float      rateOfDrying = 1f;

        private Health health;

        private void Start()
        {
            health         =  GetComponent<Health>();
            health.OnDeath += HandleOnDeath;
        }

        private void OnDisable()
            => health.OnDeath -= HandleOnDeath;

        private void Update()
            => health.ChangeHealth(-rateOfDrying * Time.deltaTime);

        private void OnParticleCollision(GameObject other)
            => Water(3f);

        private void Water(float amount)
            => health.ChangeHealth(amount);

        [ContextMenu("Harakiri")]
        private void HandleOnDeath()
        {
            LightsManager.Instance.ChangeFlickerInZone(transform.position, true);
            CreateGhost();
        }

        private void CreateGhost()
        {
            var model = transform.Find("Model");

            var ghost = Instantiate(model, transform.position + Vector3.up, Quaternion.identity).gameObject;
            ghost.AddComponent<PlantGhost>();
            ghost.name = $"{name}'s ghost";
        }
    }
}