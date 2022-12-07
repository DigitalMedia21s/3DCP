using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //public GameObject item;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;

    float distance1;
    float distance2;
    float distance3;

    GameObject Hold;

    public GameObject gameoverUI;

    // Start is called before the first frame update
    void Start()
    {
        Hold = GameObject.Find("HoldItem").gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        distance1 = Vector3.Distance(ghost1.transform.position, this.transform.position);
        distance2 = Vector3.Distance(ghost2.transform.position, this.transform.position);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Hold.GetComponent<Image>().sprite.name == "item_knife")
            {
                //SoundManager.instance.Play("hit");

                if (distance1 <= 20.0f)
                {
                    //실제 귀신 공격
                    ghost1.GetComponent<GhostAI>().isMove = false;
                }

                if (distance2 <= 20.0f)
                {
                    //실제 귀신 공격
                    ghost2.GetComponent<GhostAI>().isMove = false;
                }

                if (distance3 <= 20.0f)
                {
                    //실제 귀신 공격
                    ghost3.GetComponent<GhostAI>().isMove = false;
                }
            }
        }
    }

    public void Retry()
    {
        Debug.Log("버튼");
        if (ghost1.activeSelf == true)
        {
            Debug.Log("1번 귀신");
            ghost1.transform.position = new Vector3(-63.71f, 18.71f, -145.6f);
            this.transform.position = new Vector3(-75.4f, 18f, -152.6f);
            gameoverUI.SetActive(false);
        }
        else if (ghost2.activeSelf == true)
        {
            ghost2.transform.position = new Vector3(-111.4f, 18.71f, -102.1f);
            this.transform.position = new Vector3(-75.4f, 18f, -107.7f);
            gameoverUI.SetActive(false);
        }
        else if (ghost3.activeSelf == true)
        {
            ghost3.transform.position = new Vector3(-10.2f, -8f, -44.1f);
            this.transform.position = new Vector3(-6.18f, -9f, -92.5f);
            gameoverUI.SetActive(false);
        }
    }
}