using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //public GameObject item;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;

    float distance1;
    float distance2;
    float distance3;

    public GameObject floor;
    public GameObject hole1;
    public GameObject hole2;
    public GameObject hole3;
    public GameObject hole4;
    public GameObject hole5;
    public GameObject hole6;
    public GameObject hole7;
    public GameObject hole8;
    public GameObject hole9;
    public GameObject hole10;
    public GameObject hole11;
    public GameObject hole12;
    public GameObject hole13;
    public GameObject hole14;
    public GameObject hole15;
    public GameObject hole16;
    public GameObject hole17;
    public GameObject hole18;
    public GameObject hole19;
    public GameObject hole20;

    public GameObject ghostWall;

    // Start is called before the first frame update
    void Start()
    {

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ghost1Coli")
        {
            if (ghost1.activeSelf == true)
            {
                ghostWall.SetActive(true);

                this.GetComponent<CamShake>().StartShake();

                floor.SetActive(false);

                hole1.SetActive(true);
                hole2.SetActive(true);
                hole3.SetActive(true);
                hole4.SetActive(true);
                hole5.SetActive(true);
                hole6.SetActive(true);
                hole7.SetActive(true);
                hole8.SetActive(true);
                hole9.SetActive(true);
                hole10.SetActive(true);
                hole11.SetActive(true);
                hole12.SetActive(true);
                hole13.SetActive(true);
                hole14.SetActive(true);
                hole15.SetActive(true);
                hole16.SetActive(true);
                hole17.SetActive(true);
                hole18.SetActive(true);
                hole19.SetActive(true);
                hole20.SetActive(true);

                ghost1.SetActive(false);
                ghost2.SetActive(true);
            }
        }

        if (other.name == "Ghost2Coli")
        {
            if (ghost2.activeSelf == true)
            {
                ghost2.SetActive(false);
                ghost3.SetActive(true);
            }
        }
    }

    IEnumerator Hole()
    {
        yield return new WaitForSecondsRealtime(5.0f);

        hole1.SetActive(false);
        hole2.SetActive(false);
        hole3.SetActive(false);
        hole4.SetActive(false);
        hole5.SetActive(false);
        hole6.SetActive(false);
        hole7.SetActive(false);
        hole8.SetActive(false);
        hole9.SetActive(false);
        hole10.SetActive(false);
        hole11.SetActive(false);
        hole12.SetActive(false);
        hole13.SetActive(false);
        hole14.SetActive(false);
        hole15.SetActive(false);
        hole16.SetActive(false);
        hole17.SetActive(false);
        hole18.SetActive(false);
        hole19.SetActive(false);
        hole20.SetActive(false);
    }
}