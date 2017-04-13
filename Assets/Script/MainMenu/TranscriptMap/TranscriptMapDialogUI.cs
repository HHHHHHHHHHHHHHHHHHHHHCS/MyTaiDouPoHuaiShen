using UnityEngine;
using System.Collections;

public class TranscriptMapDialogUI : MonoBehaviour 
{
    private UILabel nameLabel;
    private UILabel desLabel;
    private UILabel energyTagLabel;
    private UILabel energyLabel;
    private UIButton closeButton;
    private UIButton enterButton;
    private UILabel btnLabel;

    private TweenScale tween;

    void Start()
    {
        nameLabel = transform.Find("TranscriptnName").GetComponent<UILabel>();
        desLabel = transform.Find("TranscriptContext/DesLabel").GetComponent<UILabel>();
        energyTagLabel = transform.Find("TranscriptContext/Label").GetComponent<UILabel>();
        energyLabel = transform.Find("TranscriptContext/EnergyLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        enterButton = transform.Find("EnterButton").GetComponent<UIButton>();
        btnLabel = transform.Find("EnterButton/Label").GetComponent<UILabel>();

        tween = transform.GetComponent<TweenScale>();

        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(this, "OnEnter");
        enterButton.onClick.Add(ed2);
    }

    public void ShowDislog(BtnTranscript btnTranscript)
    {
        energyLabel.enabled = true;
        energyTagLabel.enabled = true;
        enterButton.enabled = true;

        nameLabel.text = btnTranscript.TranscriptName;
        desLabel.text = btnTranscript.Des;
        energyLabel.text = "3".ToString();

        tween.PlayForward();
    }

    public void ShowWarrn(BtnTranscript btnTranscript)
    {
        energyLabel.enabled = false;
        energyTagLabel.enabled = false;
        enterButton.enabled = false;


        desLabel.text = "当前等级无法进入该地下城";
        desLabel.text += '\n' + "需要等级：" + btnTranscript.NeedLevel;

        tween.PlayForward();
    }

    void OnClose()
    {
        tween.PlayReverse();
    }

    void OnEnter()
    {
        transform.parent.GetComponent<TranscriptMapUI>().OnEnter();
    }
}
