using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        Vector2 directionPlayer = (player.position - transform.position).normalized;
        rb.velocity = directionPlayer * speed;
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void CollisionDetected(GameObject obj)
    { 
        if (obj.CompareTag("Player"))
        {
            FindAnyObjectByType<PlayerController>().ReceiveDamage(10);
            Destroy(gameObject);
        }
        else if (obj.CompareTag("Weapon") || obj.CompareTag("Box"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionDetected(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionDetected(collision.gameObject);
    }
}
