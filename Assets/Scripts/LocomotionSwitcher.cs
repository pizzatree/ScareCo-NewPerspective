using System;
using TMPro;
using UnityEngine;

public class LocomotionSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject teleportMovement,
                                        continuousMovement;

    private TextMeshProUGUI computerText;

    private bool  teleport;
    private float nextChangeTime;

    private void Start()
    {
        computerText = GetComponentInChildren<TextMeshProUGUI>();

        nextChangeTime = 0f;
        teleport       = false;
        ChangeLocomotion(); // start as teleport
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeLocomotion();
    }
    
    private void ChangeLocomotion()
    {
        if(nextChangeTime > Time.time)
            return;
        
        teleport = !teleport;
        
        var nextLocomotionType = teleport ? "continuous" : "teleport";
        var newText = $"Change locomotion \n" +
                      $"to <color=\"red\">{nextLocomotionType}</color> by pressing on me!";
        computerText.text = newText;

        teleportMovement.SetActive(teleport);
        continuousMovement.SetActive(!teleport);

        nextChangeTime = Time.time + 2f;
    }
}