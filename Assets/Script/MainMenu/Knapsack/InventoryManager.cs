using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour 
{
    public static InventoryManager _instance;

    private List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    public List<InventoryItem> InventoryItemList
    {
        get { return inventoryItemList; }
    }

    public delegate void OnInventoryChange();
    public event OnInventoryChange onInventoryChangeEvent;
    void Awake()
    {
        _instance = this;
        InitInventoryData();
    }

    void Start()
    {
        ReadInventoryItemInfo();
    }

    void InitInventoryData()
    {
        InventoryData inventoryData = new InventoryData();
    }


    void ReadInventoryItemInfo()
    {//获取主角的物品
        //TODO 连接服务器 获取当前角色所拥有的物品信息

        //随机生成主角所拥有的装备
        for(int i=0;i<10;i++)
        {
            int id = Random.Range(10001, 10009);
            InventoryItem newItem = AddInventoryItem(id);
            //newItem.Level = Random.Range(1, 10);  
        }
        //随机生成主角所拥有的物品
        for (int i = 0; i < 12; i++)
        {
            int id = Random.Range(11001, 11003);
            InventoryItem newItem = AddInventoryItem(id);
        }
        onInventoryChangeEvent();
    }


    public InventoryItem AddInventoryItem(int id)
    {
        if(inventoryItemList.Count>=InventoryStart.getMaxNum())
        {
            return null;
        }

        Inventory newInventory = null;
        InventoryData.InventoryDataDict.TryGetValue(id, out newInventory);
        if(newInventory.InventoryType==InventoryType.Equip)
        {
            InventoryItem it = new InventoryItem();
            it.Inventory = newInventory;
            it.Count = 1;
            it.NeedShow = false;
            inventoryItemList.Add(it);
            return it;
        }
        else
        {
            int index = GetInventoryItemIndex(id);

            if (index != -1)
            {
                inventoryItemList[index].Count++;
                return inventoryItemList[index];
            }
            else
            {
                InventoryItem it = new InventoryItem();
                it.Inventory = newInventory;
                it.Count = 1;
                it.NeedShow = true;
                inventoryItemList.Add(it);
                return it;
            }
        }
    }

    public int GetInventoryItemIndex(int id)
    {
        for(int i=0;i<inventoryItemList.Count;i++)
        {
            if(inventoryItemList[i].Inventory.Id==id)
            {
                return i;
            }
        }
        return -1;
    }


}
