using System;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float barrelSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
            Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        // make barrels move along platforms
        if (other.gameObject.tag == "Platform")
            rb.linearVelocity = other.gameObject.transform.right * barrelSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // destroy barrels at the end of the map
        if (other.gameObject.name == "BarrelDestroyer")
            Destroy(gameObject);
    }
    
    
}
