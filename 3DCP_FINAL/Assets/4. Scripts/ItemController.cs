using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour
{
    string chooseObj_name;
    public GameObject inPos1, inPos2;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ItemSelect();
        }
    }

    public void ItemSelect()
    {
        //선택한 버튼의 이미지 이름 가져오기
        chooseObj_name = inPos1.GetComponent<Image>().sprite.name;

        WhatItem();
        print(chooseObj_name);
        inPos1.GetComponent<Image>().sprite = null; //인벤토리 이미지 삭제
        inPos1.SetActive(false); //인ㅂ네토리 none이미지 비활성화
    }

    //아이템과 상호작용이 필요하다면
    public void WhatItem()
    {
        if (chooseObj_name == "")
        {
            
        }
    }
}
