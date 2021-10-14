using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject subject;
    
    public void Harakiri() => Destroy(subject);
}
