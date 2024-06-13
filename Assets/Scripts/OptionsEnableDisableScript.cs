using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsEnableDisableScript : MonoBehaviour
{
    [SerializeField] private GameObject EscUI;
    [SerializeField] private bool EscUIActive;
    public bool playerDisabled = false;
    [SerializeField] private LavaKillScript lavaKillScript;
    [SerializeField] private FinishCheckpointScript finishCheckpointScript;

    // Start is called before the first frame update
    void Start()
    {
        EscUI.SetActive(false);
        EscUIActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(lavaKillScript.dead || finishCheckpointScript.won)
        {
            EscUI.SetActive(false);
            EscUIActive = false;
            playerDisabled = false;

        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (EscUIActive == false)
                {
                    EscUI.SetActive(true);
                    EscUIActive = true;
                    playerDisabled = true;

                }
                else
                {
                    EscUI.SetActive(false);
                    EscUIActive = false;
                    playerDisabled = false;
                }


            }

        }

        
        
    }

    public void ResumeGame()
    {
        EscUI.SetActive(false);
        EscUIActive = false;
        playerDisabled = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    
}
