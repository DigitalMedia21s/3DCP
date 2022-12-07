using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearQuest5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            QuestManager.instance.clearQuest(5);
            Destroy(this);
        }
    }
}
