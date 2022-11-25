using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject item;
    public GameObject ghost;
    public GameObject rUi; //���� ui ����
    public GameObject gUi; //���� ui ����

    float distance;

    public GameObject ceiling;
    public bool isGhost;

    // Start is called before the first frame update
    void Start()
    {
        isGhost = false;
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
            Debug.Log("������ �߰�");
            //rUi.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                //�ݱ�
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
    }
}