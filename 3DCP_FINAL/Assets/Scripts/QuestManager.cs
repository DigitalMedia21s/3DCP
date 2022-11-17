// Scriptable Object 설정 -> 어차피 씬이 하나라 상관 없나?

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
    public bool open;
    public bool clear;
}

public class QuestManager : MonoBehaviour
{
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

    // private void startTrigger (Collider other) // 각 level 마다 만들어준 다음에 currentlevel? => 맞게 실행
    // {
    //     if (other.name == "LivingRoom")
    //     {
            
    //     }
    // }

    private void addCurrentQuests(QuestData quest) 
    {
        try 
        {
            quest!.open = true;
            currentQuests.Add(quest);
            // UI 동기화
        }       
        catch (NullReferenceException ex) 
        {
            Debug.Log("NULL");
        }

    }
    
    private void clearQuest(QuestData quest) 
    {
        quest.clear = true;
        currentQuests.Remove(quest);
        // UI 동기화
        nextQuestLevel();
    }

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
}

// => player에서
    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.tag == "QuestTrigger") // 퀘스트 발동 조건
    //     {

    //     }
    //     else if (other.tag == "QuestClearItem") // 퀘스트 완료 조건 => 나중에 클릭이나 뭐로 바꿀건데 일단 넣어놓음 
    //     {
    //         // 클릭했을 때
    //         // 태그가 QuestClearItem이고
    //         // 이름이 
    //     }
    // }