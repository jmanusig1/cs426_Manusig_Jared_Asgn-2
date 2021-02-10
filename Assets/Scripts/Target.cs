using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision) {
        // printing if collision is detected on the console
        Debug.Log("Wall Collision Detected");
        //after collision is detected destroy the gameobject
        Destroy(gameObject);
    }
}
