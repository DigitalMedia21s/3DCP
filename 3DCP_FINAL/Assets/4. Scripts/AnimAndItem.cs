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
    //int invenCount, invenNum; //for inventory count control

    int photoNum;

    GameObject itemsprite;
    GameObject spriteImg1, spriteImg2, spriteImg3, spriteImg4, spriteImg5, spriteImg6, spriteImg7, spriteImg8, spriteImg9, spriteImg10, spriteImg11, spriteImg12; //each item sprite

    GameObject DetailView, deailImgObj, deailEXObj, deailNmObj;
    Image detailUI_Image;
    TextMeshProUGUI detailUI_Explain;
    TextMeshProUGUI detailUI_Name;

    GameObject Hold, getUIobj, bed;

    bool dooranim, draweranim, item, uiup, inkitch, inemproom, getknife, getphoto, start, blanket;
    //bool getitem;

    GameObject kitchendoor, emptyroomdoor, startUI, puzzle;

    // Start is called before the first frame update
    void Start()
    {
        startUI = GameObject.Find("StartUI");
        start = false;

        //invenCount = 0;
        //invenNum = 0; //inven control reset

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
        blanket = false;

        bed = GameObject.Find("PFB_Bed"); 
        puzzle = GameObject.Find("PzCanvas").transform.GetChild(0).gameObject;

        //i_kn = false; i_kp = false; i_lp = false; i_gp = false; i_me = false; i_ke = false;
        //i_b1 = false; i_b2 = false; i_b3 = false; i_b4 = false; i_b5 = false; i_b6 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.instance.Play("click_UI");
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
                print(dooranim + "<-문열기, 아이템->" + item);

                if (dooranim == true)
                {
                    print("문상태"+dooranim);
                    DoorOpen();
                    dooranim = false;
                }
                if (draweranim == true)
                {
                    DrawerOpen();
                }
                if (blanket == true)
                {
                    bed.transform.GetChild(1).gameObject.SetActive(false);
                    bed.transform.GetChild(2).gameObject.SetActive(true);
                    GameObject.Find("blanketColi").SetActive(false);
                    blanket = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //if (item == true)
                //{
                //    if(getitem == false) // 가지고 있지 않으면
                //    {
                //        //invenNum += 1;
                //        photoNum += 1;
                //        //invenCount++;
                //        ItemToInven();
                //        uiup = true;
                //        item = false;
                //        getitem = false;
                //    }
                //    //ItemToInven();
                //    //uiup = true;
                //    //item = false;
                //}
                if(item == true)
                {
                    ItemToInven();
                    uiup = true;
                    item = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
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
                SoundManager.instance.Play("click_UI");
                DetailView.SetActive(false);
                for (int i = 1; i < 13; i++)
                {
                    GameObject.Find("Slot" + i).transform.GetChild(0).gameObject.SetActive(false);
                }
                Hold.SetActive(false);
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
                SoundManager.instance.Play("click_UI");
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }

    public void DontOpenDoor()
    {
        if (inkitch == true)
        {
            //door 제자리로 회전하기 & 해당 door doorNcoli active false
            kitchendoor.GetComponent<Animator>().SetBool("open", false);
            SoundManager.instance.Play("open_door");
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
                    kitchendoor.transform.GetChild(1).gameObject.SetActive(true);
                    kitchendoor.GetComponent<Animator>().SetBool("open", true);
                }
            }
        }
        if (inemproom == true)
        {
            //위와 동일 
            emptyroomdoor.GetComponent<Animator>().SetBool("open", false);
            emptyroomdoor.transform.GetChild(1).gameObject.SetActive(false);

            //조건문
        }
    }

    public void DoorOpen()
    {
        //Debug.Log(parent.name);
        Animator animator = parent.gameObject.GetComponent<Animator>();

        if (animator != null)
        {
            //Debug.Log("test");
            SoundManager.instance.Play("open_door");

            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
            //parent = null;
            dooranim = true;
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
        //invenNum += 1;
        //photoNum += 1;
        SoundManager.instance.Play("pickUpItem");

        //invenBaseImg[invenCount].sprite = itemsprite.GetComponent<SpriteRenderer>().sprite;
        //invenBaseImg[invenCount].gameObject.SetActive(true);
        //invenCount++;

        //print("인벤순서" + invenNum + "인벤개수" + invenCount + "아이템개수" + photoNum);

        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_knife")
        {
            GameObject.Find("Slot3").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("uploads_files_1924412_03+-+Knife").gameObject.SetActive(false);
            QuestManager.instance.clearQuest(1);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_paper")
        {
            GameObject.Find("Slot5").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Paper").gameObject.SetActive(false);
            QuestManager.instance.clearQuest(6);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_key")
        {
            GameObject.Find("Slot6").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Simple_02").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "itemui_image1-01")
        {
            GameObject.Find("Slot10").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (7)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image2-01")
        {
            GameObject.Find("Slot9").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (4)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image3-01")
        {
            GameObject.Find("Slot12").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (8)").gameObject.SetActive(false);
            //i_b6 = true;
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image4-01")
        {
            GameObject.Find("Slot11").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (5)").gameObject.SetActive(false);
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image5-01")
        {
            GameObject.Find("Slot2").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (1)").gameObject.SetActive(false);
            QuestManager.instance.clearQuest(2);
            //i_kp = true;
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image6-01")
        {
            GameObject.Find("Slot8").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (6)").gameObject.SetActive(false);
            //i_b2 = true;
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image7-01")
        {
            GameObject.Find("Slot1").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (2)").gameObject.SetActive(false);
            QuestManager.instance.clearQuest(0);
            //i_lp = true;
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image8-01")
        {
            GameObject.Find("Slot4").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo").gameObject.SetActive(false);
            QuestManager.instance.clearQuest(3);
            //i_gp = true;
        }
        if (itemsprite.GetComponent<SpriteRenderer>().sprite.name == "item_image9-01")
        {
            GameObject.Find("Slot7").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("photo (3)").gameObject.SetActive(false);
            //i_b1 = true;
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
            Debug.Log("this는" + this.name);

            if (this.gameObject.name.Contains("door0coli") || this.gameObject.name.Contains("door1coli") || this.gameObject.name.Contains("door2coli") 
                || this.gameObject.name.Contains("door4coli") || this.gameObject.name.Contains("door5coli") || this.gameObject.name.Contains("door6coli") 
                || this.gameObject.name.Contains("door7coli") || this.gameObject.name.Contains("door8coli") || this.gameObject.name.Contains("door9coli"))
            {
                parent = transform.parent.gameObject;
                // Debug.Log("parent는" + parent.name);
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
                blanket = true;
            }
            if (this.gameObject.name == "door3coli")
            {
                Debug.Log(Hold.GetComponent<Image>().sprite.name);
                //콜리더가 서재 문일 때 getKey가 true면 && hold 스프라이트 이름이 item_key이면 애니메이션 적용 & 인벤토리에서 key삭제
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
            if (this.gameObject.name == "guestPhtoColi")
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
            // Dialog 삽입으로 추가
            if(this.gameObject.name.Contains("door0coli")) DialogManager.instance.ShowDialog("복도_문앞");
        }
    }

    void DetailInfo()
    {
        if(Hold.GetComponent<Image>().sprite.name == "item_knife")
        {
            detailUI_Image.sprite = spriteImg1.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "날이 서있는 주방 식칼. 위협할 수 있는 무기가 된다.";
            detailUI_Name.text = "부엌 식칼";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_paper")
        {
            detailUI_Image.sprite = spriteImg5.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "붉은 글씨로 적힌 쪽지. 뭔가 불길하다.";
            detailUI_Name.text = "익명의 쪽지";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image1-01")
        {
            detailUI_Image.sprite = spriteImg9.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image2-01")
        {
            detailUI_Image.sprite = spriteImg8.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image3-01")
        {
            detailUI_Image.sprite = spriteImg11.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image4-01")
        {
            detailUI_Image.sprite = spriteImg10.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image5-01")
        {
            detailUI_Image.sprite = spriteImg2.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image6-01")
        {
            detailUI_Image.sprite = spriteImg7.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image7-01")
        {
            detailUI_Image.sprite = spriteImg3.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image8-01")
        {
            detailUI_Image.sprite = spriteImg4.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_image9-01")
        {
            detailUI_Image.sprite = spriteImg6.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "조각난 사진 조각. 섬뜩한 사진이다.";
            detailUI_Name.text = "사진 조각";
        }
        if (Hold.GetComponent<Image>().sprite.name == "item_key")
        {
            detailUI_Image.sprite = spriteImg12.GetComponent<SpriteRenderer>().sprite;
            detailUI_Explain.text = "어딘가의 열쇠. 잠긴 곳을 열 수 있다.";
            detailUI_Name.text = "열쇠";
        }
    }
}
