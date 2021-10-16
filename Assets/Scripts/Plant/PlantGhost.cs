using UnityEngine;

namespace Plant
{
    public class PlantGhost : MonoBehaviour
    {
        private Transform target;
        private float     moveSpeed      = 2f;
        private float     followDistance = 2f;
        private float     bounceSpeed    = 3.5f;
        private float     bounceScale    = 0.45f;
        
        private                  Transform model;

        private void Start()
        {
            target           = GameObject.FindWithTag("Player").transform;
            model            = transform.GetChild(0);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            var renderers = GetComponentsInChildren<MeshRenderer>();
            foreach(var meshRenderer in renderers)
                ApplyTransparency(meshRenderer);

            bounceScale    *= Random.Range(0.75f, 1.25f);
            bounceSpeed    *= Random.Range(0.75f, 1.25f);
            moveSpeed      *= Random.Range(0.75f, 1.25f);
            followDistance *= Random.Range(0.50f, 1.75f);
        }

        private void LateUpdate()
        {
            transform.LookAt(target);
            model.localPosition = new Vector3(0f, Mathf.Sin(Time.time * bounceSpeed) * bounceScale, 0f);
            
            if(Vector3.Distance(transform.position, target.position + Vector3.up) <= followDistance)
                return;
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        private void ApplyTransparency(MeshRenderer meshRenderer)
        {
            var mats = meshRenderer.materials;

            foreach(var mat in mats)
                mat.color = new Color(1, 1, 1, 0.25f);

            meshRenderer.materials = mats;
        }

        public void Harakiri()
            => Destroy(gameObject);
    }
}