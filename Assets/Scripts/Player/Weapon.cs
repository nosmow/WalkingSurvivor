using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Controls controls;

    private Animator weaponAnimator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private bool canAttack = true;

    private void Awake()
    {
        controls = new();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        weaponAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    void Update()
    {
        if (controls.Base.Attack.triggered && canAttack)
        {
            StartCoroutine(Attacking());
        }       
    }

    private IEnumerator Attacking()
    {
        canAttack = false;
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        weaponAnimator.Play("Weapon", 0, 0f);

        yield return new WaitForSeconds(0.25f);

        canAttack = true;
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    private void CollisionDetected(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
           // FindAnyObjectByType<EnemyController>().ReceiveDamage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionDetected(collision.gameObject);
    }
}
