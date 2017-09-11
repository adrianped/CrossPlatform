using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool isOnGround = true;
    public int speed = 10;
    private Rigidbody Rb;
    private Animator Animate;

    // Use this for initialization
    void Start()
    {
        Animate = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody>();
        Rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 250.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        //Vector3 v3VelPost = Rb.velocity;
        Vector3 v3VelPost = Rb.velocity;

        if (Input.GetKey(KeyCode.W))
        {
            Rb.velocity = Rb.velocity + gameObject.transform.forward * Time.deltaTime * 30000;
            Debug.Log(Rb.velocity);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Rb.velocity = Rb.velocity + (gameObject.transform.forward * -1) * 3;
        }

        if (Input.GetKey(KeyCode.Space))
        {

            //Debug.DrawLine(transform.position + Vector3.up, transform.position + Vector3.down * 5);
            if (isOnGround == true)
            {
                //transform.Translate(transform.up * 200 * Time.deltaTime, Space.World);
                Vector3 v3VelPos = Rb.velocity; 
                Rb.velocity = new Vector3(v3VelPos.x, 10, v3VelPos.z);
                isOnGround = false;
            }
        }
        Animate.SetFloat("Speed", Rb.velocity.magnitude);
        Animate.SetBool("Jump", isOnGround == false);
        Rb.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ground");
        isOnGround = true;
    }
}

