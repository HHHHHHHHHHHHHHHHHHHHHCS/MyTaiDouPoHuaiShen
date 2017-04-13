using UnityEngine;
using System.Collections;

public enum TaskType
{
    Main,//主要任务
    Reward,//赏金任务
    Daily//日常任务
}

public enum TaskProgress
{
    NoStart,//没有开始
    Accept,//接受
    Doing,//进行中
    Complete,//完成
    Reward//领取奖励
}

public class Task
{
    public delegate void OnTaskChange();
    public event OnTaskChange OnTaskChangeEvent;

    

    #region property
    //a)Id
    //b)任务类型（Main,Reward，Daily）
    //c)名称
    //d)图标
    //e)任务描述
    //f)获得的金币奖励
    //g)获得的钻石奖励
    //h)跟npc交谈的话语
    //i)Npc的id
    //j)副本id
    //k)任务的状态
    //i.未开始
    //ii.接受任务
    //iii.任务完成
    //iv.获取奖励（结束）

    private int id;  
    private TaskType taskType;
    private string name;
    private string icon;
    private string description;
    private int coin;
    private int diamond;    
    private string talkNpc;    
    private int idNpc;    
    private int idTranscript;    
    private TaskProgress taskProgress = TaskProgress.NoStart;    
    #endregion

    #region GetAndSetMethod
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public TaskType TaskType
    {
        get { return taskType; }
        set { taskType = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }
    public int Diamond
    {
        get { return diamond; }
        set { diamond = value; }
    }
    public string TalkNpc
    {
        get { return talkNpc; }
        set { talkNpc = value; }
    }
    public int IdNpc
    {
        get { return idNpc; }
        set { idNpc = value; }
    }
    public int IdTranscript
    {
        get { return idTranscript; }
        set { idTranscript = value; }
    }
    public TaskProgress TaskProgress
    {
        get { return taskProgress; }
        set 
        { 
            if(taskProgress!=value)
            {
                taskProgress = value;
                OnTaskChangeEvent();
            }
            
        }
    }
    #endregion

    public static string GetStringByIcon(TaskType taskType)
    {
        string result = "";
        switch (taskType)
        {
            case TaskType.Main:
                {
                    result = "pic_主线";
                    break;
                }
            case TaskType.Reward:
                {
                    result = "pic_奖赏";
                    break;
                }
            case TaskType.Daily:
                {
                    result = "pic_日常";
                    break;
                }
        }
        return result;
    }
    

}
