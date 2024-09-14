using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AvoidanceBehavior : IBehaviourNode
{
    private IAController iaController;
    private float avoidanceRadius = 1.5f;
    private float avoidanceStrength = 3f;

    private Animator animator;

    //Method Build
    public AvoidanceBehavior(IAController iaController, float avoidanceRadius, float avoidanceStrength)
    {
        this.iaController = iaController;
        this.avoidanceRadius = avoidanceRadius;
        this.avoidanceStrength = avoidanceStrength;
        
        animator = iaController.GetComponent<Animator>();
    }

    //Run validation so AIs don't crash
    public void Execute()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(iaController.transform.position, avoidanceRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider.gameObject != iaController.gameObject)
            {
                Vector2 directionAway = (Vector2)(iaController.transform.position - hitCollider.transform.position);
                iaController.GetComponent<Rigidbody2D>().velocity += directionAway.normalized * avoidanceStrength * Time.deltaTime;
                animator.SetFloat("Speed", 1);

                if (directionAway.x != 0)
                {
                    iaController.transform.rotation = Quaternion.Euler(0, directionAway.x > 0 ? 0 : 180f, 0);
                }
            }
        }
    }
}
