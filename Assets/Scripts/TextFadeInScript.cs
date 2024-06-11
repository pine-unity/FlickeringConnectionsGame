using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInScript : MonoBehaviour
{
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.color = new Color(255, 255, 255, 0);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {

        text.color = new Color(255, 255, 255, 0);
        while (text.color.a < 1)
        {
            text.color = new Color(255, 255, 255, text.color.a + Time.deltaTime);
            yield return null;
        }
        
    }

    IEnumerator FadeOut()
    {
        text.color = new Color(255, 255, 255, 1);
        while (text.color.a > 0)
        {
            text.color = new Color(255, 255, 255, text.color.a - Time.deltaTime);
            yield return null;
        }
        
    }
}
