using UnityEngine;
using System.Collections;

public class InventoryPopup : MonoBehaviour 
{

    private UILabel nameLabel;
    private UISprite inventorySprite;
    private UILabel desLabel;
    private UILabel btnLabel;
    private InventoryItem it;

    private UIButton closeButton;
    private UIButton useButton;
    private UIButton useBarchingButton;

    private InventoryItemUI itUI;

    void Awake()
    {
        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>(); ;
        inventorySprite = transform.Find("Bg/Sprite/Sprite").GetComponent<UISprite>();
        desLabel = transform.Find("Bg/Label").GetComponent<UILabel>();
        btnLabel = transform.Find("Bg/UseBatchingButton/Label").GetComponent<UILabel>();

        closeButton = transform.Find("Bg/CloseButton").GetComponent<UIButton>();
        useButton = transform.Find("Bg/UseButton").GetComponent<UIButton>();
        useBarchingButton = transform.Find("Bg/UseBatchingButton").GetComponent<UIButton>();


        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(this, "OnUse");
        useButton.onClick.Add(ed2);

        EventDelegate ed3 = new EventDelegate(this, "OnUseBarching");
        useBarchingButton.onClick.Add(ed3);

        gameObject.SetActive(false);
    }

    public void Show(InventoryItem it,InventoryItemUI itUI)
    {
        this.it = it;
        this.itUI = itUI;
        nameLabel.text = it.Inventory.Name;
        inventorySprite.spriteName = it.Inventory.Icon;
        desLabel.text = it.Inventory.Description;
        btnLabel.text = "批量使用(" + it.Count + ")";
        gameObject.SetActive(true);


    }

    public void UpdateCountText()
    {
        if (it == null || it.Count == 0)
        {
            OnClose();
        }
        else
        {
            btnLabel.text = "批量使用(" + it.Count + ")";
        }
    }

    public void OnClose()
    {
        it = null;
        itUI = null;
        gameObject.SetActive(false);

        transform.parent.GetComponent<Knapsack>().DisableButton();
    }

    public void OnUse()
    {
        itUI.ChangeCount(1);
        PlayerInfo._instance.InventoryUse(it,1);
        OnClose();
    }

    public void OnUseBarching()
    {
        itUI.ChangeCount(it.Count);
        PlayerInfo._instance.InventoryUse(it, it.Count);
        OnClose();
    }


}
