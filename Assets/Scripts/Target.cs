using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour

{
    // Start is called before the first frame update

    public AudioSource correct;

    int count = 0; 

    void Start(){
        correct = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision) {
        // printing if collision is detected on the console
        Debug.Log("Wall Collision Detected");

        count ++; 

        if(correct != null){

            Debug.Log("Playing");
            correct.Play(); 
        }
        else{
            Debug.Log("Empty");
        }
        //after collision is detected destroy the gameobject
        if(count == 2)
            Destroy(gameObject);


    }
}
