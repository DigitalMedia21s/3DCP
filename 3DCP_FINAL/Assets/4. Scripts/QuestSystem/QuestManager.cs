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
    public Nickname name;
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
        currentLevel = QuestLevel.FIRST;
        levelCountMax = new int[Enum.GetValues(typeof(QuestLevel)).Length]; 
        
        int temp;
        foreach (var i in quests) // LevelCountMax 배열에 quests 리스트의 level의 개수를 세어서.. 원소로 넣음
        {
            temp = (int)i.level;
            levelCountMax[temp]++;
        }
    }

    public void addCurrentQuests(int id) 
    {
        QuestData quest = getData(id);
        try 
        {
            if(!checkQuestLevel(quest)) return;
            quest.open = true;
            currentQuests.Add(quest);
            Debug.Log("퀘스트를 추가함 : " + quest.id + " , " +quest.desc); 
        }       
        catch 
        {
            Debug.Log("NULL");
        }
        ui.resetQuestUI();
        SoundManager.instance.Play("addQuest");
    }

    public void clearQuest(int id) 
    {
        QuestData quest = getData(id);
        if(!checkQuestItem(quest)) return;

        quest.clear = true;
        stars += quest.reward;
        currentQuests.Remove(quest);
        quests.Remove(quest); // 아예 지워버릴지 아니면 재사용할지?
        StartCoroutine(ui.displayClearUI(quest.desc));
        ui.resetQuestUI();
        SoundManager.instance.Play("clearQuest");
        nextQuestLevel();
    }

    private void nextQuestLevel() 
    {
        levelCount ++;
        if (currentLevel == QuestLevel.SECOND) return;

        for (int i=0; i<levelCountMax.Length; i++)
        {
            if (currentLevel == (QuestLevel)i)
            {
                if (levelCount < levelCountMax[i]) return;
                break;
            }
        }
        currentLevel ++;
        levelCount =0;
        // FIRST의 퀘스트를 모두 완료하면 퀘스트 시작
        if(currentLevel == QuestLevel.MID && levelCount == 0)
            addCurrentQuests(4);
    }

    public QuestData getData(int id) 
    {
        return quests.Find(x => x.id == id);
    }

    public QuestData getCurrentData(int id) 
    {
        return currentQuests.Find(x => x.id == id);
    }

    private bool checkQuestLevel(QuestData data)
    {
        if (currentLevel == data.level)
            return true;
        Debug.Log("현재 레벨에 해당하지 않음");
        return false;
    }

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
