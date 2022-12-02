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
        //������ ��ư�� �̹��� �̸� ��������
        chooseObj_name = inPos1.GetComponent<Image>().sprite.name;

        WhatItem();
        print(chooseObj_name);
        inPos1.GetComponent<Image>().sprite = null; //�κ��丮 �̹��� ����
        inPos1.SetActive(false); //�Τ����丮 none�̹��� ��Ȱ��ȭ
    }

    //�����۰� ��ȣ�ۿ��� �ʿ��ϴٸ�
    public void WhatItem()
    {
        if (chooseObj_name == "")
        {
            
        }
    }
}
