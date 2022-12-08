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
}