using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIO : MonoBehaviour
{
    new Renderer renderer;
    public GameObject mirrorTxt;
    public GameObject ghost;

    void Start()
    {
        renderer = mirrorTxt.GetComponent<Renderer>();
    }

    public void startFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut()
    {
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeIn()
    {
        int i = 0;
        while (i < 10)
        {
            i += 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(2f);

        ghost.SetActive(true);
    }
}
