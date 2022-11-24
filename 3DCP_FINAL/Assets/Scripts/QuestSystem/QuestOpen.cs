using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 퀘스트 오픈 조건
// 어딘가에 진입했을 경우 (특정 오브젝트에 접촉하면 실행)
public class QuestOpen : MonoBehaviour
{
    // 접촉한 오브젝트의 이름은 Open + id
    private void OnTriggerEnter(Collider other) 
    {
        string name = other.name.Substring(4,1);
        int questNum;
        bool trial = (System.Int32.TryParse(name, out questNum));
        if (!trial)
        {
            return;
        }

        QuestManager.instance.addCurrentQuests(questNum);
    }

}
