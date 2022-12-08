using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.Play("before", SoundType.BGM);
        Screen.SetResolution(1920, 1080, true);
    }

}
