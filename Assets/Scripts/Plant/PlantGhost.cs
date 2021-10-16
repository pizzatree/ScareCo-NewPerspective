using System;
using UnityEngine;

namespace Plant
{
    public class PlantGhost : MonoBehaviour
    {
        private Transform target;
        private float     moveSpeed      = 2f;
        private float     followDistance = 3f;
        private float     bounceSpeed    = 3f;
        private float     bounceScale    = 0.3f;
        
        private                  Transform model;

        private void Start()
        {
            target = GameObject.FindWithTag("Player").transform;
            model  = transform.GetChild(0);
            
            var renderers = GetComponentsInChildren<MeshRenderer>();
            foreach(var meshRenderer in renderers)
                ApplyTransparency(meshRenderer);
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
    }
}