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
    public int maxSpeed = 50 ;
    private Animator characterAnimations;

    private bool IsDead = false;

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
            
        }
        else{
            //gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
           
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
            characterRight = true;
        }   
        else if(x == -1){
            characterRight = false;
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
        
    
        rb.velocity = new Vector2(moveBy * Time.fixedDeltaTime, rb.velocity.y); 

        if(rb.velocity.magnitude > maxSpeed){
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
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
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space) || rb.velocity.y > 0 && !Input.GetKey(KeyCode.W) || rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    void Die() {
        characterAnimations.SetBool("Alive", false);
        IsDead = true;
    }


    private void OnCollisionEnter2D(Collision2D other){
   
        if (other.gameObject.tag == "Obstacle"){
            Die();
        }
  
    }
}
