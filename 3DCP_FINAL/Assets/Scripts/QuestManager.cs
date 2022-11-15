using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quest Data Struct
[System.Serializable]
public struct QuestData
{
    public string desc;
    public bool open;
    public bool clear;
}
public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private List<QuestData> questDatas;

    private void Awake() 
    {
        
    }
}
