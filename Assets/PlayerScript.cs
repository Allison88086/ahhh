using System.Collections; //easiest way to make camera follow player is to make it child of player
using System.Collections.Generic; //these 3 are just import statements, most of this is boilerplate stuff so don't delete
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour //playercontrol inherits from monobehavior
{
    private Vector2 movementVector; //variable (field since in a class)
    private Rigidbody2D rb;
    [SerializeField] int speed = 0; //serialized field lets u access variable within inspector
    bool jumpable = true;
    bool grappling = false;
    private GameObject playerObj = null;
    Vector2 myVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpable = true;
        } 
        //rb.AddForce(new Vector2(0, 500));
        //if (collision.gameObject.CompareTag("Gem"))
        //{

        //}
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       jumpable = false;
    }
    // Update is called once per frame
    void Update()
    {
        //rb.velocity = movementVector;
        rb.velocity = new Vector2(speed * movementVector.x, rb.velocity.y);
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        //animator.SetBool("Walk_Right", !Mathf.Approximately(movementVector
        //SpriteRender.flipX = movementVector.x, 0；
        //Debug.Log(movementVector); //variables in camel case functions with normal caps (depends on conventions)

    }
    void OnJump(InputValue value)
    {
        if (jumpable == true || grappling == true)
        {
            rb.AddForce(new Vector2(0, 50) * speed);
        }
        else
        {
            Debug.Log("no double jumps");
        }


    }

   void OnGrapple(InputValue value)
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        int varX = (int)(playerObj.transform.position.x);
        int varY = (int)(playerObj.transform.position.y);
        myVector = new Vector2(varX, varY);
        RaycastHit2D hit = Physics2D.Raycast(myVector + new Vector2(1, 0), Vector2.right * 10);

        if (hit.collider != null)
        {
            Debug.Log("no double jumps");

            // Get position of collision

            // Calculate vector 
        }
    } 
}
//

//c# stores everything as a reference and when you have a custom type, that creates a reference of type vector2 at the top, so the new Vector2 creates a new obj and deletes the old one to the reference
//physics joints aren't used often because theyre inpredictable, instantiating game obj is more costly than just reusing an old obj,
//store position where u want player to grapple towards, in fixed update u can continuously apply rigidbody.addforce towards direction with a magnitude
//forcemode.force will apply a gradual force