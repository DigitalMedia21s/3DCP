using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairShake : MonoBehaviour
{
    float rotSpeed = 30f;

    public float shakeTime = 0.4f;

    private void Start()
    {
        //this.transform.rotation = Quaternion.Euler(75, 0, 0);
        StartCoroutine(Chair());
    }

    IEnumerator Chair()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            transform.Rotate(new Vector3(-rotSpeed * Time.deltaTime, 0, 0));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            transform.Rotate(new Vector3(rotSpeed * Time.deltaTime, 0, 0));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        StartCoroutine(Chair());
    }
}