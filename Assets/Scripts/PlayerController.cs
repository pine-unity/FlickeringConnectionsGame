using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // emilio is a confirmed feathery, he has furry-like tendencies

    public Rigidbody2D rb;
    // horizontal speed
    [SerializeField] int speedX = 1000;
    int jumpForce = 450;
    // to see if the player is on the ground. revolutionary, right?
    [SerializeField] bool isGrounded;
    // horizontal direction
    [SerializeField] int dirX = 1;
    // x position
    float x;
    // player animator
    Animator Animator;
    // to prevent the player from shooting off the screen
    [SerializeField] bool flippedDirInLast = false;
    // to prevent the WaitToSpeedUp() ienum to be called multiple times while the A or D key is held down
    [SerializeField] bool startedSpeedingUp = false;
    [SerializeField] bool isIdle = true;
    [SerializeField] bool useFasterSpeed = false;

    [SerializeField] OptionsEnableDisableScript optionScript;

    

    // initial x
    float xPosInit = -37.53f;
    // initial y
    float yPosInit = 5.67f;
    // initial z
    float zPosInit = -13.48f;

    //~~---------------------------------------------------~~\\

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xPosInit, yPosInit, zPosInit);
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        // reset player animator to default speed
        Animator.speed = 1;
    }

    //~~---------------------------------------------------~~\\

    // Update is called once per frame
    void Update()
    {

        if (optionScript.playerDisabled)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            // fixing some weird bug with the freezing not letting the player gravity work again after disabling
            // the option menu
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, -15.6f);
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, -15.6f);
        }

        //------------------------------\\

        x = transform.position.x;

        if((Animator.speed > 1) || (useFasterSpeed))
        {
            rb.AddForce(Vector2.right * dirX * 2000 * Time.deltaTime);
            
        }
        

        //------------------------------\\

        if (Input.GetKey(KeyCode.A) && optionScript.playerDisabled == false)
        {

            
            if (rb.velocity.x > -1000 && rb.velocity.x <= 0 && !useFasterSpeed)
            {
                rb.AddForce(Vector2.left * speedX * Time.deltaTime);

            }
            else if (useFasterSpeed)
            {
                DelayAddForce(1f, Vector2.left);
            }

            

            Animator.SetBool("isWalking", true);
            isIdle = false;

            if (dirX != -1)
            {
                Flip();
            }

            if (!startedSpeedingUp && isIdle == false)
            {

                if (Animator.GetBool("isWalking") == true)
                {
                    StartCoroutine(WaitToSpeedUp());
                    startedSpeedingUp = true;
                }
                else
                {
                    startedSpeedingUp = false;

                }

            }

        }

        //------------------------------\\

        if (Input.GetKey(KeyCode.D) && optionScript.playerDisabled == false)
        {
            if (rb.velocity.x < 1000 && rb.velocity.x >= 0 && !useFasterSpeed)
            {
                rb.AddForce(Vector2.right * 1000 * Time.deltaTime);

            } else if (useFasterSpeed)
            {
                DelayAddForce(1f, Vector2.right);
            }

            Animator.SetBool("isWalking", true);
            isIdle = false;
            if (dirX != 1)
            {
                Flip();

            }
            if (!startedSpeedingUp && isIdle == false)
            {

                if (Animator.GetBool("isWalking") == true)
                {
                    StartCoroutine(WaitToSpeedUp());
                    startedSpeedingUp = true;

                } else
                {
                    startedSpeedingUp = false;

                }

            }

        }

        //------------------------------\\

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || isIdle == true)
        {
            Animator.speed = 1;
            //speedX = 1000;
            startedSpeedingUp = false;
            useFasterSpeed = false;
            
        }

        //------------------------------\\

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && optionScript.playerDisabled == false)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        //------------------------------\\

        if (rb.velocity == Vector2.zero)
        {
            Animator.SetBool("isWalking", false);
            Animator.SetBool("isIdle", true);
            Animator.speed = 1;
            //speedX = 1000;


            if (Animator.GetBool("isIdle") == true && Animator.GetBool("isWalking") == false)
            {

                isIdle = true;

            }

        }

        //Debug.Log(rb.velocity);
    }

    //~~---------------------------------------------------~~\\
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    //~~---------------------------------------------------~~\\

   private void OnCollisionExit2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
   } 

    //~~---------------------------------------------------~~\\

    void Flip()
    {

         if(dirX == 1 && !flippedDirInLast)
         {
             transform.rotation = Quaternion.Euler(0, 0, 0);
             transform.position = new Vector3(x - 3, transform.position.y, transform.position.z);
             dirX *= -1;
             flippedDirInLast = true;
             StartCoroutine(Wait());

        } else if(dirX == -1 && !flippedDirInLast)
         {
             transform.rotation = Quaternion.Euler(0, 180, 0);
             transform.position = new Vector3(x + 3, transform.position.y, transform.position.z);
             dirX *= -1;
             flippedDirInLast = true;
             StartCoroutine(Wait());
         }


    }

    //~~---------------------------------------------------~~\\

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(0.1f);
        flippedDirInLast = false;

    }

    //~~---------------------------------------------------~~\\

    IEnumerator WaitToSpeedUp()
    {
        yield return new WaitForSeconds(1.0f);
        //Debug.Log("should have sped up");
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && optionScript.playerDisabled == false)
        {
            if (!isIdle)
            {
                Animator.speed = 2.5f;
                useFasterSpeed = true;
            }
            else if(isIdle || (isIdle && startedSpeedingUp))
            {
                Animator.speed = 1;
                //speedX = 2000;
                useFasterSpeed = false;
                startedSpeedingUp = false;
                //Debug.Log("should slow down");
                
            }
            
            
            
        }
        
    }

    //~~---------------------------------------------------~~\\

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    //~~---------------------------------------------------~~\\

    IEnumerator DelayAddForce(float seconds, Vector2 vector)
    {
        yield return new WaitForSeconds(seconds);

        if(vector == Vector2.right)
        {
            if (rb.velocity.x < 2000)
            {
                rb.AddForce(Vector2.right * 2000 * Time.deltaTime);
            }
        } else if(vector == Vector2.left)
        {
            if (rb.velocity.x > -2000)
            {
                rb.AddForce(Vector2.left * 2000 * Time.deltaTime);
            }
        }
        
        

    }


}
