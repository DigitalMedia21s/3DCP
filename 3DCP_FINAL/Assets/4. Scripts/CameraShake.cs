using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTime = 1.0f;
    public float shakeSpeed = 2.0f;
    public float shakeAmount = 1.0f;

    Transform cam;

<<<<<<< HEAD
    // Update is called once per frame
    void Update()
=======
    private void Start()
    {

    }

    private void Update()
>>>>>>> 25d60423f10efa43a2ea8ca3be3b0ff232f9d8df
    {
        cam = this.transform;

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        Vector3 originPosition = cam.localPosition;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        cam.localPosition = originPosition;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 25d60423f10efa43a2ea8ca3be3b0ff232f9d8df
