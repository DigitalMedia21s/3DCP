using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public GameObject Panel;
    GameObject parent;

    List<Image> invenBaseImg = new List<Image>(); //image with inven item
    int invenCount, invenNum; //for inventory count control

    public GameObject itemsprite;
    GameObject spriteImg1, spriteImg2, spriteImg3, spriteImg4, spriteImg5, spriteImg6, spriteImg7, spriteImg8, spriteImg9, spriteImg10, spriteImg11, spriteImg12; //each item sprite

    // Start is called before the first frame update
    void Start()
    {
        invenCount = 0;
        invenNum = 0; //inven control reset

        for (int i = 1; i < 13; i++)
        {
            invenBaseImg.Add(GameObject.Find("Slot" + i).transform.GetChild(0).gameObject.GetComponent<Image>());
        }

        spriteImg1 = GameObject.Find("AllItemSprite").transform.GetChild(0).gameObject;
        spriteImg2 = GameObject.Find("AllItemSprite").transform.GetChild(1).gameObject;
        spriteImg3 = GameObject.Find("AllItemSprite").transform.GetChild(2).gameObject;
        spriteImg4 = GameObject.Find("AllItemSprite").transform.GetChild(3).gameObject;
        spriteImg5 = GameObject.Find("AllItemSprite").transform.GetChild(4).gameObject;
        spriteImg6 = GameObject.Find("AllItemSprite").transform.GetChild(5).gameObject;
        spriteImg7 = GameObject.Find("AllItemSprite").transform.GetChild(6).gameObject;
        spriteImg8 = GameObject.Find("AllItemSprite").transform.GetChild(7).gameObject;
        spriteImg9 = GameObject.Find("AllItemSprite").transform.GetChild(8).gameObject;
        spriteImg10 = GameObject.Find("AllItemSprite").transform.GetChild(9).gameObject;
        spriteImg11 = GameObject.Find("AllItemSprite").transform.GetChild(10).gameObject;
        spriteImg12 = GameObject.Find("AllItemSprite").transform.GetChild(11).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            OpenPanel();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ItemToInven();
            DoorOpen();
        }
    }

    public void OpenPanel()
    {
        if(Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }

    public void DoorOpen()
    {
        Debug.Log(parent.name);
        Animator animator = parent.gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            //Debug.Log("test");
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
            parent = null;
        }
    }

    public void ItemToInven()
    {
        invenNum += 1;

        Debug.Log(itemsprite.name);

        invenBaseImg[invenCount].sprite = itemsprite.GetComponent<SpriteRenderer>().sprite;
        invenBaseImg[invenCount].gameObject.SetActive(true);
        invenCount++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("this´Â" + this.name);

            if (this.gameObject.name.Contains("door0coli") || this.gameObject.name.Contains("door1coli") || this.gameObject.name.Contains("door2coli") || this.gameObject.name.Contains("door3coli")
                || this.gameObject.name.Contains("door4coli") || this.gameObject.name.Contains("door5coli") || this.gameObject.name.Contains("door6coli") || this.gameObject.name.Contains("door7coli")
                || this.gameObject.name.Contains("door8coli") || this.gameObject.name.Contains("door9coli") || this.gameObject.name.Contains("door10coli"))
            {
                parent = transform.parent.gameObject;
                //Debug.Log("parent´Â" + parent.name);
            }


            if (this.gameObject.name == "knifeColi")
                itemsprite = spriteImg1;
            if (this.gameObject.name == "kitchPhtoColi")
                itemsprite = spriteImg2;
            if (this.gameObject.name == "livinPhtoColi")
                itemsprite = spriteImg3;
            if (this.gameObject.name == "guestPhotoColi")
                itemsprite = spriteImg4;
            if (this.gameObject.name == "memoColi")
                itemsprite = spriteImg5;
            if (this.gameObject.name == "basePhtoColi1")
                itemsprite = spriteImg6;
            if (this.gameObject.name == "basePhtoColi2")
                itemsprite = spriteImg7;
            if (this.gameObject.name == "basePhtoColi3")
                itemsprite = spriteImg8;
            if (this.gameObject.name == "basePhtoColi4")
                itemsprite = spriteImg9;
            if (this.gameObject.name == "basePhtoColi5")
                itemsprite = spriteImg10;
            if (this.gameObject.name == "basePhtoColi6")
                itemsprite = spriteImg11;
            //if (this.gameObject.name == "keyColi")
            //    itemsprite = spriteImg12;
        }
    }
}
