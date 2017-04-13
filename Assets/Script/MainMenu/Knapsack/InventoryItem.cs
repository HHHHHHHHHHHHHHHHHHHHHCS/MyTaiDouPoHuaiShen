using UnityEngine;
using System.Collections;

public class InventoryItem 
{

    #region property
    private Inventory inventory;
    private int level;
    private int count;
    private bool needShow;//是否显示数量
    private bool isDressed;
    #endregion

    #region GetAndSetMethod
    public Inventory Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public bool NeedShow
    {
        get { return needShow; }
        set { needShow = value; }
    }

    public bool IsDressed
    {
        get { return isDressed; }
        set { isDressed = value; }
    }
    #endregion



}
