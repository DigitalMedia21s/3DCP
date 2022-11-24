// DontDestroy 설정 -> 어차피 씬 변환 없음

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestLevel 
{
    START, FIRST, MID, SECOND
} 

[System.Serializable]
public class QuestData
{
    public int id; 
    public QuestLevel level;
    public string desc;
    public int reward;
    public bool open;
    public bool clear;

        // 퀘스트 완료 아이템 ?
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [SerializeField]
    List<QuestData> quests;
    QuestLevel currentLevel; 
    int levelCount =0; 
    List<QuestData> currentQuests; // 현재 수행중인 퀘스트 목록
    int[] levelCountMax;

    private void Awake() 
    {
        currentLevel = QuestLevel.START;
        levelCountMax = new int[System.Enum.GetValues(typeof(QuestLevel)).Length]; 
        
        foreach (var i in quests) // LevelCountMax 배열에 quests 리스트의 level의 개수를 세어서.. 원소로 넣음
        {
            if (i.level == QuestLevel.START) levelCountMax[0]++;
            else if (i.level == QuestLevel.FIRST) levelCountMax[1]++;
            else if (i.level == QuestLevel.MID) levelCountMax[2]++;
            else if (i.level == QuestLevel.SECOND) levelCountMax[3]++;
        }
        
    }

    /// <summary>
    /// 퀘스트 리스트에 현재 퀘스트 추가
    /// </summary>
    public void addCurrentQuests(int id) 
    {
        QuestData quest = getData(id);

        try 
        {
            quest!.open = true;
            currentQuests.Add(quest);
            Debug.Log("퀘스트를 추가함");
            // UI 동기화
        }       
        catch (NullReferenceException ex) 
        {
            Debug.Log("NULL");
        }

    }
    
    /// <summary> 
    /// 현재 퀘스트 완료
    /// </summary>
    public void clearQuest(int id) 
    {
        QuestData quest = getData(id);

        quest.clear = true;
        currentQuests.Remove(quest);
        // UI 동기화
        nextQuestLevel();
    }

    /// <summary> 
    /// 현재 레벨에서 완료한 퀘스트의 개수를 세고, 현재 레벨을 모두 완료하면 다음 레벨로 넘어감
    /// </summary>
    private void nextQuestLevel() 
    {
        levelCount ++;

        if (currentLevel == QuestLevel.START)
        {
            if (levelCount < levelCountMax[0]) return;
        }
        else if (currentLevel == QuestLevel.FIRST) 
        {
            if (levelCount < levelCountMax[1]) return;
        }
        else if (currentLevel == QuestLevel.MID)
        {
            if (levelCount < levelCountMax[2]) return;
        }
        else if (currentLevel == QuestLevel.SECOND)
        {
            return;
        }

        currentLevel ++;
        levelCount =0;
    }

    private QuestData getData(int id) 
    {
        return quests[id];
    } 

}
