using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(QuestManager.instance.checkQuestLevel(QuestLevel.FIRST))
        {
            if (other.name == "door0coli") DialogManager.instance.ShowDialog("복도_문앞");
            else if (other.name == "livinPhtoColi") DialogManager.instance.ShowDialog("거실_식탁");
            else if (other.name == "KitchenColi") DialogManager.instance.ShowDialog("부엌");
            else if (other.name == "Open2") DialogManager.instance.ShowDialog("부엌_시작");
            else if (other.name == "Open3") DialogManager.instance.ShowDialog("응접실_시작");
        }
        else if(QuestManager.instance.checkQuestLevel(QuestLevel.MID))
        {
            if (other.name == "Open5") DialogManager.instance.ShowDialog("1층_시작");
        }
        else if(QuestManager.instance.checkQuestLevel(QuestLevel.SECOND))
        {
            if (other.name == "Open6") DialogManager.instance.ShowDialog("침실_시작");
            else if (other.name == "2FRoom2Coli") DialogManager.instance.ShowDialog("욕실_안");
            else if (other.name == "StudyColi") DialogManager.instance.ShowDialog("서재");
            else if (other.name == "2FRoom3Coli") DialogManager.instance.ShowDialog("빈방");
        }
    }
}
