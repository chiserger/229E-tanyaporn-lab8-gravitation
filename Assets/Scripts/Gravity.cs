using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f;
    public static List<Gravity> gravityObjectList;
    [SerializeField] bool planet = false;
    [SerializeField] int orbitSpeed = 10000;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (gravityObjectList == null )
        {
            gravityObjectList = new List<Gravity> ();
        }
        gravityObjectList.Add( this );  

        if (!planet)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
    }

    private void FixedUpdate()
    {
        foreach ( var planets in gravityObjectList )
        {
            if (planets != this)
            {
                Attract(planets);
            }

        }
    }

    void Attract(Gravity other)
    {
       Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagnitue = G * ((rb.mass * otherRb.mass) / Mathf.Pow (distance, 2));
        Vector3 finalForce = forceMagnitue * direction.normalized;
        
        otherRb.AddForce(finalForce);

    }




}
