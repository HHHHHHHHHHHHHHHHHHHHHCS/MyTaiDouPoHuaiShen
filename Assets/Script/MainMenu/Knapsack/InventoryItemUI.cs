using UnityEngine;
using System.Collections;

public class InventoryItemUI : MonoBehaviour 
{

    private UISprite sprite;
    private UILabel label;
    private InventoryItem it;

    public InventoryItem It
    {
        get { return it; }
        set { it = value; }
    }

    private string nullName = InventoryData.DefaultSpriteName;

    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = transform.Find("Sprite").GetComponent<UISprite>();
            }
            return sprite;
        }
    }
    private UILabel Label
    {
        get
        {
            if (label == null)
            {
                label = transform.Find("Label").GetComponent<UILabel>();
            }
            return label;
        }
    }
    public void SetInventoryItem(InventoryItem it)
    {
        if(it!=null)
        {
            this.it = it;
            Sprite.spriteName = it.Inventory.Icon;
            Label.text = it.NeedShow ? it.Count.ToString() : "";//是否显示数量
        }

    }

    public void Clear()
    {
        this.it = null;
        Label.text = "";
        Sprite.spriteName = nullName;
    }


    public void OnClick()
    {
        if (this.it != null)
        {
            object[] objectArray = new object[3];
            objectArray[0] = it;
            objectArray[1] = true;
            objectArray[2] = this;
            transform.parent.parent.parent.parent.GetComponent<Knapsack>().OnInventoryClick(objectArray);
        }
    }

    public void ChangeCount(int count)
    {
        if (it.Count - count == 0)
        {
            Clear();
        }
        else if (it.Count - count >= 1)
        {
            label.text = (it.Count - count).ToString();
        }
    }
}
