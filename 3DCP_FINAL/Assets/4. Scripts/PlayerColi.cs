using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColi : MonoBehaviour
{
    public GameObject manager;
    public GameObject player;

    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ghost1Coli")
        {
            if (ghost1.activeSelf == true)
            {
                ghostWall.SetActive(true);

                player.GetComponent<CamShake>().StartShake();

                StartCoroutine(Hole());
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            if (ghost1.activeSelf == true)
            {
                StartCoroutine(manager.GetComponent<ReTry>().GameOver1());
            }
            else if (ghost2.activeSelf == true)
            {
                StartCoroutine(manager.GetComponent<ReTry>().GameOver2());
            }
            else if (ghost3.activeSelf == true)
            {
                StartCoroutine(manager.GetComponent<ReTry>().GameOver3());
            }
        }
    }
}