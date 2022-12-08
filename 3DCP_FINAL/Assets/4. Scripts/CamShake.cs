using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    float shakeTime = 3.0f;
    float shakeSpeed = 2.0f;
    float shakeAmount = 20.0f;

    Transform cam;

    // Update is called once per frame
    void Update()
    {
        cam = this.transform;

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    StartCoroutine(Shake());
        //}
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Debug.Log("Ä«¸Þ¶ó");
        Vector3 originPosition = cam.localPosition;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            SoundManager.instance.Play("falldown");

            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        cam.localPosition = originPosition;
    }

}