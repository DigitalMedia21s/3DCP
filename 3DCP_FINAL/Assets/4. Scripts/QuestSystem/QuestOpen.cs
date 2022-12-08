using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOpen : MonoBehaviour
{
    // Player에게 부착
    // 접촉한 오브젝트의 이름은 Open + id
    private void OnTriggerEnter(Collider other) 
    {
        string name = other.name.Substring(0,4);
        if (name!="Open") return; 
        name = other.name.Substring(4);
        int questNum;
        bool trial = (System.Int32.TryParse(name, out questNum));
        
        if (!trial)
        {
            return;
        }

        if (QuestManager.instance.addCurrentQuests(questNum))
            Destroy(other);
    }
}
