﻿using System.Collections;
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

    public int Health;
    public int Armor;

    [SerializeField]
    private int MaxHealth;

    private GameObject SpawnPoint;

    public bool Invincible = false;

    public Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        SpawnPoint = GameObject.Find("SpawnPoint");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        InputManager();
        Death();
        Movement(horizontal);

        Anim.SetBool("Attack", GetComponent<PlayerAttack>().Attacking);

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
        Anim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
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
        if (Input.GetButtonDown("Jump"))
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
            print("Fuck this code");
        }
        if (Other.gameObject.tag == "Mosquito" && Invincible == false)
        {
            if (Armor <= 0)
            {
                Health += -1;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -1;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
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
            Armor += 1;
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
            if (Armor <= 0)
            {
                Health += -2;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -2;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }
        if (Other.gameObject.tag == "Warrior" && Invincible == false)
        {
            if (Armor <= 0)
            {
                Health += -3;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -3;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}
