using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public Transform questParent;
    private Transform[] questsUI;
    private TMP_Text datailText;
    private TMP_Text nickText;
    private TMP_Text costText;
    private int currentQuestCount;

    private void Start() 
    {
        questsUI = new Transform[questParent.transform.childCount];
        for (int i =0; i < questParent.childCount; i++)
        {
            questsUI[i] = questParent.GetChild(i);
        }
    }
    /// <summary> 
    /// 퀘스트를 시작하거나 완료하면 UI를 리셋함 
    /// </summary>
    public void resetQuestUI() 
    {   
        // UI 모두 해제
        for(int i =0; i<questsUI.Length; i++)
        {
            questsUI[i].gameObject.SetActive(false);
        }
        // 현재 수행중인 quest UI 설정
        int current = QuestManager.instance.CurrentQuests.Count -1; //looping parameter
        foreach(QuestData quest in QuestManager.instance.CurrentQuests)
        {
            if (current < 0 && current + 1 >= questsUI.Length)
            {
                Debug.LogError("Error!");
                return;
            }
            questsUI[current].gameObject.SetActive(true);
            questsUI[current].Find("Detail_Text").GetComponent<TextMeshProUGUI>().text = quest.desc;
            questsUI[current].Find("Nick_Text").GetComponent<TextMeshProUGUI>().text = quest.name.ToString();
            questsUI[current].Find("Cost_Text").GetComponent<TextMeshProUGUI>().text = quest.reward.ToString();
            // 사운드 추가
            // 페이드 효과 추가
            current--;
        }
    }
}
