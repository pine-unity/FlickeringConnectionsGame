using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickScript : MonoBehaviour
{
    public void LoadGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
