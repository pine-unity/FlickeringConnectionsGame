using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaKillScript : MonoBehaviour
{
    // text UI
    // public Text deathText;
    public GameObject deathScreen;
    public GameObject controlsText;
    public PowerUp powerUpScript;
    [SerializeField] GameObject Bubble;
    [SerializeField] float upwardLavaForce = 5;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Transform playerTrn;
    [SerializeField] GameObject lavaTrail;
    public bool lavaDisabledTrail = false;

    // exit and retry buttons
    //public GameObject buttons;

    // transparent
    [SerializeField] Color color1;

    // white
    [SerializeField] Color color2;

    void Start()
    {
        //color1 = new Color(255, 255, 255, 0);
        // color2 = new Color(255, 255, 255, 255);
        //deathText.color = color1;
        //buttons.SetActive(false);
        deathScreen.SetActive(false);
        lavaTrail.SetActive(false);
        lavaDisabledTrail = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Lava"))
        {
            if (powerUpScript.poweredUp == true)
            { 
                
                Bubble.SetActive(false);
                

                //playerTrn.position = new Vector3(playerTrn.position.x, playerTrn.position.y + 2, playerTrn.position.z);
                playerRb.velocity += (Vector2.up * 50);
                lavaTrail.SetActive(true);
                lavaDisabledTrail = false;


                if (playerRb.velocity.y > 30)
                {
                    StartCoroutine(DelayDisableTrail(1));
                    
                    powerUpScript.poweredUp = false;
                    
                }

            }

            
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            if (powerUpScript.poweredUp == false)
            {

                gameObject.SetActive(false);
                //deathText.color = color2;
                //buttons.SetActive(true);
                controlsText.SetActive(false);
                deathScreen.SetActive(true);
            }
        }
    }

    IEnumerator DelayDisableTrail(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        lavaTrail.SetActive(false);
        lavaDisabledTrail = true;

    }





}