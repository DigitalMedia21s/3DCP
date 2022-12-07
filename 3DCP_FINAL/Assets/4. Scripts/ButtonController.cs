using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;

    public GameObject gameoverUI;

    public void Retry()
    {
        Debug.Log("¹öÆ°");
        if (ghost1.activeSelf == true)
        {
            Debug.Log("1¹ø ±Í½Å");
            ghost1.transform.position = new Vector3(-63.71f, 18.71f, -145.6f);
            this.transform.position = new Vector3(-75.4f, 18f, -152.6f);
            gameoverUI.SetActive(false);
            Time.timeScale = 1;
        }
        else if (ghost2.activeSelf == true)
        {
            ghost2.transform.position = new Vector3(-111.4f, 18.71f, -102.1f);
            this.transform.position = new Vector3(-75.4f, 18f, -107.7f);
            gameoverUI.SetActive(false);
            Time.timeScale = 1;
        }
        else if (ghost3.activeSelf == true)
        {
            ghost3.transform.position = new Vector3(-10.2f, -8f, -44.1f);
            this.transform.position = new Vector3(-6.18f, -9f, -92.5f);
            gameoverUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
