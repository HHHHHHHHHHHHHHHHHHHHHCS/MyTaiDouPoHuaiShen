using UnityEngine;
using System.Collections;

public class TaskItemUI : MonoBehaviour 
{
    private Task task;

    private UISprite taskTypeSprite;
    private UISprite iconSprite;
    private UILabel nameLabel;
    private UILabel desLabel;
    private UISprite reward1Sprite;
    private UILabel reward1Label;
    private UISprite reward2Sprite;
    private UILabel reward2Label;
    private UIButton rewardButton;
    private UIButton combatButton;
    private UILabel combatButtonLabel;


    void Awake()
    {
        taskTypeSprite = transform.Find("TaskTypeSprite").GetComponent<UISprite>();
        iconSprite = transform.Find("IconBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        reward1Sprite = transform.Find("Reward1Sprite").GetComponent<UISprite>();
        reward1Label = transform.Find("Reward1Sprite/Label").GetComponent<UILabel>();
        reward2Sprite = transform.Find("Reward2Sprite").GetComponent<UISprite>();
        reward2Label = transform.Find("Reward2Sprite/Label").GetComponent<UILabel>();
        rewardButton = transform.Find("RewardButton").GetComponent<UIButton>();
        combatButton = transform.Find("CombatButton").GetComponent<UIButton>();
        combatButtonLabel = transform.Find("CombatButton/Label").GetComponent<UILabel>();


        EventDelegate ed1 = new EventDelegate(this, "OnCombat");
        combatButton.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(this, "OnReward");
        rewardButton.onClick.Add(ed2);
    }
 
    public void SetTask(Task task)
    {
        this.task = task;
        task.OnTaskChangeEvent += this.OnTaskChange;
        UpdateShow();
    }

    void UpdateShow()
    {
        taskTypeSprite.spriteName = Task.GetStringByIcon(task.TaskType);
        iconSprite.spriteName = task.Icon;
        nameLabel.text = task.Name;
        desLabel.text = task.Description;
        SetRewardPosByTask(task);
        reward1Label.text = "x" + task.Coin.ToString();
        reward2Label.text = "x" + task.Diamond.ToString();
        SetRewardProgress(task);
    }

    void SetRewardPosByTask(Task task)
    {
        int _rewardCount = GetRewardCountByTask(task);
        switch (_rewardCount)
        {
            case -1:
                {
                    reward1Sprite.gameObject.SetActive(false);
                    reward2Sprite.gameObject.SetActive(false);
                    break;
                }
            case 0:
                {
                    reward1Sprite.gameObject.SetActive(true);
                    reward2Sprite.gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    reward1Sprite.gameObject.SetActive(false);
                    reward2Sprite.transform.localPosition = reward1Sprite.transform.localPosition;
                    reward2Sprite.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    reward1Sprite.gameObject.SetActive(true);
                    reward2Sprite.gameObject.SetActive(true);
                    break;
                }
        }
    }

    void SetRewardProgress(Task task)
    {
        switch(task.TaskProgress)
        {
            case TaskProgress.NoStart:
                {
                    combatButton.gameObject.SetActive(true);
                    rewardButton.gameObject.SetActive(false);
                    combatButtonLabel.text = "下一步";
                    break;
                }
            case TaskProgress.Accept:
                {
                    combatButton.gameObject.SetActive(true);
                    rewardButton.gameObject.SetActive(false);
                    combatButtonLabel.text = "战斗";
                    break;
                }
            case TaskProgress.Complete:
                {
                    combatButton.gameObject.SetActive(false);
                    rewardButton.gameObject.SetActive(true);   
                    break;
                }
        }
    }

    int GetRewardCountByTask(Task task)
    {//-1：两个奖励都没有，0：一奖励有二奖励无，1：一奖励无二奖励有，2：一二奖励都没有
        int result = -1;
        if(task.Coin!=0&&task.Diamond==0)
        {
            result = 0;
        }
        if (task.Coin == 0 && task.Diamond != 0)
        {
            result = 1;
        }
        if (task.Coin != 0 && task.Diamond != 0)
        {
            result = 2;
        }
        return result;
    }


    void OnCombat()
    {
        TaskUI._instance.Hide();
        TaskManager._instance.OnExcuteTask(task);        
    }

    void OnReward()
    {

    }

    void OnTaskChange()
    {
        UpdateShow();
    }
}

