using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Patrol : MonoBehaviour
{
    public Transform[] arrWaypoints;
    public float fSpeed;
    public int nCurWaypoint;
    public bool bPatroling = true;
    public Vector3 v3Target;
    public Vector3 v3MoveDir;
    public Vector3 v3Vel;

    private Animator Anim;

    // Use this for initialization
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nCurWaypoint < arrWaypoints.Length)
        {
            v3Target = arrWaypoints[nCurWaypoint].position;
            v3MoveDir = v3Target - transform.position;
            v3Vel = GetComponent<Rigidbody>().velocity;
            float fMagnitude = v3Vel.magnitude;

            if (fMagnitude > 0)
            {
                Anim.SetFloat("Monster", 1.0f);
            }
            else
            {
                Anim.SetFloat("Monster", 0.0f);
            }
            
            if (v3MoveDir.magnitude < 1)
            {
                nCurWaypoint++;
            }
            else
            {
                v3Vel = v3MoveDir.normalized * fSpeed;
            }
        }
        else
        {
            if (bPatroling)
            {
                nCurWaypoint = 0;
            }
            else
            {
                v3Vel = Vector3.zero;
            }
        }
        GetComponent<Rigidbody>().velocity = v3Vel;
        transform.LookAt(v3Target);
    }
}