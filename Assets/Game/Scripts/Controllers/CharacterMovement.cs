using UnityEngine;

public class CharacterControl : MonoBehaviour{

    public float maxspeed = 7f;     //Maximum speed of character
    			
    public float jumpForce = 15f;   //Force of Jump
    float groundRadius = 0.04f;		//Radius of overlap cicles
    float h_gain;		            //Current keyboard gain

    public LayerMask whatIsGround;	//What is ground layer. Put your platforms to this layer
    
    public GameObject BackGroundCheck;	//Ground checking object, 1st leg
    public GameObject MiddleGroundCheck;	//Ground checking object, between legs
    public GameObject FrontGroundCheck;	//Ground checking object, 2nd leg

    bool grounded = false;			//If character on the ground with 1st leg
    bool grounded2 = false;			//If character on the ground with body or space between legs
    bool grounded3 = false;			//If character on the ground with 2nd leg

    private InputActions InputActions; 

    void Awake()                            
    {
        Physics2D.gravity = new Vector2(0, -70);
        InputActions = new InputActions();
        //Need to make platformer dynamic
    }

    

    void Update()
    {
        // if ((grounded || grounded2 || grounded3) && Input.GetButtonDown("Jump"))            // Jumping code. If player grounded he can jump;
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);          // adding velocity to player.
          
              
    }

    void FixedUpdate()
    {
        // grounded = Physics2D.OverlapCircle(BackGroundCheck.transform.position, BackGroundCheck.GetComponent<CircleCollider2D>().radius, whatIsGround);
        // grounded2 = Physics2D.OverlapCircle(MiddleGroundCheck.transform.position, MiddleGroundCheck.GetComponent<CircleCollider2D>().radius, whatIsGround);
        // grounded3 = Physics2D.OverlapCircle(FrontGroundCheck.transform.position, FrontGroundCheck.GetComponent<CircleCollider2D>().radius, whatIsGround);       //checking if character grounded with any of groundcheck objects
        //
        // h_gain = Input.GetAxis("Horizontal");                                        //reading input 
        // GetComponent<Rigidbody2D>().velocity = new Vector2(maxspeed*h_gain, GetComponent<Rigidbody2D>().velocity.y); //actually moving the character.
        //
        // if (Mathf.Abs(h_gain) > 0.1)                                                 //
        //     transform.localScale = new Vector3(Mathf.Sign(h_gain) * 1, 1, 1);        //Flipping left or right
       
    }

    void OnJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
    }
    
    
}
