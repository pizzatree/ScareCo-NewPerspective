using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private bool ableToExplode;

    public void SetAbleToExplode(bool isAbleTo) => ableToExplode = isAbleTo;

    private void Start()
    {
        ableToExplode = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!ableToExplode)
            return;

        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Hand"))
            return;
        
        if(!(collision.relativeVelocity.magnitude > 0.5))
            return;

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
