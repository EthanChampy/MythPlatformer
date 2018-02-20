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
    private float fallMultiplier = 2.5f;

    [SerializeField]
    private float MinJumpMultiplier = 2f;

    [SerializeField]
    private float JumpForce;

    [SerializeField]
    private int Health;

    [SerializeField]
    private int MaxHealth;

    private GameObject SpawnPoint;

    public bool Invincible = false;

    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        SpawnPoint = GameObject.Find("SpawnPoint");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        AttackManager();
        InputManager();
        Death();
        Movement(horizontal);

        if (PlayerRigidBody.velocity.y < 0)
        {
            PlayerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (PlayerRigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            PlayerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (MinJumpMultiplier - 1) * Time.deltaTime;
        }

        if (PlayerRigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (PlayerRigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        
        isGrounded = IsGrounded();
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

    void Death()
    {
        if (Health <= 0)
        {
            this.gameObject.transform.position = SpawnPoint.transform.position;
            Health = MaxHealth;
        }
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "KillBox")
        {
            Health = 0;
        }
        if (Other.gameObject.tag == "Mosquito" && Invincible == false)
        {
            Health += -1;
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.name == "Apples")
        {
            if (Health < MaxHealth)
            {
                Health += 1;
                Destroy(Other.gameObject);
            }
        }
        if (Other.gameObject.name == "Shield")
        {
                Health += 1;
                Destroy(Other.gameObject);
        }
        if (Other.gameObject.name == "DoubleDamage")
        {
            GameObject AttackHitbox = GameObject.Find("AttackHitbox");
            AttackHitbox.GetComponent<AttackHitbox>().DamageMult = 2;
            Destroy(Other.gameObject);
        }
        if (Other.gameObject.tag == "MosqZomb" && Invincible == false)
        {
            Health += -2;
            Invincible = true;
            Invoke("invincibleTimer", 1.5f);
        }
    }

    void AttackManager()
    {
        if (Input.GetButtonDown("Attack"))
        {
            print("Attack");
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}
