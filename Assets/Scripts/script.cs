using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{   
    public AudioSource audSrc;

    int count = 0; 
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision){
        
        count++;
        if(count % 2 == 0){
            gameObject.GetComponent<Renderer> ().material.color = Color.green;
        }
        else{
            gameObject.GetComponent<Renderer> ().material.color = Color.blue;
        }

        if(!audSrc.isPlaying){
                audSrc.Play(); 
            }
    
        if (collision.gameObject.tag == "cat"){

            Debug.Log("cat collide");
            if(!audSrc.isPlaying){
                audSrc.Play(); 
            }
        }
    }
}
