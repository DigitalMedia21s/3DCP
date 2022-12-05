using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootShake : MonoBehaviour
{
    //public float shakeTime = 1.0f;
    public float shakeSpeed = 2.0f;
    public float shakeAmount = 2.5f;

    Transform foot;

    Vector3 originPosition;

    private void Start()
    {
        foot = this.transform;
        originPosition = foot.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
        foot.localPosition = Vector3.Lerp(foot.localPosition, randomPoint, Time.deltaTime * shakeSpeed);
        foot = this.transform;
    }
}
