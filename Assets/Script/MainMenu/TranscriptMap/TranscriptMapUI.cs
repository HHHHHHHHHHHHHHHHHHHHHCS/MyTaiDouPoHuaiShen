using UnityEngine;
using System.Collections;

public class TranscriptMapUI : MonoBehaviour 
{
    public static TranscriptMapUI _instance;

    private TweenPosition tween;
    private TranscriptMapDialogUI dialog;
    private UIButton backButton;

	void Awake()
    {
        _instance = this;
        tween = transform.GetComponent<TweenPosition>();
        dialog = transform.Find("Dialog").GetComponent<TranscriptMapDialogUI>();
        backButton = transform.Find("BackButton").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this, "Hide");
        backButton.onClick.Add(ed1);
        
    }

    public void Show()
    {
        tween.PlayForward();
    }

    public void Hide()
    {
        tween.PlayReverse();
    }

    public void OnBtnTranscriptClick(BtnTranscript btnTranscript)
    {
        PlayerInfo info = PlayerInfo._instance;
        if(info.Level>=btnTranscript.NeedLevel)
        {
            dialog.ShowDislog(btnTranscript);
        }
        else
        {
            dialog.ShowWarrn(btnTranscript);
        }
    }

    public void OnEnter()
    {
        //TODO:
    }
}
