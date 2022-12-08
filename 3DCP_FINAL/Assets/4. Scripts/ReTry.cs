using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTry : MonoBehaviour
{
    public GameObject player;

    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;

    public GameObject gameoverImg;
    public GameObject gameoverTxt;

    bool gameStop;
    bool isghost1;
    bool isghost2;
    bool isghost3;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (gameStop == true)
            {
                gameoverTxt.SetActive(false);
                gameoverImg.SetActive(false);

                SoundManager.instance.Play("restart_enter");

                if (isghost1 == true)
                {
                    isghost1 = false;

                    player.transform.position = new Vector3(-75.4f, 18f, -152.6f);
                    ghost1.transform.position = new Vector3(-63.71f, 18.71f, -145.6f);

                    player.SetActive(true);
                    ghost1.SetActive(true);
                }
                else if (isghost2 == true)
                {
                    isghost2 = false;

                    player.transform.position = new Vector3(-75.4f, 18f, -107.7f);
                    ghost2.transform.position = new Vector3(-111.4f, 18.71f, -102.1f);

                    player.SetActive(true);
                    ghost2.SetActive(true);
                }
                else if (isghost3 == true)
                {
                    isghost3 = false;

                    player.transform.position = new Vector3(-6.18f, -9f, -92.5f);
                    ghost3.transform.position = new Vector3(-10.2f, -8f, -44.1f);

                    player.SetActive(true);
                    ghost3.SetActive(true);
                }

                gameStop = false;
            }
        }
    }

    public IEnumerator GameOver1()
    {
        isghost1 = true;

        player.SetActive(false);
        ghost1.SetActive(false);

        gameoverImg.SetActive(true);
        gameoverTxt.SetActive(true);
        gameStop = true;

        yield return null;
    }

    public IEnumerator GameOver2()
    {
        isghost2 = true;

        player.SetActive(false);
        ghost2.SetActive(false);

        gameoverImg.SetActive(true);
        gameoverTxt.SetActive(true);
        gameStop = true;

        yield return null;
    }

    public IEnumerator GameOver3()
    {
        isghost3 = true;

        player.SetActive(false);
        ghost2.SetActive(false);

        gameoverImg.SetActive(true);
        gameoverTxt.SetActive(true);
        gameStop = true;

        yield return null;
    }
}