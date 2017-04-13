using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour 
{
    public static SkillUI _instance;

    private int startWidth;
    private int addWidth = 25;
    private UILabel skillNameLabel;
    private UILabel skillDesLabel;
    private UIButton closeButton;
    private UIButton upgradeButton;
    private UILabel upgradeButtonLabel;
    private UISprite skill1Sprite;
    private UISprite skill2Sprite;
    private UISprite skill3Sprite;
    private TweenPosition tween;

    private Skill skill;

    void Awake()
    {
        _instance = this;

        skillNameLabel = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDesLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        upgradeButtonLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();
        skill1Sprite = transform.Find("Bg/Skill1Sprite").GetComponent<UISprite>();
        skill2Sprite = transform.Find("Bg/Skill2Sprite").GetComponent<UISprite>();
        skill3Sprite = transform.Find("Bg/Skill3Sprite").GetComponent<UISprite>();
        tween = transform.GetComponent<TweenPosition>();

        startWidth = skill1Sprite.height;


        EventDelegate ed = new EventDelegate(this,"OnUpgrade");
        upgradeButton.onClick.Add(ed);

        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);

        Clear();

    }

    void DisableUpgradeButton(string str=null)
    {
        upgradeButton.SetState(UIButton.State.Disabled,true);
        upgradeButton.GetComponent<Collider>().enabled = false;
        if(str!=null)
        {
            upgradeButtonLabel.text = str;
        }
    }

    void EnableUpgradeButton(string str = null)
    {
        upgradeButton.SetState(UIButton.State.Normal, true);
        upgradeButton.GetComponent<Collider>().enabled = true;
        if (str != null)
        {
            upgradeButtonLabel.text = str;
        }
    }

    void Clear()
    {
        skill = null;
        ClearScale();
        skillNameLabel.text = "";
        skillDesLabel.text = "";
        DisableUpgradeButton("选择技能");
    }

    void ClearScale()
    {
        skill1Sprite.width = startWidth;
        skill2Sprite.width = startWidth;
        skill3Sprite.width = startWidth;  
    }

    void ChangeScale()
    {
        UISprite us=null;
        int t = SkillManager._instance.GetNumberByPosition(skill.SkillPosType);
        switch(t)
        {
            case 1:
            {
                us = skill1Sprite;
                break;
            }
            case 2:
            {
                us = skill2Sprite;
                break;
            }
            case 3:
            {
                us = skill3Sprite;
                break;
            }
        }
        if (us != null)
        {
            us.width += addWidth;
        }
    }

    public void OnSkillCick(Skill skill)
    {
        
        this.skill = skill;


        ClearScale();
        ChangeScale();

        UpdateShow();
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;

        if ((500 * (skill.Level + 1)) <= info.Coin && skill.Level <= info.Level)
        {
            EnableUpgradeButton("升级");
        }
        else if ((500 * (skill.Level + 1)) > info.Coin)
        {
            DisableUpgradeButton("金币不足");
        }
        else
        {
            DisableUpgradeButton("等级不足");
        }
        skillNameLabel.text = skill.SkillName + " Lv." + skill.Level;
        skillDesLabel.text = "当前技能的攻击力为：" + (skill.Damage * skill.Level).ToString();
        skillDesLabel.text += '\n' + "下一级技能的攻击力为：" + (skill.Damage * (skill.Level + 1)).ToString();
        skillDesLabel.text += '\n' + "升级所需要的金币数量：" + (500 * (skill.Level + 1)).ToString();
        
    }

    void OnUpgrade()
    {
        PlayerInfo info = PlayerInfo._instance;
        if(skill.Level<=info.Level)
        {
            int coinNeed = 500 * (skill.Level + 1);
            bool isSuccess = info.GetCoin(coinNeed);
            if (isSuccess)
            {
                skill.Upgrade();
                UpdateShow();
            }
            else
            {
                DisableUpgradeButton("金币不足");
            }
        }
        else
        {
            DisableUpgradeButton("等级不足");
        }
    }

    public void Show()
    {
        tween.PlayForward();
    }

    public void Hide()
    {
        tween.PlayReverse();
    }

    void OnClose()
    {
        Clear();
        Hide();
    }
}
