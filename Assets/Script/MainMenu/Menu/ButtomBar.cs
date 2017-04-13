using UnityEngine;
using System.Collections;

public class ButtomBar : MonoBehaviour 
{
    private UIButton combatButton;
    private UIButton knapsackButton;
    private UIButton taskButton;
    private UIButton skillButton;
    private UIButton shopButton;
    private UIButton systemButton;

    void Awake()
    {
        combatButton = transform.Find("Combat").GetComponent<UIButton>();
        knapsackButton = transform.Find("Knapsack").GetComponent<UIButton>();
        taskButton = transform.Find("Task").GetComponent<UIButton>();
        skillButton = transform.Find("Skill").GetComponent<UIButton>();
        shopButton = transform.Find("Shop").GetComponent<UIButton>();
        systemButton = transform.Find("System").GetComponent<UIButton>();

        InitClickEvent();

    }

    void InitClickEvent()
    {
        EventDelegate ed1 = new EventDelegate(this, "OnComBat");
        combatButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "OnKnapsack");
        knapsackButton.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "OnTask");
        taskButton.onClick.Add(ed3);
        EventDelegate ed4 = new EventDelegate(this, "OnSkill");
        skillButton.onClick.Add(ed4);
        EventDelegate ed5 = new EventDelegate(this, "OnShop");
        shopButton.onClick.Add(ed5);
        EventDelegate ed6 = new EventDelegate(this, "OnSystem");
        systemButton.onClick.Add(ed6);
    }

    void OnComBat()
    {

    }

    void OnKnapsack()
    {
        Knapsack._instance.Show();
    }

    void OnTask()
    {
        TaskUI._instance.Show();
    }

    void OnSkill()
    {
        SkillUI._instance.Show();
    }

    void OnShop()
    {

    }

    void OnSystem()
    {

    }
}
