using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultpos;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultpos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //print("ondragÀÏ¶§ xÁÂÇ¥ : " + this.transform.position.x + "yÁÂÇ¥ : " + this.transform.position.y);
        
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;

        if (this.name == "pz1")
        {
            if (this.transform.position.x >= 740 && this.transform.position.x <= 750
                && this.transform.position.y >= 855 && this.transform.position.y <= 865)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz2")
        {
            if (this.transform.position.x >= 960 && this.transform.position.x <= 970
                && this.transform.position.y >= 855 && this.transform.position.y <= 865)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz3")
        {
            if (this.transform.position.x >= 1180 && this.transform.position.x <= 1190
                && this.transform.position.y >= 855 && this.transform.position.y <= 865)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz4")
        {
            if (this.transform.position.x >= 740 && this.transform.position.x <= 750
                && this.transform.position.y >= 635 && this.transform.position.y <= 645)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(3).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz5")
        {
            if (this.transform.position.x >= 960 && this.transform.position.x <= 970
                && this.transform.position.y >= 635 && this.transform.position.y <= 645)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(4).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz6")
        {
            if (this.transform.position.x >= 1180 && this.transform.position.x <= 1190
                && this.transform.position.y >= 635 && this.transform.position.y <= 645)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(5).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz7")
        {
            if (this.transform.position.x >= 740 && this.transform.position.x <= 750
                && this.transform.position.y >= 415 && this.transform.position.y <= 425)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(6).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz8")
        {
            if (this.transform.position.x >= 960 && this.transform.position.x <= 970
                && this.transform.position.y >= 415 && this.transform.position.y <= 425)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(7).gameObject.SetActive(true);
            }
        }
        if (this.name == "pz9")
        {
            if (this.transform.position.x >= 1180 && this.transform.position.x <= 1190
                && this.transform.position.y >= 415 && this.transform.position.y <= 425)
            {
                this.gameObject.SetActive(false);
                GameObject.Find("Puzzle_BG").transform.GetChild(8).gameObject.SetActive(true);
            }
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = defaultpos;
    }
}
