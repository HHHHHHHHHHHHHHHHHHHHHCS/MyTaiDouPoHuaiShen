using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour 
{
    public static PlayerStatus _instance;

    private Transform playerStatus;
    private UISprite headSprite;
    private UILabel levelLabel;
    private UILabel nameLabel;
    private UILabel powerLabel;
    private UISlider expSlider;
    private UILabel expLabel;
    private UILabel diamondLabel;
    private UILabel coinLabel;
    private UILabel energyLabel;
    private UILabel energyRestorePartLabel;
    private UILabel energyRestoreAllLabel;
    private UILabel toughenLabel;
    private UILabel toughenRestorePartLabel;
    private UILabel toughenRestoreAllLabel;

    /*-----界面开关-----*/
    private TweenPosition tween;
    private UIButton closeButton;
    private bool isShow;


    /*-----改名-----*/
    private UIButton changeNameButton;
    private GameObject changeNameGo;
    private UIInput nameInput;
    private UIButton sureButton;
    private UIButton cancenButton;

    void Awake()
    {
        _instance = this;

        playerStatus = transform;
        headSprite = playerStatus.Find("HeadSprite").GetComponent<UISprite>();
        levelLabel = playerStatus.Find("LevelLabel").GetComponent<UILabel>();
        nameLabel = playerStatus.Find("NameLabel").GetComponent<UILabel>();
        powerLabel = playerStatus.Find("PowerLabel").GetComponent<UILabel>();
        expSlider = playerStatus.Find("ExpProgreeBar").GetComponentInChildren<UISlider>();
        expLabel = playerStatus.Find("ExpProgreeBar/Label").GetComponent<UILabel>();
        diamondLabel = playerStatus.Find("DiamondLabel/NumLabel").GetComponent<UILabel>();
        coinLabel = playerStatus.Find("CoinLabel/NumLabel").GetComponent<UILabel>();
        energyLabel = playerStatus.Find("EnergyLabel/NumLabel").GetComponent<UILabel>();
        energyRestorePartLabel = playerStatus.Find("EnergyLabel/RestorePartTime").GetComponent<UILabel>();
        energyRestoreAllLabel = playerStatus.Find("EnergyLabel/RestoreAllTime").GetComponent<UILabel>();
        toughenLabel = playerStatus.Find("ToughenEnergyLabel/NumLabel").GetComponent<UILabel>();
        toughenRestorePartLabel = playerStatus.Find("ToughenEnergyLabel/RestorePartTime").GetComponent<UILabel>();
        toughenRestoreAllLabel = playerStatus.Find("ToughenEnergyLabel/RestoreAllTime").GetComponent<UILabel>();

        tween = GetComponent<TweenPosition>();
        closeButton = playerStatus.Find("CloseButton").transform.GetComponent<UIButton>();
        isShow = false;

        changeNameButton = playerStatus.Find("ChangeNameButton").GetComponent<UIButton>();
        changeNameGo = playerStatus.Find("ChangeNameBg").gameObject;
        nameInput = changeNameGo.transform.Find("NameInput").GetComponent<UIInput>();
        sureButton = changeNameGo.transform.Find("SureButton").GetComponent<UIButton>();
        cancenButton = changeNameGo.transform.Find("CancelButton").GetComponent<UIButton>();
        EventDelegate changeNameEvent = new EventDelegate(this, "OnButtonChangeNameClick");
        changeNameButton.onClick.Add(changeNameEvent);
        EventDelegate sureChangNameEvent = new EventDelegate(this, "OnButtonSureChangeNameClick");
        sureButton.onClick.Add(sureChangNameEvent);
        EventDelegate cancelChangeNameEvent = new EventDelegate(this, "OnButtonCancelChangeNameClick");
        cancenButton.onClick.Add(cancelChangeNameEvent);
        changeNameGo.SetActive(false);

        EventDelegate showAndHidePanelEvent = new EventDelegate(this, "ShowAndHidePanel");
        closeButton.onClick.Add(showAndHidePanelEvent);

        PlayerInfo._instance.OnPlayerInfoChangeEvent += this.OnPlayerInfoChange;
    }

    void Update()
    {
        UpdateShow();
    }

    void OnDestory()
    {//注销更新信息委托事件
        PlayerInfo._instance.OnPlayerInfoChangeEvent -= this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(PlayerInfoType playerInfoType)
    {//当我们的主角信息发生改变的时候，会触发这个方法
        UpdateShow();
    }

    void UpdateShow()
    {//更新显示
        headSprite.spriteName = PlayerInfo._instance.HeadPortrait;
        levelLabel.text = PlayerInfo._instance.Level.ToString();
        nameLabel.text = PlayerInfo._instance.Name.ToString();
        powerLabel.text = PlayerInfo._instance.Power.ToString();
        expSlider.value = PlayerInfo._instance.Exp/PlayerInfo._instance.MaxExp;
        expLabel.text = PlayerInfo._instance.Exp.ToString() + "/" + PlayerInfo._instance.MaxExp.ToString();
        diamondLabel.text = PlayerInfo._instance.Diamond.ToString();
        coinLabel.text = PlayerInfo._instance.Coin.ToString();
        UpdateEnergyAndToughenShow();
    }

    void UpdateEnergyAndToughenShow()
    {//更新体力和历练
        energyLabel.text = PlayerInfo._instance.Energy.ToString() + "/100";
        toughenLabel.text = PlayerInfo._instance.Toughen.ToString() + "/50";
        if(PlayerInfo._instance.Energy>=100)
        {
            energyRestorePartLabel.text = GetTimeFormat(0);
            energyRestoreAllLabel.text = GetTimeFormat(0);
        }
        else if(PlayerInfo._instance.Energy>=0)
        {
            energyRestorePartLabel.text = GetTimeFormat(60-PlayerInfo._instance.EnergyTimer);
            energyRestoreAllLabel.text = GetTimeFormat(PlayerInfo._instance.EnergyAllTime);
        }
        if (PlayerInfo._instance.Toughen >= 50)
        {
            toughenRestorePartLabel.text = GetTimeFormat(0);
            toughenRestoreAllLabel.text = GetTimeFormat(0);
        }
        else if (PlayerInfo._instance.Toughen >= 0)
        {
            toughenRestorePartLabel.text = GetTimeFormat(60-PlayerInfo._instance.ToughenTimer);
            toughenRestoreAllLabel.text = GetTimeFormat(PlayerInfo._instance.ToughenAllTime);
        }
    }

    string GetTimeFormat(float _time)
    {//根据输入的float得到时间的格式
        string result;
        int time = (int)_time;
        int h = time / 3600;
        int m = (time - 3600 * h) / 60;
        int s = time - 3600 * h - 60 * m;
        
        result = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
        return result;
    }  

    public void ShowAndHidePanel()
    {
        if(isShow)
        {
            tween.PlayReverse();
        }
        else
        {
            tween.PlayForward();
        }
        isShow = !isShow;
    }

    void OnButtonChangeNameClick()
    {
        changeNameGo.SetActive(true);
    }


    void OnButtonSureChangeNameClick()
    {
        //首先联网校验名字是否重复，是否符合规范
        //TODO
        //不存在重复改变名字，隐藏改名面板
        PlayerInfo._instance.ChangeNewName(nameInput.value);
        changeNameGo.SetActive(false);
        //否则提示更改名字错误信息
    }


    void OnButtonCancelChangeNameClick()
    {
        changeNameGo.SetActive(false);
    }

}
