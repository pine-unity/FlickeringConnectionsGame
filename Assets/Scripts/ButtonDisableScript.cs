using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisableScript : MonoBehaviour
{
    [SerializeField] Button button;
    // the purpose of this class is to fix some issues with the buttonUI
    public void enable()
    {
        button.interactable = false;
        button.interactable = true;
    }
    
}
