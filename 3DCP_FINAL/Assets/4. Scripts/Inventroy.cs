using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventroy : MonoBehaviour
{
    List<Image> invenBaseImg = new List<Image>(); //image with inven item
    int invenCount, invenNum; //for inventory count control

    void Start()
    {
        invenCount = 0; invenNum = 0; //inven control reset
        for(int i= 1; i < 4; i++)
        {
            invenBaseImg.Add(GameObject.Find("Slot" + i).transform.GetChild(0).gameObject.GetComponent<Image>());
        }
    }

    void Update()
    {
        
    }

    //Add to Player or not..?
    public void ItemToInven()
    {
        Item itm = GameObject.Find("ItemController").GetComponent<Item>();

        invenNum += 1;

        invenBaseImg[invenCount].sprite = itm.itemsprite.GetComponent<SpriteRenderer>().sprite;
        invenBaseImg[invenCount].gameObject.SetActive(true);
        invenCount++;
    }
}
