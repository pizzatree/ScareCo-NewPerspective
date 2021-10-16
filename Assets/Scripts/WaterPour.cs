using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPour : MonoBehaviour
{
    [SerializeField] private float       pourRate = 5.0f;
    [SerializeField] private AudioSource popSound;
    [SerializeField] private GameObject  explosion;

    private ParticleSystem waterParticle;
    private Health         health;

    private bool readyToDie;

    private void Start()
    {
        waterParticle = GetComponentInChildren<ParticleSystem>();
        health        = GetComponent<Health>();

        health.OnDeath += SetReadyForDeath;
    }

    private void OnDisable()
    {
        health.OnDeath -= SetReadyForDeath;
    }

    private void Update()
    {
        if(readyToDie)
        {
            waterParticle.Stop();
            return;
        }        
        
        var tippedOver = transform.up.y <= 0.7f;

        if(tippedOver && !waterParticle.isPlaying)
            waterParticle.Play();

        if(!tippedOver)
            waterParticle.Stop();
        else
            health.ChangeHealth(-pourRate * Time.deltaTime);
    }

    public void CheckDeath() // To be called by VRTK Ungrabbed Event
    {
        if(readyToDie)
            sheDead();
    }

    private void SetReadyForDeath()
        => readyToDie = true;

    private void sheDead()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        
        popSound = GetComponentInChildren<AudioSource>();
        popSound.Play();
        
        Destroy(gameObject.transform.parent.parent.gameObject);
    }
}