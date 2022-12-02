using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private float interval; 
    [SerializeField] private CanvasGroup playerDialogPanel;
    [SerializeField] private TextMeshProUGUI playerDialogText;
    // viewerNicknameText => TMP_Text?
    // viewerDialogText => TMP_Text?
    [SerializeField] private List<PlayerDialog> playerDialogs;
    [SerializeField] private List<ViewerDialog> viewerDialogs;
    [SerializeField] private ViewerDialog loopViewerDialogs;

    private void Start() 
    {
        ShowDialog("시작");
    }
    /// <summary> 
    /// 대사를 시작하고 싶은 곳에서 이 함수를 호출하세요. 매개변수로 대사의 ID를 사용합니다. 
    /// </summary>
    public void ShowDialog(string id)
    {
        PlayerDialog pDialog = playerDialogs.Find(x => x.id == id);
        // ViewerDialog vDialog = viewerDialogs.Find(x => x.id == id);

        if (pDialog == null) Debug.LogWarning("CAN NOT FIND PLAYER DIALOG");
        else StartCoroutine(ShowPlayerDialog(pDialog));
        // if (vDialog == null) Debug.LogWarning("CAN NOT FIND VIEWER DIALOG");
        // else StartCoroutine(ShowViewerDialog(vDialog));
    }

    private IEnumerator ShowPlayerDialog(PlayerDialog dialog) 
    {
        Tween tweener;
        yield return new WaitForSeconds(3);
        tweener = playerDialogPanel.DOFade(1, 1f);
        foreach (string c in dialog.content)
        {
            playerDialogText.text = c;
            tweener = playerDialogText.DOFade(1,1.5f);
            yield return tweener.WaitForCompletion();
            yield return new WaitForSeconds(interval);
            tweener = playerDialogText.DOFade(0, 0);   
        }
            tweener = playerDialogPanel.DOFade(0, 1.5f);   
    }
    // private IEnumerator ShowViewerDialog(ViewerDialog dialog)
    // {
    //     Tween tweener;
    //     foreach (var c in dialog.content)
    //     {

    //     }
    // }

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
    public string name;
    public string content;
}