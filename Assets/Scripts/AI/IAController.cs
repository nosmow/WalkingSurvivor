using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    private BehaviourTree behaviourTree;
    private Rigidbody rb;

    public Transform currentRoom;

    private PatrolArea patrolArea;
    [SerializeField] private float patrolSpeed = 2f;

    [SerializeField] private float avoidanceRadius = 1.5f;
    [SerializeField] private float avoidanceStrength = 3f;
    [SerializeField] private bool isWaiting = false;
    [SerializeField] private float waitTime = 2f;

    void Start()
    {
        patrolArea = currentRoom.GetComponent<PatrolArea>();

        behaviourTree = new BehaviourTree();
        behaviourTree.AddNode(new PatrolBehavior(this, patrolArea, patrolSpeed, isWaiting, waitTime));
        //behaviourTree.AddNode(new AvoidanceBehavior(this, avoidanceRadius, avoidanceStrength));
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        behaviourTree.Execute();
    }
}
