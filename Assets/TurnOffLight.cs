using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // this.GetComponent<Light> ().enabled = true;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // if (Input.GetKey (KeyCode.UpArrow))
    //     // if (this.gameObject.tag.Equals("Generic Right Grabber"))
    //     //     this.GetComponent<Light> ().enabled = true;
    //     // if (Input.GetKey (KeyCode.DownArrow))
    //     //     this.GetComponent<Light> ().enabled = false;

    //     // if (this.gameObject.tag.Equals("Generic Right Grabber") == true){
    //     if (Input.GetKey (KeyCode.UpArrow)){
    //         this.GetComponent<Light> ().enabled = !(this.GetComponent<Light> ().enabled);
    //         Debug.Log("njkdbnvc");
    //     }
    // }

    void OnCollisionEnter(Collision collision){
        if (collision.collider.name == "bean_knight_interactable" || 
            collision.collider.name == "Interactions.Interactable_bean_knight")
        {
            //Output the message
            Debug.Log("bean knight is here!");
        }
    }
}
