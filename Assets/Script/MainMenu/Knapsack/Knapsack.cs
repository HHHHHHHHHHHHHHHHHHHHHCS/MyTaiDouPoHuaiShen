using UnityEngine;
using System.Collections;

public class Knapsack : MonoBehaviour 
{
    public static Knapsack _instance;

    private EquipPopup equipPopup;
    private InventoryPopup inventoryPopup;

    private UIButton saleButton;
    private UILabel priceLabel;

    private UIButton closeButton;

    private InventoryItemUI itUI;

    private TweenPosition tween;

    void Awake()
    {
        _instance = this;

        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
        inventoryPopup=transform.Find("InventoryPopup").GetComponent<InventoryPopup>();

        saleButton = transform.Find("Inventory/SaleButton").GetComponent<UIButton>();
        priceLabel = transform.Find("Inventory/PriceBg/Label").GetComponent<UILabel>();

        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();

        tween = transform.GetComponent<TweenPosition>();

        DisableButton();

        EventDelegate ed = new EventDelegate(this, "OnSale");
        saleButton.onClick.Add(ed);

        EventDelegate ed2 = new EventDelegate(this, "Hide");
        closeButton.onClick.Add(ed2);

        gameObject.SetActive(false);
    }

    public void OnInventoryClick(object[] objectArray)
    {
        InventoryItem it = (InventoryItem)objectArray[0];
        bool isLeft = (bool)objectArray[1];
        

        if(it.Inventory.InventoryType==InventoryType.Equip)
        {
            inventoryPopup.OnClose();
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if(isLeft)
            {
                itUI = (InventoryItemUI)objectArray[2];
            }
            else
            {
                roleEquip = (KnapsackRoleEquip)objectArray[2];
            }
            equipPopup.Show(it,itUI,roleEquip ,isLeft);
        }
        else if(it.Inventory.InventoryType==InventoryType.Drug)
        {
            equipPopup.OnClose();
            InventoryItemUI itUI = (InventoryItemUI)objectArray[2];
            inventoryPopup.Show(it,itUI);
        }
        else
        {
            inventoryPopup.OnClose();
            equipPopup.OnClose();
        }

        if((it.Inventory.InventoryType==InventoryType.Equip&&isLeft)||(it.Inventory.InventoryType!=InventoryType.Equip))
        {
            this.itUI = (InventoryItemUI)objectArray[2];
            EnableButton();
            priceLabel.text = this.itUI.It.Inventory.Price.ToString();
        }

    }


    public void DisableButton()
    {
        itUI = null;
        saleButton.SetState(UIButtonColor.State.Disabled, true);
        saleButton.GetComponent<Collider>().enabled = false;
        priceLabel.text = "";
    }

    public void EnableButton()
    {
        saleButton.SetState(UIButtonColor.State.Normal, true);
        saleButton.GetComponent<Collider>().enabled = true;
    
    }

    void OnSale()
    {
        int price = 0;
        if(priceLabel.text!="")
        {
            price = int.Parse(priceLabel.text);
        }

        PlayerInfo._instance.ChangeInventoryCount(itUI.It, 1);
        itUI.ChangeCount(0);
        if(itUI.It==null)
        {
            equipPopup.OnClose();
            inventoryPopup.OnClose();
            DisableButton();
        }
        else
        {
            inventoryPopup.UpdateCountText();
        }

        PlayerInfo._instance.AddCoin(price);
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
