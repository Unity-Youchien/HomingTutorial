using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
    [SerializeField] Transform target;

    Rigidbody2D rb;
    float speed = 5f;
    float rotateSpeed = 200f;

    [SerializeField] GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitEffect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(hitEffect, 0.5f);
        Destroy(gameObject);
    }
}
