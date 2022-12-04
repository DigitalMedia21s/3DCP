using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //public GameObject item;
    public GameObject ghost;
    public GameObject rUi; //���� ui ����
    public GameObject gUi; //���� ui ����

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
            //����(�ִϸ��̼�)
            if (distance <= 8.0f)
            {
                //���� �ͽ� ����
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