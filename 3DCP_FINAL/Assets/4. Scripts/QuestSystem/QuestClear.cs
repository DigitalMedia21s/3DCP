using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestClear : MonoBehaviour
{
    public static QuestClear instance;

    public void clearQuest(int id) 
    {
        QuestManager.instance.clearQuest(id);
        // 아이템 획득 코드 -> 인벤토리에 추가 ??

        // 완료 UI 띄우기

        // 추가로 id 마다 더 해야할 동작이 있으면 넣기
    }
}
