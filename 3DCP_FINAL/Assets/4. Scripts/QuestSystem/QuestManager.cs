// DontDestroy 설정 -> 어차피 씬 변환 없음

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public int id; 
    public QuestLevel level;
    public string name;
    public string desc;
    public int reward;
    public bool open;
    public bool clear;
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [SerializeField]
    private List<QuestData> quests;
    private QuestLevel currentLevel; 
    private int levelCount =0; 
    private List<QuestData> currentQuests; // 현재 수행중인 퀘스트 목록
    public List<QuestData> CurrentQuests {get{return currentQuests;}} // QuestUI에서 사용하기 위한 읽기전용 프로퍼티
    private int[] levelCountMax;
    private QuestUI ui;
    private int stars;
    public int Stars {get{return stars;}}

    private void Awake() 
    {
        instance = this;
        stars =0;
        ui = GetComponent<QuestUI>();
        currentQuests = new();
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
            if(!checkQuestLevel(quest)) return;
            quest.open = true;
            currentQuests.Add(quest);
            Debug.Log("퀘스트를 추가함 : " + quest.id + " , " +quest.desc);
            // UI 동기화
        }       
        catch (NullReferenceException ex) 
        {
            Debug.Log("NULL");
        }
        ui.resetQuestUI();
    }
    
    /// <summary> 
    /// 현재 퀘스트 완료
    /// </summary>
    public void clearQuest(int id) 
    {
        QuestData quest = getData(id);
        if(!checkQuestItem(quest)) return;

        quest.clear = true;
        stars += quest.reward;
        currentQuests.Remove(quest);
        quests.Remove(quest); // 아예 지워버릴지 아니면 재사용할지?
        ui.resetQuestUI();
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

    /// <summary> 
    /// 아이디에 해당하는 QuestData를 quests 리스트에서 찾아서 반환함
    /// </summary>
    public QuestData getData(int id) 
    {
        return quests.Find(x => x.id == id);
    }

    public QuestData getCurrentData(int id) 
    {
        return currentQuests.Find(x => x.id == id);
    }

    /// <summary> 
    /// 인자로 받은 QuestData의 level이 currentLevel과 일치하는지 여부를 반환함
    /// </summary>
    private bool checkQuestLevel(QuestData data)
    {
        if (currentLevel == data.level)
            return true;
        Debug.Log("현재 레벨에 해당하지 않음");
        return false;
    }

    /// <summary> 
    /// 현재 아이템이 수행중인 퀘스트의 클리어 아이템인지?
    /// </summary>
    public bool checkQuestItem(QuestData data) 
    {
        try
        {
            currentQuests.Find(x => x == data);
            Debug.Log("currentQuests에 있음");
            return true;
        }
        catch
        {
            Debug.Log("currentQuests에 없음");
            return false;
        }
    }

}
