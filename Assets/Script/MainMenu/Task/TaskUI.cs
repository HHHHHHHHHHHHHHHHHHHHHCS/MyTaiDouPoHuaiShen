using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskUI : MonoBehaviour 
{
    public static TaskUI _instance;

    private UIGrid taskListGrid;
    private UIButton closeButton;
    public GameObject taskItemPrefab;
    private TweenPosition tween;

    void Awake()
    {
        _instance = this;

        taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        tween = transform.GetComponent<TweenPosition>();

        EventDelegate ed1 = new EventDelegate(this, "Hide");
        closeButton.onClick.Add(ed1);
    }

    void Start()
    {
        InitTaskList();
        Hide();
    }

    /// <summary>
    /// 初始化任务列表信息
    /// </summary>
	void InitTaskList()
    {
        List<Task> taskList = TaskManager._instance.TaskList;

        foreach (Task task in taskList)
        {
            GameObject go = NGUITools.AddChild(taskListGrid.gameObject, taskItemPrefab);
            taskListGrid.AddChild(go.transform);
            TaskItemUI ti = go.GetComponent<TaskItemUI>();
            ti.SetTask(task);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        tween.PlayForward();
        
    }

    public void Hide()
    {
        tween.PlayReverse();
        //gameObject.SetActive(false);
    }

}
