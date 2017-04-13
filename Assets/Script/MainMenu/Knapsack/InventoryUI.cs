using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour 
{
    public static InventoryUI _instance;
    private List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();//所有背包中的物体

    private UIButton clearUpButton;
    private UILabel inventoryLabel;
    void Awake()
    {
        _instance = this;
        Init();
        InventoryManager._instance.onInventoryChangeEvent += this.OnInventoryChange;
        clearUpButton = transform.Find("ClearUpButton").GetComponent<UIButton>();
        inventoryLabel = transform.Find("InventoryNumLabel").GetComponent<UILabel>();

        EventDelegate ed = new EventDelegate(this, "OnClearUp");
        clearUpButton.onClick.Add(ed);
    }

    void OnDestory()
    {
        InventoryManager._instance.onInventoryChangeEvent -= this.OnInventoryChange;
    }

    void Init()
    {
        Transform father = transform.Find("InventoryGrids/Scroll View").GetComponent<Transform>();
        foreach (Transform child in father)
        {
            InventoryItemUI childUI = child.GetComponent<InventoryItemUI>();
            itemUIList.Add(childUI);
        }
    }

    void OnInventoryChange()
    {
        UpdateShow();
    }



    void UpdateShow()
    {
        int temp = 0;
        int maxCount = InventoryStart.getMaxNum(); ;
        for(int i=0;i<InventoryManager._instance.InventoryItemList.Count;i++)
        {
            InventoryItem it = InventoryManager._instance.InventoryItemList[i];
            if(it!=null&&!it.IsDressed)
            {
                itemUIList[temp].SetInventoryItem(it);
                temp++;
            }    
        }

        for (int i = temp; i < itemUIList.Count; i++)
        {
            itemUIList[i].Clear();
        }

        inventoryLabel.text = temp + "/" + maxCount;
    }

    public void AddInventoryItem(InventoryItem it)
    {
        foreach(InventoryItemUI itUI in itemUIList)
        {
            if(itUI.It==null)
            {
                itUI.SetInventoryItem(it);
                break;
            }
        }

        int temp = 0;
        int maxCount = InventoryStart.getMaxNum();
        for (int i = 0; i < InventoryManager._instance.InventoryItemList.Count; i++)
        {
            InventoryItem _it = InventoryManager._instance.InventoryItemList[i];
            if (_it != null && !_it.IsDressed)
            {
                temp++;
            }
        }

        inventoryLabel.text = temp + "/" + maxCount;
    }

    public void UpdateCount()
    {
        int temp = 0;
        int maxCount = InventoryStart.getMaxNum();
        for (int i = 0; i < InventoryManager._instance.InventoryItemList.Count; i++)
        {
            InventoryItem _it = InventoryManager._instance.InventoryItemList[i];
            if (_it!=null&&!_it.IsDressed)
            {
                temp++;
            }
        }

        inventoryLabel.text = temp + "/" + maxCount;
    }

    void OnClearUp()
    {//整理
        UpdateShow();
    }
}
