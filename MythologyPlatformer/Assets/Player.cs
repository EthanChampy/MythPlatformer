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

    public int Health;
    public int Armor;
    public int Key;

    [SerializeField]
    private int MaxHealth;

    private GameObject SpawnPoint;

    public bool Invincible = false;
    public bool DeathBool = false;
    public int Lives = 3;
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

        if (DeathBool == false)
        {
            InputManager();
            Movement(horizontal);
        }

        Anim.SetBool("Attack", GetComponent<PlayerAttack>().Attacking);

        if (Health <= 0)
        {
            DeathBool = true;
            Anim.SetBool("DeathBool", DeathBool);
            Invoke("Death", 0.9f);
        }

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
        if (DeathBool == true)
        {
            Lives += -1;
            PlayerRigidBody.velocity = new Vector2(0f, 0f);
            DeathBool = false;
            Anim.SetBool("DeathBool", DeathBool);
            this.gameObject.transform.position = SpawnPoint.transform.position;
            Health = MaxHealth;
        }
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "KillBox")
        {
            Armor = 0;
            DeathBool = true;
            Invoke("Death", 0f);
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
        if (Other.gameObject.name == "Apples") //Health Item
        {
            if (Health == 5)
            {
                Health = MaxHealth;
            }
            if (Health == 4)
            {
                Health = MaxHealth;
            }
            if (Health < MaxHealth)
            {
                if (Health <= 3)
                Health += 3;
                Destroy(Other.gameObject);
            }
        }
        if (Other.gameObject.name == "Shield") // Armor Item
        {
            Armor += 3;
                Destroy(Other.gameObject);
        }
        if (Other.gameObject.name == "DoubleDamage") // Damage Item
        {
            GameObject AttackHitbox = GameObject.Find("AttackHitbox");
            AttackHitbox.GetComponent<AttackHitbox>().DamageMult = 2;
            Destroy(Other.gameObject);
        }

        if (Other.gameObject.tag == "Vine" && Invincible == false) //PEST Vine damage
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

        if (Other.gameObject.tag == "Pestilence" && Invincible == false) //PEST Boss damage
        {
            if (Armor <= 0)
            {
                Health += -5;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -5;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }

        if (Other.gameObject.tag == "War" && Invincible == false) //WAR Boss damage
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

        if (Other.gameObject.tag == "Famine" && Invincible == false) //FAMINE Boss damage
        {
            if (Armor <= 0)
            {
                Health += -4;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -4;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }

        if (Other.gameObject.tag == "Death" && Invincible == false) //DEATH Boss damage
        {
            if (Armor <= 0)
            {
                Health += -5;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -5;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }

        if (Other.gameObject.tag == "MosqZomb" && Invincible == false) //Zombie damage
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
        if (Other.gameObject.tag == "Warrior" && Invincible == false) //Warrior Damage
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
        if (Other.gameObject.tag == "Blob" && Invincible == false) //Blob Damage
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

        if (Other.gameObject.tag == "Skeleton" && Invincible == false) //Skeleton Damage
        {
            if (Armor <= 0)
            {
                Health += -4;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -4;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }
        if (Other.gameObject.tag == "SkeleHitbox" && Invincible == false) //SkeletonAXE Damage
        {
            if (Armor <= 0)
            {
                Health += -Health;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
            if (Armor > 0)
            {
                Armor += -Armor;
                Invincible = true;
                Invoke("invincibleTimer", 1.5f);
            }
        }
    }

    void OnTriggerStay2D (Collider2D Other)
    {
        if (Other.gameObject.name == "FamineDoor" && Input.GetButtonDown("Up")) //Doors
        {
            this.gameObject.transform.position = new Vector3(-15.987f, 18.992f, 0);
        }
        if (Other.gameObject.name == "DeathDoor" && Input.GetButtonDown("Up"))
        {
            this.gameObject.transform.position = new Vector3(-12.733f, -18.394f, 0);
        }
        if (Other.gameObject.name == "WarDoor" && Input.GetButtonDown("Up"))
        {
            this.gameObject.transform.position = new Vector3(67.047f, -16.64f, 0);
        }
        if (Other.gameObject.name == "PestilenceDoor" && Input.GetButtonDown("Up"))
        {
            this.gameObject.transform.position = new Vector3(21.918f, -10.798f, 0);
        }


        if (Other.gameObject.tag == "KeyHolderWar" && Input.GetButtonDown("Up"))
        {
            Key += 1;
            GameObject WarLock = GameObject.Find("WarLock");
            Destroy(WarLock);
            this.gameObject.transform.position = SpawnPoint.transform.position;
            Destroy(Other.gameObject);
        }

        if (Other.gameObject.tag == "KeyHolderDeath" && Input.GetButtonDown("Up"))
        {
            Key += 1;
            GameObject DeathLock = GameObject.Find("DeathLock");
            Destroy(DeathLock);
            this.gameObject.transform.position = SpawnPoint.transform.position;
            Destroy(Other.gameObject);
        }

        if (Other.gameObject.tag == "KeyHolderPest" && Input.GetButtonDown("Up"))
        {
            Key += 1;
            GameObject PestLock = GameObject.Find("PestLock");
            Destroy(PestLock);
            this.gameObject.transform.position = SpawnPoint.transform.position;
            Destroy(Other.gameObject);
        }

        if (Other.gameObject.tag == "KeyHolderFamine" && Input.GetButtonDown("Up"))
        {
            Key += 1;
            GameObject FamineLock = GameObject.Find("FamineLock");
            Destroy(FamineLock);
            this.gameObject.transform.position = SpawnPoint.transform.position;
            Destroy(Other.gameObject);
        }

    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}
