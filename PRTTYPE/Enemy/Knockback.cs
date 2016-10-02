using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour
{
    private Rigidbody rb;
    private float _knockbackForce = 1000;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.AddForce(-transform.forward * _knockbackForce);
        }
    }
}
