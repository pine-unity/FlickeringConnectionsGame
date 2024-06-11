using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] Transform Player;
    public bool poweredUp = false;
    public GameObject Bubble;

    void Start()
    {
        gameObject.SetActive(true);
        Bubble.SetActive(false);
        poweredUp = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //Player.localScale *= 1.5f;
            poweredUp = true;
            Bubble.SetActive(true);
        }
    }
}
