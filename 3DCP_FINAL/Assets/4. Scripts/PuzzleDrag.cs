using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultpos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if(this.name == "pz1" && this.transform.position == )
        //{

        //}
        if (this.name == "pz2")
        {

        }
        if (this.name == "pz3")
        {

        }
        if (this.name == "pz4")
        {

        }
        if (this.name == "pz5")
        {

        }
        if (this.name == "pz6")
        {

        }
        if (this.name == "pz7")
        {

        }
        if (this.name == "pz8")
        {

        }
        if (this.name == "pz9")
        {

        }
        this.transform.position = defaultpos;
    }
}
