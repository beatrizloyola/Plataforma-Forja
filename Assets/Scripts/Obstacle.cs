using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject onCollectEffect;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-7.5f, -3.5f, other.transform.position.z);
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}