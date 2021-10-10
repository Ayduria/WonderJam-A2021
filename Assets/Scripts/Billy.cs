using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billy : MonoBehaviour
{

    Rigidbody2D rb; 
    public float speed;
    public float jumpForce;
    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor; 
    float lastTimeGrounded;
    public bool characterRight = true;
    public bool characterUp = false;
    public int maxSpeed = 50 ;
    private Animator characterAnimations;
    public bool timeIsStopped;
    public bool IsDead = false;

    public float DashForce = 15f;
    public float StartDashTimer;
    private bool DashDirection;

    float CurrentDashTimer;
    public float DefaultDashCoolDown = 0.75f;
    float DashCoolDown;

    bool isDashing;
    bool hasUsedDash = false;

    //Sons
    public AudioSource jump;
    public AudioSource walk;
    public AudioSource takeDamage;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3 (1, 1, 1);
        characterAnimations = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0){
                return;
        }

        if(timeIsStopped){
            rb.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;
        }
        else{
            rb.constraints = UnityEngine.RigidbodyConstraints2D.None;
        }

        // Dash Left
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded && rb.velocity.x != 0){
            if(hasUsedDash == false){
                isDashing = true;
                characterAnimations.SetBool("IsDashing", true);
                CurrentDashTimer = StartDashTimer;
                DashCoolDown = DefaultDashCoolDown;
                hasUsedDash = true;
                if(rb.velocity.x > 0.01){
                    DashDirection = true;
                }
                else{
                    DashDirection = false;
                }
            }
        }


        Move(); 
        Jump();
        CheckIfGrounded();
        BetterJump();
        

        if(IsDead){
             rb.velocity = new Vector2(0,  rb.velocity.y);
        }
     
            //Rotate 
            if(!characterRight){
                //gameObject.transform.localScale = new Vector3 (-0.5f, 0.5f, 0.5f);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                if(characterUp){
                    transform.localRotation = Quaternion.Euler(180, 180, 0);
                }
                
            }
            else{
                //gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                if(characterUp){
                    transform.localRotation = Quaternion.Euler(180, 0, 0);
                }
            }
        
    }

    void Move() { 
        if(IsDead){
             return;
        }
        float x = Input.GetAxisRaw("Horizontal"); 
        float moveBy = x * speed;

        Vector3 InitialPos = gameObject.transform.localScale;



        if(x == 1){
            if(timeIsStopped == false){
                characterRight = true;
            }
        }   
        else if(x == -1){
            if(timeIsStopped == false){
                characterRight = false;
            }
        }

        //Change l'état de l'animation
        if(x == 0){
            characterAnimations.SetFloat("speed", 0);
            //walk.Pause();
            
        }
        else{
            characterAnimations.SetFloat("speed", 1);
            //walk.Play();
        }

        DashCoolDown -= Time.deltaTime;

        if(isDashing){
            characterAnimations.SetBool("IsDashing", true);
            if(DashDirection){
                rb.velocity = new Vector2(DashForce, 0); 
            }
            else{
               rb.velocity = new Vector2(DashForce * -1, 0); 
            }

            CurrentDashTimer -= Time.deltaTime;

            if(CurrentDashTimer <= 0){
                isDashing = false;
                characterAnimations.SetBool("IsDashing", false);
            }
        }
        else{
            rb.velocity = new Vector2(moveBy * Time.fixedDeltaTime, rb.velocity.y); 
            if(rb.velocity.magnitude > maxSpeed){
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }

    }

    void Jump() { 
        if(IsDead){
             return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump.Play();
        }

        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump.Play();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump.Play();
        }
    }
    
    void CheckIfGrounded() { 
            Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
            if (colliders != null) { 
                isGrounded = true; 
                hasUsedDash = false;
                characterAnimations.SetBool("IsJumping", false);
            } else { 
                if (isGrounded) { 
                    lastTimeGrounded = Time.time; 
                } 
                isGrounded = false; 
                characterAnimations.SetBool("IsJumping", true);
            } 
    }

    void BetterJump() {
        
    }

    void Die() {
        characterAnimations.SetBool("Alive", false);
        IsDead = true;
        takeDamage.Play();
    }

    public void toggleTime() {
        timeIsStopped = !timeIsStopped;
        GetComponent<Animator>().enabled = !timeIsStopped;
        

        if(timeIsStopped == false){
            rb.gravityScale *= -1;
            characterUp = !characterUp;
            jumpForce *= -1;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D other){
   
        if (other.gameObject.tag == "Obstacle"){
            Die();
        }
  
    }
}
