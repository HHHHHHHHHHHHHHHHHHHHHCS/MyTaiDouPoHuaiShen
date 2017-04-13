using UnityEngine;
using System.Collections;

public class NPCDialogUI : MonoBehaviour 
{
    public static NPCDialogUI _instance;

    private TweenPosition tween;
    private UILabel npcTalkLabel;
    private UIButton acceptButton;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        tween = this.GetComponent<TweenPosition>();
        npcTalkLabel = transform.Find("Label").GetComponent<UILabel>();
        acceptButton = transform.Find("AcceptButton").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this, "OnAccept");
        acceptButton.onClick.Add(ed1); 
    }

    public void Show(string npcTalk)
    {
        npcTalkLabel.text = npcTalk;
        tween.PlayForward();
    }

    public void Hide()
    {
        tween.PlayReverse();
    }

    public void OnAccept()
    {
        //通知任务已经接受
        TaskManager._instance.OnAcceptTask();
        Hide();
    }


}
