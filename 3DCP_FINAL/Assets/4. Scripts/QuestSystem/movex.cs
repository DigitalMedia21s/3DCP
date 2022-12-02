using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movex : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {   
            this.transform.Translate(-30f, 0, 0);
        }
    }
}
