using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    private GameObject deskLight;
    public Light ptLight;
    // Start is called before the first frame update
    void Start()
    {
        deskLight = GameObject.Find("Interactions.Interactable_desk_light");
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetKeyUp(KeyCode.Space))
    //     {
    //         ptLight.enabled = !ptLight.enabled;
    //     }
    // }


    void OnCollisionEnter(Collision collision){
        // if (collision.collider.name == "Input.UnityInputManager.Oculus.TouchRightController" ||
        //     collision.collider.name == "Generic Right Grabber"){
                
        //         ptLight.enabled = !ptLight.enabled;
        //     }
        ptLight.enabled = !ptLight.enabled;
    }
}
