using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour 
{
    public static TaskManager _instance;

    private List<Task> taskList = new List<Task>();

    private Task currentTask;

    private PlayerAutoMove playerAutoMove;

    private PlayerAutoMove PlayerAutoMove
    {
        get
        {
            if(playerAutoMove==null)
            {
                playerAutoMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoMove>();
            }
            return playerAutoMove;
        }
    }

    public List<Task> TaskList
    {
        get { return taskList; }
    }

    void Awake()
    {
        _instance = this;
        InitTaskData();
    }

    /// <summary>
    /// 初始化TaskData
    /// </summary>
    void InitTaskData()
    {
        TaskData taskData = new TaskData();
        foreach(KeyValuePair<int, Task> kv in TaskData.TaskDataDict)
        {
            TaskList.Add(kv.Value);
        }
    }

    public void OnExcuteTask(Task task)
    {//执行某个任务
        this.currentTask = task;

        if(currentTask.TaskProgress==TaskProgress.NoStart)
        {//如果还没有开始则导航到NPC位置，接受任务
            PlayerAutoMove.SetDestination(NPCManager._instance.GetNpcById(task.IdNpc).transform.position);
        }
        else if (currentTask.TaskProgress == TaskProgress.Accept)
        {
            PlayerAutoMove.SetDestination(NPCManager._instance.GetTranscriptGo().transform.position);
        }
    }

    public void OnAcceptTask()
    {
        currentTask.TaskProgress = TaskProgress.Accept;
        //PlayerAutoMove.SetDestination(NPCManager._instance.GetTranscriptGo().transform.position);
        
    }

    public void OnArriveDestination()
    {//到达目的地
        if(currentTask.TaskProgress==TaskProgress.NoStart)
        {//到达NPC所在
            NPCDialogUI._instance.Show(currentTask.TalkNpc);
        }
        else
        {//到达副本

        }
    }
}
