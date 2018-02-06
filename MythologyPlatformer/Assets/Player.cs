using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D PlayerRigidBody;

    [SerializeField]
    private float MovementSpeed;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundradius;

    [SerializeField]
    private LayerMask WhatIsGround;

    private bool isGrounded;

    private bool Jump;

    [SerializeField]
    private float JumpForce;

    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputManager();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();
        Movement(horizontal);
        ResetValues();

        if (Jump == true)
        {
            print("Jump");
        }
    }

    private void Movement(float horizontal)
    {
        PlayerRigidBody.velocity = new Vector2(horizontal * MovementSpeed, PlayerRigidBody.velocity.y);

        if (isGrounded && Jump)
        {
            isGrounded = false;
            PlayerRigidBody.AddForce(new Vector2(0, JumpForce));
            print("jump");
        }
    }

    private bool IsGrounded()
    {
        if (PlayerRigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundradius, WhatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
        }
    }

    private void ResetValues()
    {
        Jump = false;
    }
}
