using UnityEngine;
using System.Collections;

public class PlayerBar : MonoBehaviour 
{
    private Transform playerBar;
    private UISprite headSprite;
    private UILabel nameLabel;
    private UILabel levelLabel;
    private UISlider energySlider;
    private UILabel energyLabel;
    private UISlider toughenSlider;
    private UILabel toughenLabel;
    private UIButton energyPlusButton;
    private UIButton toughenPlusButton;
    private UIButton headButton;
    void Awake()
    {
        playerBar = transform;

        headSprite = playerBar.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = playerBar.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = playerBar.Find("LevelLabel").GetComponent<UILabel>();
        energySlider = playerBar.Find("EnergyProgressBar").GetComponent<UISlider>();
        energyLabel = playerBar.Find("EnergyProgressBar/Label").GetComponent<UILabel>();
        toughenSlider = playerBar.Find("ToughenProgressBar").GetComponent<UISlider>();
        toughenLabel = playerBar.Find("ToughenProgressBar/Label").GetComponent<UILabel>();
        energyPlusButton = playerBar.Find("EnergyPlusButton").GetComponent<UIButton>();
        toughenPlusButton = playerBar.Find("ToughenPlusButton").GetComponent<UIButton>();
        headButton = playerBar.Find("HeadButton").GetComponent<UIButton>();
        
        PlayerInfo._instance.OnPlayerInfoChangeEvent += this.OnPlayerInfoChange;

        EventDelegate ed = new EventDelegate(this, "OnHeadButtonClick");
        headButton.onClick.Add(ed);

    }


    void OnDestory()
    {//注销更新信息委托事件
        PlayerInfo._instance.OnPlayerInfoChangeEvent += this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(PlayerInfoType playerInfoType)
    {//当我们的主角信息发生改变的时候，会触发这个方法
        if(playerInfoType==PlayerInfoType.Name||playerInfoType==PlayerInfoType.HeadPortrait||playerInfoType==PlayerInfoType.Level
            ||playerInfoType==PlayerInfoType.Energy||playerInfoType==PlayerInfoType.Toughen
            || playerInfoType == PlayerInfoType.All)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {//更新显示
        headSprite.spriteName = PlayerInfo._instance.HeadPortrait;
        levelLabel.text = PlayerInfo._instance.Level.ToString();
        nameLabel.text = PlayerInfo._instance.Name.ToString();
        energySlider.value = PlayerInfo._instance.Energy / 100.0f;
        energyLabel.text = PlayerInfo._instance.Energy + "/100";
        toughenSlider.value = PlayerInfo._instance.Toughen / 50.0f;
        toughenLabel.text = PlayerInfo._instance.Toughen + "/50";
    }

    void OnHeadButtonClick()
    {
        PlayerStatus._instance.ShowAndHidePanel();
    }
}
