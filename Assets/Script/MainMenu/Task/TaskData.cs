using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskData  
{

    private static bool isFirst = true;
    private static Dictionary<int, Task> taskDataDict = new Dictionary<int, Task>();

    public static Dictionary<int, Task> TaskDataDict
    {
        get 
        {
            if(isFirst)
            {
                AwakeData();
            }
            return taskDataDict; 
        }
    }

    static bool AwakeData()
    {
        if (isFirst)
        {
            isFirst = false;

            #region StartTaskData
            Task newTask;

            newTask = new Task();
            newTask.Id = 1001;
            newTask.TaskType = TaskType.Main;
            newTask.Name = "试练之地";
            newTask.Icon = "男性手镯 (2)";
            newTask.Description = "通过试练之地完成新手挑战";
            newTask.Coin = 500;
            newTask.Diamond = 1000;
            newTask.TalkNpc = "你好，英雄，准备好开始了吗？";
            newTask.IdNpc = 1001;
            newTask.IdTranscript = 1001;
            taskDataDict.Add(newTask.Id, newTask);

            newTask = new Task();
            newTask.Id = 1002;
            newTask.TaskType = TaskType.Reward;
            newTask.Name = "赏金猎人";
            newTask.Icon = "金币";
            newTask.Description = "通过赏金之地抓捕罪犯阿凡达";
            newTask.Coin = 100;
            newTask.Diamond = 20;
            newTask.TalkNpc = "你成长的好快，已经准备着迎接新的挑战了吗？";
            newTask.IdNpc = 1002;
            newTask.IdTranscript = 1002;
            taskDataDict.Add(newTask.Id, newTask);

            newTask = new Task();
            newTask.Id = 1003;
            newTask.TaskType = TaskType.Daily;
            newTask.Name = "每日通关";
            newTask.Icon = "战斗";
            newTask.Description = "通关炼狱";
            newTask.Coin = 100;
            newTask.Diamond = 100;
            newTask.TalkNpc = "准备好了吗？";
            newTask.IdNpc = 1002;
            newTask.IdTranscript = 1003;
            taskDataDict.Add(newTask.Id, newTask);
            #endregion
            return true;
        }
        return false;
    }
}
