using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultpos;
    public bool clear = false;

    GameObject PzBg;
    GameObject[] pz = new GameObject[9];
    public GameObject check0, check1, check2, check3, check4, check5, check6, check7, check8;

    public Image Panel;
    float time = 0f;
    float F_time = 2f;

    void Start()
    {
        PzBg = GameObject.Find("Puzzle_BG");
        for (int i = 0; i < 9; i++)
        {
            pz[i] = PzBg.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (PzBg.transform.childCount <= 9)
        {
            clear = true;
            print("ÆÛÁñÅ¬¸®¾î");
            StartCoroutine(FadeFlow());
        }
    }

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

    void ChectAndDestroy()
    {
        if (pz[0].activeSelf == true)
        {
            Destroy(check0);
        }
        if (pz[1].activeSelf == true)
        {
            Destroy(check1);
        }
        if (pz[2].activeSelf == true)
        {
            Destroy(check2);
        }
        if (pz[3].activeSelf == true)
        {
            Destroy(check3);
        }
        if (pz[4].activeSelf == true)
        {
            Destroy(check4);
        }
        if (pz[5].activeSelf == true)
        {
            Destroy(check5);
        }
        if (pz[6].activeSelf == true)
        {
            Destroy(check6);
        }
        if (pz[7].activeSelf == true)
        {
            Destroy(check7);
        }
        if (pz[8].activeSelf == true)
        {
            Destroy(check8);
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultpos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;

        if (this.name == "pz1")
        {
            if (this.transform.position.x >= 740 && this.transform.position.x <= 750
                && this.transform.position.y >= 855 && this.transform.position.y <= 865)
            {
                this.gameObject.SetActive(false);
                pz[0].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz2")
        {
            if (this.transform.position.x >= 960 && this.transform.position.x <= 970
                && this.transform.position.y >= 855 && this.transform.position.y <= 865)
            {
                this.gameObject.SetActive(false);
                pz[1].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz3")
        {
            if (this.transform.position.x >= 1180 && this.transform.position.x <= 1190
                && this.transform.position.y >= 855 && this.transform.position.y <= 865)
            {
                this.gameObject.SetActive(false);
                pz[2].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz4")
        {
            if (this.transform.position.x >= 740 && this.transform.position.x <= 750
                && this.transform.position.y >= 635 && this.transform.position.y <= 645)
            {
                this.gameObject.SetActive(false);
                pz[3].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz5")
        {
            if (this.transform.position.x >= 960 && this.transform.position.x <= 970
                && this.transform.position.y >= 635 && this.transform.position.y <= 645)
            {
                this.gameObject.SetActive(false);
                pz[4].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz6")
        {
            if (this.transform.position.x >= 1180 && this.transform.position.x <= 1190
                && this.transform.position.y >= 635 && this.transform.position.y <= 645)
            {
                this.gameObject.SetActive(false);
                pz[5].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz7")
        {
            if (this.transform.position.x >= 740 && this.transform.position.x <= 750
                && this.transform.position.y >= 415 && this.transform.position.y <= 425)
            {
                this.gameObject.SetActive(false);
                pz[6].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz8")
        {
            if (this.transform.position.x >= 960 && this.transform.position.x <= 970
                && this.transform.position.y >= 415 && this.transform.position.y <= 425)
            {
                this.gameObject.SetActive(false);
                pz[7].SetActive(true);
                ChectAndDestroy();
            }
        }
        if (this.name == "pz9")
        {
            if (this.transform.position.x >= 1180 && this.transform.position.x <= 1190
                && this.transform.position.y >= 415 && this.transform.position.y <= 425)
            {
                this.gameObject.SetActive(false);
                pz[8].SetActive(true);
                ChectAndDestroy();
            }
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = defaultpos;
    }
}
