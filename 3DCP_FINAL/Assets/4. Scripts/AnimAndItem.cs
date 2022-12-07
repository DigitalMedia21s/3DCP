using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimAndItem : MonoBehaviour
{
    public GameObject Panel;
    GameObject parent;
    GameObject drawer;

    List<Image> invenBaseImg = new List<Image>(); //image with inven item
    int invenCount, invenNum; //for inventory count control

    int photoNum;

    public GameObject itemsprite;
    GameObject spriteImg1, spriteImg2, spriteImg3, spriteImg4, spriteImg5, spriteImg6, spriteImg7, spriteImg8, spriteImg9, spriteImg10, spriteImg11, spriteImg12; //each item sprite

    GameObject DetailView, deailImgObj, deailEXObj, deailNmObj;
    Image detailUI_Image;
    TextMeshProUGUI detailUI_Explain;
    TextMeshProUGUI detailUI_Name;

    GameObject Hold, getUIobj;

    bool dooranim, draweranim, item, uiup, inkitch, inemproom, getknife, getphoto, start;

    GameObject kitchendoor, emptyroomdoor, startUI, puzzle;

    // Start is called before the first frame update
    void Start()
    {
        startUI = GameObject.Find("StartUI");
        start = false;

        invenCount = 0;
        invenNum = 0; //inven control reset

        for (int i = 1; i < 13; i++)
        {
            invenBaseImg.Add(GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.GetComponent<Image>());
        }

        photoNum = 0;

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

        getUIobj = GameObject.Find("GetUI").gameObject.transform.GetChild(0).gameObject;

        DetailView = GameObject.Find("InvenUI").transform.GetChild(0).gameObject;
        deailImgObj = DetailView.transform.GetChild(0).gameObject;
        deailEXObj = DetailView.transform.GetChild(1).gameObject;
        deailNmObj = DetailView.transform.GetChild(2).gameObject;
        detailUI_Image = deailImgObj.GetComponent<Image>();
        detailUI_Explain = deailEXObj.GetComponent<TextMeshProUGUI>();
        detailUI_Name = deailNmObj.GetComponent<TextMeshProUGUI>();

        kitchendoor = GameObject.Find("door2coli").transform.parent.gameObject;
        //emptyroomdoor = GameObject.Find("").transform.parent.gameObject;

        getknife = false;
        getphoto = false;

        puzzle = GameObject.Find("PzCanvas").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            startUI.SetActive(false);
            start = true;
        }
        if(start == true)
        {
            DontOpenDoor();

            if (uiup == true)
            {
                StartCoroutine("GetUIroutine");
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenPanel();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (dooranim == true)
                {
                    DoorOpen();
                }
                if (draweranim == true)
                {
                    DrawerOpen();
                }
                if (item == true)
                {
                    ItemToInven();
                    uiup = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                GameObject.Find("Slot1").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot1").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                GameObject.Find("Slot2").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot2").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                GameObject.Find("Slot3").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot3").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                GameObject.Find("Slot4").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot4").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                GameObject.Find("Slot5").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot5").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                GameObject.Find("Slot6").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot6").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                GameObject.Find("Slot7").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot7").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                GameObject.Find("Slot8").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot8").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                GameObject.Find("Slot9").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot9").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                GameObject.Find("Slot10").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot10").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F11))
            {
                GameObject.Find("Slot11").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot11").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.F12))
            {
                GameObject.Find("Slot12").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("InvenUI").transform.GetChild(0).gameObject.SetActive(true);

                deailImgObj.SetActive(true);
                deailEXObj.SetActive(true);
                deailNmObj.SetActive(true);

                Hold.SetActive(true);
                Hold.GetComponent<Image>().sprite = GameObject.Find("Slot12").transform.GetChild(1).gameObject.GetComponent<Image>().sprite;

                DetailInfo();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DetailView.SetActive(false);
                for (int i = 1; i < 13; i++)
                {
                    GameObject.Find("Slot" + i).transform.GetChild(0).gameObject.SetActive(false);
                }
                detailUI_Image.sprite = null;
                deailImgObj.SetActive(false);
                detailUI_Explain.text = "";
                deailEXObj.SetActive(false);
                detailUI_Name.text = "";
                deailEXObj.SetActive(false);
            }
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

    public void DontOpenDoor()
    {
        if (inkitch == true)
        {
            //door ���ڸ��� ȸ���ϱ� & �ش� door doorNcoli active false
            kitchendoor.GetComponent<Animator>().SetBool("open", false);
            kitchendoor.transform.GetChild(1).gameObject.SetActive(false);
            for (int i = 1; i < 13; i++)
            {
                if(GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.GetComponent<Image>().sprite.name == "item_knife")
                {
                    getknife = true;
                    Debug.Log(getknife);
                }
                if(GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.GetComponent<Image>().sprite.name == "item_image5-01")
                {
                    getphoto = true;
                    Debug.Log(getphoto);
                }
                if(getknife == true && getphoto == true)
                {
                    kitchendoor.GetComponent<Animator>().SetBool("open", true);
                }
            }
        }
        if (inemproom == true)
        {
            //���� ���� 
            emptyroomdoor.GetComponent<Animator>().SetBool("open", false);
            emptyroomdoor.transform.GetChild(1).gameObject.SetActive(false);

            //���ǹ�
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
            dooranim = false;
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
        photoNum += 1;

        invenBaseImg[invenCount].sprite = itemsprite.GetComponent<SpriteRenderer>().sprite;
        invenBaseImg[invenCount].gameObject.SetActive(true);
        invenCount++;

        print("�κ�����" + invenNum + "�κ�����" + invenCount + "�����۰���" + photoNum);

        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_knife")
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

    IEnumerator GetUIroutine()
    {
        getUIobj.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        uiup = false;
        getUIobj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("this��" + this.name);

            if (this.gameObject.name.Contains("door0coli") || this.gameObject.name.Contains("door1coli") || this.gameObject.name.Contains("door2coli") 
                || this.gameObject.name.Contains("door4coli") || this.gameObject.name.Contains("door5coli") || this.gameObject.name.Contains("door6coli") 
                || this.gameObject.name.Contains("door7coli") || this.gameObject.name.Contains("door8coli") || this.gameObject.name.Contains("door9coli"))
            {
                parent = transform.parent.gameObject;
                Debug.Log("parent��" + parent.name);
                dooranim = true;
            }
            else
            {
                parent = null;
                dooranim = false;
            }
            if (this.gameObject.name == "KitchenColi")
            {
                inkitch = true;
            }
            if (this.gameObject.name == " ")
            {
                inemproom = true;
            }
            if (this.gameObject.name == "blanketColi")
            {
                //���� �̺� ��Ȱ ���� �̺� Ȱ��ȭ ħ���ݸ��� ��Ȱ
            }
            if (this.gameObject.name == "door3coli")
            {
                Debug.Log(Hold.GetComponent<Image>().sprite.name);
                //�ݸ����� ���� ���� �� getKey�� true�� && hold ��������Ʈ �̸��� item_key�̸� �ִϸ��̼� ���� & �κ��丮���� key����
                if(Hold.GetComponent<Image>().sprite.name == "item_key")
                {
                    parent = transform.parent.gameObject;
                    dooranim = true;
                    for(int i = 1; i < 13; i++)
                    {
                        if(GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.GetComponent<Image>().sprite.name == "item_key")
                        {
                            GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
                            GameObject.Find("Slot" + i).transform.GetChild(1).gameObject.SetActive(false);
                        }
                    }
                }
            }
            if (this.gameObject.name == "door10coli")
            {
                if(photoNum > 11)
                {
                    puzzle.gameObject.SetActive(true);
                }
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
            if (this.gameObject.name == "basePEhtoColi2")
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
    //private void OnTriggerExit(Collider other)
    //{
    //    item = false;
    //}

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
