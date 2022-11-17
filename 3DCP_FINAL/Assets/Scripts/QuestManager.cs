// Scriptable Object 설정 -> 어차피 씬이 하나라 상관 없나?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestLevel 
{
    START, FIRST, MID, SECOND
} 

[System.Serializable]
public struct QuestData
{
    public int index;
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
    List<QuestData> currentQuests; // 현재 수행중인 퀘스트 목록

    private void Awake() 
    {
        currentLevel = QuestLevel.START;
    }

    private void Update() 
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
                
    }

    // 퀘스트 UI 활성화
    // 현재 수행중인 퀘스트 목록에 업데이트
    // Quest 함수
}
