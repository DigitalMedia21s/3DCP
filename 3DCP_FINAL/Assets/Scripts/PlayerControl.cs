using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject item;
    public GameObject ghost;
    public GameObject rUi; //지금 ui 없음
    public GameObject gUi; //지금 ui 없음

    float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Pick();
        Attack();
    }

    void Pick()
    {
        distance = Vector3.Distance(item.transform.position, this.transform.position);

        if (distance <= 3.0f)
        {
            Debug.Log("아이템 발견");
            //rUi.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                //줍기
                item.SetActive(false);
                //rUi.SetActive(false);
            }
        }
    }

    void Attack()
    {
        distance = Vector3.Distance(ghost.transform.position, this.transform.position);

        if (Input.GetKeyDown(KeyCode.F))
        {
            //공격(애니메이션)
            if (distance <= 8.0f)
            {
                //실제 귀신 공격
                GameObject.Find("Ghost").GetComponent<GhostAI>().isMove = false;
            }
        }
    }
}