using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAccessoriesScript : MonoBehaviour
{
    public GameObject bowTie;
    public static bool bowTieEnabled = false;

    public GameObject topHat;
    public static bool topHatEnabled = false;

    public GameObject wizardHat;
    public static bool wizardHatEnabled = false;

    public GameObject glasses;
    public static bool glassesEnabled = false;

    [SerializeField] bool bowTieButtonClicked = false;
    [SerializeField] bool topHatButtonClicked = false;
    [SerializeField] bool wizardHatButtonClicked = false;
    [SerializeField] bool glassesButtonClicked = false;

    void Start()
    {
        bowTie.SetActive(false);

        DontDestroyOnLoad(bowTie);
        DontDestroyOnLoad(topHat);
        DontDestroyOnLoad(wizardHat);
        DontDestroyOnLoad(glasses);

    }

    public void Update()
    {
        if(!bowTieEnabled)
        {
            bowTie.SetActive(false);
        } else
        {
            bowTie.SetActive(true);
        }

        if (!topHatEnabled)
        {
            topHat.SetActive(false);
        }
        else
        {
            topHat.SetActive(true);
        }

        if (!wizardHatEnabled)
        {
            wizardHat.SetActive(false);
        }
        else
        {
            wizardHat.SetActive(true);
        }

        if (!glassesEnabled)
        {
            glasses.SetActive(false);
        }
        else
        {
            glasses.SetActive(true);
        }
    }

    public void addBowTie()
    {
        if(!bowTieButtonClicked)
        {
            bowTieEnabled = true;
            bowTieButtonClicked = true;
            

        } else
        {
            bowTieEnabled = false;
            bowTieButtonClicked = false;
        }
        
    }

    public void addTopHat()
    {
        if (!topHatButtonClicked)
        {
           
            topHatEnabled = true;
            topHatButtonClicked = true;
            if (wizardHatEnabled)
            {
                wizardHatEnabled = false;
                wizardHatButtonClicked = false;
            }

        }
        else
        {
            topHatEnabled = false;
            topHatButtonClicked = false;
        }
    }

    public void addGlasses()
    {
        if (!glassesButtonClicked)
        {

            glassesEnabled = true;
            glassesButtonClicked = true;

        }
        else
        {
            glassesEnabled = false;
            glassesButtonClicked = false;
        }
    }

    public void addWizardHat()
    {
        if (!wizardHatButtonClicked)
        {
            
            wizardHatEnabled = true;
            wizardHatButtonClicked = true;
            if(topHatEnabled)
            {
                topHatEnabled = false;
                topHatButtonClicked = false;
            }
            
            
        }
        else
        {
            wizardHatEnabled = false;
            wizardHatButtonClicked = false;
        }
    }
}
