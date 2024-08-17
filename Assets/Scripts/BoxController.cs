using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private int strength;
    private Animator boxAnimator;
    private Collider2D[] colliders;

    private void Start()
    {
        boxAnimator = GetComponent<Animator>();
        colliders = GetComponents<BoxCollider2D>();

        boxAnimator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            SubtractStrength();
        }
    }

    private void SubtractStrength()
    {
        strength--;

        if (strength <= 0)
        {
            StartCoroutine(DestroyBox()); 
        }
    }

    private IEnumerator DestroyBox()
    {
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        boxAnimator.enabled = true;
        boxAnimator.Play("BoxDestroy", 0, 0f);
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
