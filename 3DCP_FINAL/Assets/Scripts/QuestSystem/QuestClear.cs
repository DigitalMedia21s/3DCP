using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// 퀘스트 클리어 조건 <br/>
/// 아이템을 획득하거나 특정 구역에 진입한 경우 <br/>
/// 아이템을 획득한 경우, 
/// </summary>
public class QuestClear : MonoBehaviour
{
    public static QuestClear instance;

    public void clearQuest(int id) 
    {
        // 퀘스트 후 변하는게 reward로 별풍선 획득하는 것밖에 없으면 굳이 이 스크립트가 필요 없을 것 같기도 하다
        QuestManager.instance.clearQuest(id);
        // 아이템 획득 코드 -> 인벤토리에 추가 ??
    }
}
