
using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PatrolBehavior : IBehaviourNode
{
    private IAController iaController;
    private PatrolArea patrolArea;
    private Vector2 targetPoint;
    private float speed = 2f;
    private bool isWaiting = false;
    private float waitTime = 2f;

    private Animator animator;

    //Method Builder
    public PatrolBehavior(IAController controller, PatrolArea patrolArea, float speed, bool isWaiting, float waitTime)
    {
        this.iaController = controller;
        this.patrolArea = patrolArea;
        this.speed = speed;
        SetNewPatrolPoint();
        this.isWaiting = isWaiting;
        this.waitTime = waitTime;

        animator = iaController.GetComponent<Animator>();
    }

    //Execute patrol action
    public void Execute()
    {
        if (!isWaiting)
        {
            MoveTowardsTarget();
            if (Vector2.Distance(iaController.transform.position, targetPoint) < 0.2f)
            {
                iaController.StartCoroutine(WaitBeforeNextPoint());
            }
        }
    }

    //Coroutine to wait before changing point
    private IEnumerator WaitBeforeNextPoint()
    {
        isWaiting = true;
        iaController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(waitTime);
        SetNewPatrolPoint();
        isWaiting = false;
    }

    //Get a new patrol point
    private void SetNewPatrolPoint()
    {
        targetPoint = patrolArea.GetRandomPoint();
    }

    //Move the AI to the next point
    private void MoveTowardsTarget()
    {
        Vector2 currentPosition = iaController.transform.position;
        Vector2 direction = targetPoint -currentPosition;
        direction.Normalize();
        iaController.GetComponent<Rigidbody2D>().velocity = direction * speed;
        animator.SetFloat("Speed", 1);


        if (direction.x != 0)
        {
            iaController.transform.rotation = Quaternion.Euler(0, direction.x > 0 ? 0 : 180f, 0);
        }
    }
}
