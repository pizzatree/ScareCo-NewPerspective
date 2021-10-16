using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(!(collision.relativeVelocity.magnitude > 0.5))
            return;
        
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
