using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Animation : MonoBehaviour
{
    public GameObject Panel;
    GameObject parent;
    GameObject drawer;

    List<Image> invenBaseImg = new List<Image>(); //image with inven item
    int invenCount, invenNum; //for inventory count control

    public GameObject itemsprite;
    GameObject spriteImg1, spriteImg2, spriteImg3, spriteImg4, spriteImg5, spriteImg6, spriteImg7, spriteImg8, spriteImg9, spriteImg10, spriteImg11, spriteImg12; //each item sprite

    Image detailUI_Image;
    TextMeshProUGUI detailUI_Explain;
    TextMeshProUGUI detailUI_Name;

    GameObject Hold;

    bool dooranim, draweranim, item;

    // Start is called before the first frame update
    void Start()
    {
        invenCount = 0;
        invenNum = 0; //inven control reset

        for (int i = 1; i < 13; i++)
        {
            invenBaseImg.Add(GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.GetComponent<Image>());
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

        Hold = GameObject.Find("HoldItem").gameObject.transform.GetChild(0).gameObject;
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
            if(dooranim == true)
            {
                DoorOpen();
            }
            if(draweranim == true)
            {
                DrawerOpen();
            }
            if(item == true)
                ItemToInven();
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            GameObject.Find("Slot1").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot1").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GameObject.Find("Slot2").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot2").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            GameObject.Find("Slot3").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot3").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            GameObject.Find("Slot4").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot4").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GameObject.Find("Slot5").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot5").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            GameObject.Find("Slot6").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot6").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameObject.Find("Slot7").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot7").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            GameObject.Find("Slot8").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot8").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            GameObject.Find("Slot9").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot9").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            GameObject.Find("Slot10").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot10").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            GameObject.Find("Slot11").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot11").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            GameObject.Find("Slot12").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

            detailUI_Image = GameObject.Find("InvenDetailView").transform.GetChild(0).gameObject.GetComponent<Image>();
            detailUI_Explain = GameObject.Find("InvenDetailView").transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            detailUI_Name = GameObject.Find("InvenDetailView").transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();

            Hold.SetActive(true);
            Hold.GetComponent<Image>().sprite = GameObject.Find("Slot12").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

            DetailInfo();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot1").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot2").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot3").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot4").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot5").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot6").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot7").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot8").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot9").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot10").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot11").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Slot12").transform.GetChild(0).gameObject.SetActive(false);
            detailUI_Image.sprite = null;
            detailUI_Explain.text = null;
            detailUI_Name.text = null;
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
        //Debug.Log(parent.name);
        Animator animator = parent.gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            //Debug.Log("test");
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
            //parent = null;
            //dooranim = false;
        }
    }

    public void DrawerOpen()
    {
        Debug.Log(drawer.name);
        Animator animator = drawer.gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
            //drawer = null;
            draweranim = false;
            GameObject.Find("animForDrawerColi").gameObject.SetActive(false);
            //draweropen = true;
            GameObject.Find("2FRoom3Coli").transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ItemToInven()
    {
        invenNum += 1;

        Debug.Log(itemsprite.name);

        invenBaseImg[invenCount].sprite = itemsprite.GetComponent<SpriteRenderer>().sprite;
        invenBaseImg[invenCount].gameObject.SetActive(true);
        invenCount++;

        Debug.Log(itemsprite.GetComponent<SpriteRenderer>().sprite.name);

        if(itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_knife")
        {
            GameObject.Find("uploads_files_1924412_03+-+Knife").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_paper")
        {
            GameObject.Find("Paper").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_key")
        {
            GameObject.Find("Simple_02").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "itemui_image1-01")
        {
            GameObject.Find("photo (7)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image2-01")
        {
            GameObject.Find("photo (4)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image3-01")
        {
            GameObject.Find("photo (8)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image4-01")
        {
            GameObject.Find("photo (5)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image5-01")
        {
            GameObject.Find("photo (1)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image6-01")
        {
            GameObject.Find("photo (6)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image7-01")
        {
            GameObject.Find("photo (2)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image8-01")
        {
            GameObject.Find("photo").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image9-01")
        {
            GameObject.Find("photo (3)").gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("this��" + this.name);

            if (this.gameObject.name.Contains("door0coli") || this.gameObject.name.Contains("door1coli") || this.gameObject.name.Contains("door2coli") || this.gameObject.name.Contains("door3coli")
                || this.gameObject.name.Contains("door4coli") || this.gameObject.name.Contains("door5coli") || this.gameObject.name.Contains("door6coli") || this.gameObject.name.Contains("door7coli")
                || this.gameObject.name.Contains("door8coli") || this.gameObject.name.Contains("door9coli") || this.gameObject.name.Contains("door10coli"))
            {
                parent = transform.parent.gameObject;
                //Debug.Log("parent��" + parent.name);
                dooranim = true;
            }
            if (this.gameObject.name == "animForDrawerColi")
            {
                drawer = GameObject.Find("grpDraw_Anim").gameObject;
                draweranim = true;
            }
            if (this.gameObject.name == "knifeColi")
            {
                item = true;
                itemsprite = spriteImg1; 
            }
            if (this.gameObject.name == "kitchPhtoColi")
            {
                item = true;
                itemsprite = spriteImg2;
            }
            if (this.gameObject.name == "livinPhtoColi")
            {
                item = true;
                itemsprite = spriteImg3;
            }
            if (this.gameObject.name == "guestPhotoColi")
            {
                item = true;
                itemsprite = spriteImg4;
            }
            if (this.gameObject.name == "memoColi")
            {
                item = true;
                itemsprite = spriteImg5;
            }
            if (this.gameObject.name == "basePhtoColi1")
            {
                item = true;
                itemsprite = spriteImg6;
            }
            if (this.gameObject.name == "basePhtoColi2")
            {
                item = true;
                itemsprite = spriteImg7;
            }
            if (this.gameObject.name == "basePhtoColi3")
            {
                item = true;
                itemsprite = spriteImg8;
            }
            if (this.gameObject.name == "basePhtoColi4")
            {
                item = true;
                itemsprite = spriteImg9;
            }
            if (this.gameObject.name == "basePhtoColi5")
            {
                item = true;
                itemsprite = spriteImg10;
            }
            if (this.gameObject.name == "basePhtoColi6")
            {
                item = true;
                itemsprite = spriteImg11;
            }
            if (this.gameObject.name == "keyColi")
            {
                item = true;
                itemsprite = spriteImg12;
            }
        }
    }

    void DetailInfo()
    {
        if(Hold.GetComponent<Image>().sprite.name == "item_knife")
        {
            detailUI_Image.sprite = spriteImg1.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "���� ���ִ� �ֹ� ��Į. ������ �� �ִ� ���Ⱑ �ȴ�.";
            detailUI_Name.text = "�ξ� ��Į";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_paper")
        {
            detailUI_Image.sprite = spriteImg5.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "���� �۾��� ���� ����. ���� �ұ��ϴ�.";
            detailUI_Name.text = "�͸��� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image1-01")
        {
            detailUI_Image.sprite = spriteImg9.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image2-01")
        {
            detailUI_Image.sprite = spriteImg8.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image3-01")
        {
            detailUI_Image.sprite = spriteImg11.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image4-01")
        {
            detailUI_Image.sprite = spriteImg10.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image5-01")
        {
            detailUI_Image.sprite = spriteImg2.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image6-01")
        {
            detailUI_Image.sprite = spriteImg7.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image7-01")
        {
            detailUI_Image.sprite = spriteImg3.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image8-01")
        {
            detailUI_Image.sprite = spriteImg4.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image9-01")
        {
            detailUI_Image.sprite = spriteImg6.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "������ ���� ����. ������ �����̴�.";
            detailUI_Name.text = "���� ����";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_key")
        {
            detailUI_Image.sprite = spriteImg12.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "����� ����. ��� ���� �� �� �ִ�.";
            detailUI_Name.text = "����";
        }
    }
}
