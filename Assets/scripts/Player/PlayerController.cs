using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpspeed = 12f;
    private float direction = 0f;//==horizontal
    private float dirY = 0f;//==horizontal
    private Rigidbody2D player;//=rigidbody
    public GameObject projectilePrefab;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;//==animator
   
    public int maxHealth = 6;
   
    public int Health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject handle,Trigger;
    public GameObject Door;

    public bool ClimbingAllowed { get; set; }

    private Vector3 respawnPoint;
    //public GameObject Fall;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
       
        currentHealth = maxHealth;//full health when start

        handle = GameObject.FindGameObjectWithTag("Touch");//up
        handle.SetActive(true);

        Door = GameObject.FindGameObjectWithTag("OnDoor");//
        Door.SetActive(false);

        Trigger = GameObject.FindGameObjectWithTag("OnHandle");//down
        Trigger.SetActive(false);

        respawnPoint = transform.position;
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);//checkground
        direction = Input.GetAxisRaw("Horizontal");
        if (ClimbingAllowed)
        {
            dirY = Input.GetAxisRaw("Vertical") * speed;
        }
       
        if (direction > 0f)//right direction
        {
            player.velocity = new Vector2 (direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.2f,0.2f);
        }
        else if(direction < 0f)//left direction
        {
            player.velocity = new Vector2 (direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.2f, 0.2f);//facing left
        }
        else
        {
            player.velocity = new Vector2(0,player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x,jumpspeed);
        }

        playerAnimation.SetFloat("Speed",Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (!Mathf.Approximately(direction, 0.0f))
        {
            lookDirection.Set(direction * speed, 0f);
            lookDirection.Normalize();
        }

       
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (ClimbingAllowed)
        {
            player.isKinematic = true;
            player.velocity = new Vector2(direction * speed, dirY);
        }
        else
        {
            player.isKinematic = false;
            //rb.velocity = new Vector2(dirX, rb.velocity.y);
        }

    }

    public void ChangeHealth(int amount)
    {

        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth+amount,0,maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);


        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, player.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        //playerAnimation.SetTrigger("Launch");
    }



    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Touch"))
        {
           
            Trigger.SetActive(true);//hide the target that not lighted
            handle.SetActive(false);
            Door.SetActive(true);
           
        }

        if (other.gameObject.CompareTag("Zombie"))
        {

            ChangeHealth(-1);

        }


    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("attackplayer");
            ChangeHealth(-1);

        }


        if(other.gameObject.CompareTag("Restart"))
        {
            transform.position = respawnPoint;
            ChangeHealth(-1);

        }
        else if(other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;

        }



    }
    public void Die()
    {
        Debug.Log("Die");
        //bool dead = true;
        FindObjectOfType<UIHealthBar>().GameOver();

    }
   


}
