using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;

    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private float speed = 5f;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private Vector2 movInput;

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
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movInput = controls.Base.Move.ReadValue<Vector2>().normalized;
      
        playerAnimator.SetFloat("speed", movInput.sqrMagnitude);

        fieldOfView.SetOrigin(transform.position);
    }

    private void FixedUpdate()
    {
        if (movInput != Vector2.zero)
        {
            playerRb.MovePosition(playerRb.position + movInput * speed * Time.fixedDeltaTime);

            transform.rotation = Quaternion.Euler(0, movInput.x > 0 ? 0 : movInput.x < 0 ? 180f : transform.rotation.eulerAngles.y, 0);
        }
    }
}
