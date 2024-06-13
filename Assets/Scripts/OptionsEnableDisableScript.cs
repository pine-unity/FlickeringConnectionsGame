using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsEnableDisableScript : MonoBehaviour
{
    [SerializeField] private GameObject EscUI;
    [SerializeField] private bool EscUIActive;
    public bool playerDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        EscUI.SetActive(false);
        EscUIActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(EscUIActive == false)
            {
                EscUI.SetActive(true);
                EscUIActive = true;
                playerDisabled = true;

            } else
            {
                EscUI.SetActive(false);
                EscUIActive = false;
                playerDisabled = false;
            }


        }
        
    }

    
}
