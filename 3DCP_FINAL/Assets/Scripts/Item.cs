using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    GameObject chosenitem; //what item choose
    public GameObject itemsprite; //for allocate inven item sprite
    public GameObject spriteImg1, spriteImg2, spriteImg3, spriteImg4, spriteImg5, spriteImg6, spriteImg7; //each item sprite

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemControl()
    {
        //Plus to do: set Item+N Tag to Item & set button sprite of allitemsprite in order with pair
        chosenitem = EventSystem.current.currentSelectedGameObject;

        if (chosenitem.tag == "Item1")
        {
            itemsprite = spriteImg1;
        }
        if (chosenitem.tag == "Item2")
        {
            itemsprite = spriteImg2;
        }
        if (chosenitem.tag == "Item3")
        {
            itemsprite = spriteImg3;
        }
        if (chosenitem.tag == "Item4")
        {
            itemsprite = spriteImg4;
        }
        if (chosenitem.tag == "Item5")
        {
            itemsprite = spriteImg5;
        }
        if (chosenitem.tag == "Item6")
        {
            itemsprite = spriteImg6;
        }
        if (chosenitem.tag == "Item7")
        {
            itemsprite = spriteImg7;
        }
    }
}
