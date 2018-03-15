using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int MaxHealth;

    private GameObject SpawnPoint;
    GameObject AttackHitbox;

    public bool Invincible = false;
    public bool DeathBool = false;
    public int Lives = 3;
    public Animator Anim;

    SpriteRenderer ThisSR;

    public AudioClip JumpSound;
    public AudioClip AttackSound;
    public AudioClip DamageSound;

    AudioSource AudioSource;


    void Start() //When player spawns
    {
        Invoke("StatSet", 0.1f);
        AttackHitbox = GameObject.Find("AttackHitbox");
        AudioSource = GetComponent<AudioSource>();
        ThisSR = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        SpawnPoint = GameObject.Find("SpawnPoint");
    }

    void Update() //Run every frame
    {
        Physics2D.IgnoreCollision(AttackHitbox.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        if (Health <= 0)
        {
            Health = 0;
        }
        if (Lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        float horizontal = Input.GetAxis("Horizontal");

        if (DeathBool == false)
        {
            InputManager();
            Movement(horizontal);
        }

        Anim.SetBool("Attack", GetComponent<PlayerAttack>().Attacking); //Sets bool for animator for attacks

        if (Health <= 0) //Death
        {
            DeathBool = true;
            Anim.SetBool("DeathBool", DeathBool);
            Invoke("Death", 0.7f);
        }

        if (PlayerRigidBody.velocity.y < 0) //Movement
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

    private void Movement(float horizontal) //Movement
    {
        Anim.SetFloat("MovementSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        PlayerRigidBody.velocity = new Vector2(horizontal * MovementSpeed, PlayerRigidBody.velocity.y);

        if (isGrounded && Jump)
        {
            isGrounded = false;
            PlayerRigidBody.AddForce(new Vector2(0, JumpForce));
            AudioSource.volume = 1;
            AudioSource.PlayOneShot(JumpSound);
        }
    }

    private bool IsGrounded() //Can You Jump?
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

    private void InputManager() //Jump
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

    void OnCollisionEnter2D(Collision2D Other) //Collisions! (I know it's the least optimised thing in existence, I apologise sincerely)
    {
        if (Other.gameObject.tag == "KillBox")
        {
            Armor = 0;
            DeathBool = true;
            PlayerRigidBody.velocity = new Vector2(0, 0);
            Anim.SetBool("DeathBool", DeathBool);
            Invoke("Death", 0.7f);
        }
        if (Other.gameObject.tag == "Mosquito" && Invincible == false)
        {
            if (Armor <= 0)
            {
                Health += -1;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -1;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
                if (Armor < 0)
                {
                    Armor = 0;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Other) //Collisions with triggers! (I know it's the least optimised thing in existence, I apologise sincerely)
    {
        if (Other.gameObject.name == "LevelChanger")
        {
            PlayerPrefs.SetInt("Health", Health);
            PlayerPrefs.SetInt("Armor", Armor);
            PlayerPrefs.SetInt("Lives", Lives);
            PlayerPrefs.SetInt("Damage", AttackHitbox.GetComponent<AttackHitbox>().DamageMult);
            SceneManager.LoadScene("MainLevel");
        }

        if (Other.gameObject.name == "Apples") //Health Item
        {
            if (Health == 5)
            {
                Health = MaxHealth;
                Destroy(Other.gameObject);
            }
            if (Health == 4)
            {
                Health = MaxHealth;
                Destroy(Other.gameObject);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -2;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -5;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -3;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -4;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -5;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -2;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -3;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -3;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -4;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
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
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
            if (Armor > 0)
            {
                Armor += -Armor;
                Invincible = true;
                AudioSource.volume = 0.5f;
                AudioSource.PlayOneShot(DamageSound);
                Invoke("invincibleTimer", 1.5f);
                Invoke("ColorOff", 0f);
                Invoke("ColorOn", 0.15f);
                Invoke("ColorOff", 0.3f);
                Invoke("ColorOn", 0.45f);
                Invoke("ColorOff", 0.6f);
                Invoke("ColorOn", 0.75f);
            }
        }
    }

    void OnTriggerStay2D (Collider2D Other)
    {
        if (Other.gameObject.name == "BossLevelTP" && Key == 4)
        {
            PlayerPrefs.SetInt("Health", Health);
            PlayerPrefs.SetInt("Armor", Armor);
            PlayerPrefs.SetInt("Lives", Lives);
            PlayerPrefs.SetInt("Damage", AttackHitbox.GetComponent<AttackHitbox>().DamageMult);
            SceneManager.LoadScene("BossLevel");
        }

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

    void ColorOn()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 255);
    }

    void ColorOff()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 0);
    }

    void StatSet()
    {
        Health = PlayerPrefs.GetInt("Health");
        Armor = PlayerPrefs.GetInt("Armor");
        Lives = PlayerPrefs.GetInt("Lives");
    }

    public void DoHealthCalc(int _health)
    {
        
        if (Health + _health > MaxHealth)
            Health = MaxHealth;
        else
            Health += _health;

        if (Health < 0)
            Health = 0;
    }

    public void DoArmorCalc(int _armor)
    {
            Armor += _armor;

        if (Armor < 0)
            Armor = 0;
    }
}
