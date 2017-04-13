using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour 
{
    private Transform topBar;
    private UILabel coinLabel;
    private UILabel diamondLabel;
    private UIButton coinPlusButton;
    private UIButton diamondPlusButton;

    void Awake()
    {
        topBar = transform;

        coinLabel = topBar.Find("CoinBg/Label").GetComponent<UILabel>();
        diamondLabel = topBar.Find("DiamondBg/Label").GetComponent<UILabel>();
        coinPlusButton = topBar.Find("CoinBg/PlusButton").GetComponent<UIButton>();
        diamondPlusButton = topBar.Find("DiamondBg/PlusButton").GetComponent<UIButton>();
        PlayerInfo._instance.OnPlayerInfoChangeEvent += this.OnPlayerInfoChange;
    }

    void OnDestory()
    {//注销更新信息委托事件
        PlayerInfo._instance.OnPlayerInfoChangeEvent -= this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(PlayerInfoType playerInfoType)
    {//当我们的主角信息发生改变的时候，会触发这个方法
        if (playerInfoType == PlayerInfoType.Coin || playerInfoType == PlayerInfoType.Diamond 
            || playerInfoType == PlayerInfoType.All)
        {
            UpdateShow();
        }
    }

    void UpdateShow()
    {//更新显示
        coinLabel.text = PlayerInfo._instance.Coin.ToString();
        diamondLabel.text = PlayerInfo._instance.Diamond.ToString();
    }
}
