using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool isOnGround = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKey(KeyCode.Space))
        {
           
            //Debug.DrawLine(transform.position + Vector3.up, transform.position + Vector3.down * 5);
            if(isOnGround == true)
            {
                transform.Translate(Vector3.up * 200 * Time.deltaTime, Space.World);
                isOnGround = false;
            }
        }

        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ground");
        isOnGround = true;
    }
}
