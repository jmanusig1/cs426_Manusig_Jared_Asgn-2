using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    //variables that control the speed and rotation speed 
    public float speed = .085f;
    public float rotationSpeed = 2f;

    int jumps = 0;
    public int maxJump = 1;
    public float force = 550f; 

    Rigidbody rb;
    Transform tran;

    public Camera myCam; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tran = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }


        if (myCam.enabled == false)
            myCam.enabled = true; 
        
        //variables for translation adn rotation 
        var r = Input.GetAxis("Horizontal") * rotationSpeed;
        var t = Input.GetAxis("Vertical") * speed;

        transform.Translate(0, 0, t);
        transform.Rotate(0, r, 0);

        if (jumps < maxJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumps += 1;
                rb.AddForce(tran.up * force);
            }
        }

        
        if (Input.GetKey(KeyCode.P))
        {
            rb.AddForce(tran.up * 5f);
        }
        
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumps = 0;
        }
    }
}
