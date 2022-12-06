using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    GameObject pzcheck;

    void Start()
    {
        pzcheck = GameObject.Find("Puzzle_BG");
    }

    void Update()
    {
        if(pzcheck.GetComponent<PuzzleDrag>().clear == true)
        {
            StartCoroutine(FadeFlow());
        }
    }

    //public void Fade()
    //{
    //    StartCoroutine(FadeFlow());
    //}

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
}
