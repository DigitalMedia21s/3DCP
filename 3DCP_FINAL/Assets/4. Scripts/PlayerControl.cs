using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //public GameObject item;
    public GameObject ghost;
    public GameObject rUi; //지금 ui 없음
    public GameObject gUi; //지금 ui 없음

    public GameObject ghost1;

    float distance;

    public GameObject ceiling;
    bool isGhost;

    // Start is called before the first frame update
    void Start()
    {
        isGhost = GameObject.Find("PlayerArmature").GetComponent<PlayerControl>().isGhost;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        distance = Vector3.Distance(ghost.transform.position, this.transform.position);

        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManager.instance.Play("hit");
            //공격(애니메이션)
            if (distance <= 8.0f)
            {
                //실제 귀신 공격
                GameObject.Find("Ghost").GetComponent<GhostAI>().isMove = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WallTrigger")
        {
            if (isGhost == true)
            {
                ceiling.SetActive(false);
            }
        }

        if (other.name == "GhostTrigger1")
        {
            ghost.SetActive(false);
            ghost1.SetActive(true);
        }
    }
}