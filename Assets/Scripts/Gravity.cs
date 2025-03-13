using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.00674f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Attract(Gravity other)
    {
       Rigidbody otherRb = other.rb;

        Vector3 direction = otherRb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagnitue = G * ((rb.mass * otherRb.mass) / Mathf.Pow (distance, 2));
        Vector3 finalForce = forceMagnitue * direction.normalized;
        
        otherRb.AddForce(finalForce);

    }




}
