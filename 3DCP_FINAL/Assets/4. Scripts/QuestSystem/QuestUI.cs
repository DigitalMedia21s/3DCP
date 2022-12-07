using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Transform questParent;
    [SerializeField] TextMeshProUGUI starCount;
    [SerializeField] private TextMeshProUGUI statusText;
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
        resetQuestUI();
    }

    public void resetQuestUI(bool isOpen = true) 
    {   
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
            questsUI[current].Find("Cost_Text").GetComponent<TextMeshProUGUI>().text = "상금" + quest.reward.ToString() + "만원";

            current--;
        }
        StartCoroutine(QuestEffect(isOpen));
        // 사운드 추가
        starCount.text = QuestManager.instance.Stars.ToString();
    }

    private IEnumerator QuestEffect(bool isOpen)
    {
        if (isOpen)
        {
            if(questsUI[0].gameObject.activeSelf == false) yield break;
            statusText.text = "NEW";
            statusText.color = Color.red;
        }
        else
        {
            statusText.text = "CLEAR";
            statusText.color = Color.yellow;
        }
        Sequence seq = DOTween.Sequence().SetAutoKill();
        seq.Append(statusText.DOFade(0, 1)).Append(statusText.DOFade(1, 1)).SetLoops(3);
        seq.Play();
        yield return seq.WaitForCompletion();
        statusText.DOFade(0, 1);
        yield return null;
    }
}
