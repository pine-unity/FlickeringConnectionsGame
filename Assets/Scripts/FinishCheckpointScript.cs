using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheckpointScript : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] GameObject player;
    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            winText.SetActive(true);
            Debug.Log("You did it!");
            player.SetActive(false);
            won = true;
        }
    }
}
