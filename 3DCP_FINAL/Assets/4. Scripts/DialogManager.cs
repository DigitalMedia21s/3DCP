using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI playerDialogText;
    // viewerNicknameText => TMP_Text?
    // viewerDialogText => TMP_Text?
    [SerializeField] private List<PlayerDialog> playerDialogs;
    [SerializeField] private List<ViewerDialog> viewerDialogs;
    [SerializeField] private ViewerDialog loopViewerDialogs;

    /// <summary> 
    /// 대사를 시작하고 싶은 곳에서 이 함수를 호출하세요. 매개변수로 대사의 ID를 사용합니다. 
    /// </summary>
    public void ShowDialog(string id)
    {
        // player Dialogs 에서 해당 아이디를 찾는다. => 못찾으면 log 출력
        // 해당 id의 content를 출력한다.
        // content가 여러개일 경우 일정 시간을 간격으로 출력한다. 
        
    }
    private void ShowPlayerDialog(string id) 
    {
        PlayerDialog dialog = playerDialogs.Find(x => x.id == id);
        if (dialog == null) return;
        foreach (string c in dialog.content)
        {
                       
        }

    }
    private void ShowViewerDialog(string id) 
    {

    }

}



[System.Serializable]
public class PlayerDialog
{
    public string id; //String? Enum?
    public List<string> content;
}
[System.Serializable]
public class ViewerDialog
{
    public string id;
    public List<ViewerDialogSub> content;
}
[System.Serializable]
public struct ViewerDialogSub
{
    public NickName name;
    public string content;
}