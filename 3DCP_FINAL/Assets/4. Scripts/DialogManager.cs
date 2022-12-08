using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using DG.Tweening;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    
    [SerializeField] private float interval;
    [SerializeField] private Transform parentContent;
    [SerializeField] private CanvasGroup playerDialogPanel;
    [SerializeField] private TextMeshProUGUI playerDialogText;
    [SerializeField] private GameObject viewerTextPrefab;

    // viewerNicknameText => TMP_Text?
    // viewerDialogText => TMP_Text?
    private DialogDatas datas;
    private Queue<GameObject> viewerTextQueue;
    private bool displayLoopDialog = false;

    private void Awake()
    {
        Load();
    }
    private void Start()
    {
        instance = this;
        viewerTextQueue = new();
        ShowDialog("복도");
        StartCoroutine(ShowLoopingDialog()); // 반복
    }

    public void ShowDialog(string id)
    {
        PlayerDialog pDialog = datas.playerDialogs.Find(x => x.id.Equals(id));
        ViewerDialog vDialog = datas.viewerDialogs.Find(x => x.id.Equals(id));
        // UI 그리기
        if (pDialog == null) Debug.LogError("CAN NOT FIND PLAYER DIALOG");
        else StartCoroutine(ShowPlayerDialog(pDialog));
        if (vDialog == null) Debug.LogError("CAN NOT FIND VIEWER DIALOG"); 
        else StartCoroutine(ShowViewerDialog(vDialog));
        // 한 번 띄운 대사 삭제
        datas.Remove(id);
    }
    private IEnumerator ShowPlayerDialog(PlayerDialog dialog)
    {
        Tween tweener;
        yield return new WaitForSeconds(3);
        tweener = playerDialogPanel.DOFade(1, 1f);
        foreach (string c in dialog.content)
        {
            playerDialogText.text = c;
            tweener = playerDialogText.DOFade(1, 1.5f);
            yield return tweener.WaitForCompletion();
            yield return new WaitForSeconds(interval);
            tweener = playerDialogText.DOFade(0, 0);
        }
        tweener = playerDialogPanel.DOFade(0, 1.5f);
    }
    private IEnumerator ShowViewerDialog(ViewerDialog dialog)
    {
        displayLoopDialog = false;
        Debug.Log("ShowViewerDialog");
        foreach (var c in dialog.content)
        {
            GameObject clone = Instantiate(viewerTextPrefab, parentContent);
            clone.GetComponent<TextMeshProUGUI>().text = $"{c.name} : {c.content}";
            viewerTextQueue.Enqueue(clone);
            if (viewerTextQueue.Count > 6) Destroy(viewerTextQueue.Dequeue());
            yield return new WaitForSeconds(interval);
        }
        displayLoopDialog = true;
    }
    private IEnumerator ShowLoopingDialog()
    {
        Debug.Log("ShowLoopingDialog");
        ViewerDialog dialog = datas.viewerDialogs.Find(x => x.id == "반복");

        while (true) 
        {
            yield return null;
            if (displayLoopDialog)
            {
                // yield return null;
                foreach (var c in dialog.content)
                {
                    GameObject clone = Instantiate(viewerTextPrefab, parentContent);
                    clone.GetComponent<TextMeshProUGUI>().text = $"{c.name} : {c.content}";
                    viewerTextQueue.Enqueue(clone);
                    if (viewerTextQueue.Count > 6) Destroy(viewerTextQueue.Dequeue());
                    yield return new WaitForSeconds(interval);
                }
            }
        }

    }
    public void Load()
    {
        Debug.Log("Load 시작");

        TextAsset t = Resources.Load<TextAsset>("DialogData");
        datas = JsonUtility.FromJson<DialogDatas>(t.text);
        Debug.Log("Complete Data Load");
    }
}

[System.Serializable]
public class DialogDatas
{
    public List<PlayerDialog> playerDialogs; // => dictionary? can not serialize
    public List<ViewerDialog> viewerDialogs;

    public void Remove(string id)
    {
        playerDialogs.Remove(playerDialogs.Find(x => x.id.Equals(id))); 
        viewerDialogs.Remove(viewerDialogs.Find(x => x.id.Equals(id)));
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

    [System.Serializable]
    public struct ViewerDialogSub
    {
        public string name;
        public string content;
    }
}
