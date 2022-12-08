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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (gameStop == true)
            {
                gameoverTxt.SetActive(false);
                gameoverImg.SetActive(false);

                player.transform.position = new Vector3(-75.4f, 18f, -152.6f);
                ghost1.transform.position = new Vector3(-63.71f, 18.71f, -145.6f);

                player.SetActive(true);
                ghost1.SetActive(true);

                gameStop = false;
            }
        }
    }

    public IEnumerator GameOver1()
    {
        gameStop = true;

        player.SetActive(false);
        ghost1.SetActive(false);

        gameoverImg.SetActive(true);

        yield return new WaitForSecondsRealtime(2.0f);

        gameoverTxt.SetActive(true);
    }

    public IEnumerator GameOver2()
    {
        ghost2.SetActive(false);
        player.SetActive(false);

        gameoverImg.SetActive(true);

        yield return new WaitForSecondsRealtime(2.0f);

        gameoverTxt.SetActive(true);

        if (Input.GetKey(KeyCode.Return))
        {
            gameoverTxt.SetActive(false);
            gameoverImg.SetActive(false);

            ghost2.SetActive(true);
            player.SetActive(true);

            ghost2.transform.position = new Vector3(-111.4f, 18.71f, -102.1f);
            player.transform.position = new Vector3(-75.4f, 18f, -107.7f);
        }
    }

    public IEnumerator GameOver3()
    {
        ghost3.SetActive(false);
        player.SetActive(false);

        gameoverImg.SetActive(true);

        yield return new WaitForSecondsRealtime(2.0f);

        gameoverTxt.SetActive(true);

        if (Input.GetKey(KeyCode.Return))
        {
            gameoverTxt.SetActive(false);
            gameoverImg.SetActive(false);

            ghost3.SetActive(true);
            player.SetActive(true);

            ghost3.transform.position = new Vector3(-10.2f, -8f, -44.1f);
            player.transform.position = new Vector3(-6.18f, -9f, -92.5f);
        }
    }
}