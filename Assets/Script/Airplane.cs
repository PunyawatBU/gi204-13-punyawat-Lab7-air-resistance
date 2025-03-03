using System;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;
    [SerializeField] public float enginePower = 20f;
    [SerializeField] public float liftBooster = 0.5f;
    [SerializeField] public float angularDrag = 0.001f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);
    }
}
