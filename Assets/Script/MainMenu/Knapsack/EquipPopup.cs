using UnityEngine;
using System.Collections;

public class EquipPopup : MonoBehaviour 
{
    private PowerShow powerShow;

    private const string zhuangbei = "装备";
    private const string xiexia = "卸下";

    private InventoryItem it;
    private InventoryItemUI itUI;
    private KnapsackRoleEquip roleEquip;

    private UISprite equipSprite;
    private UILabel nameLabel;
    private UILabel qualityLabel;
    private UILabel levelLabel;
    private UILabel propertyLabel;
    private UILabel powerLabel;
    private UILabel descriptionLabel;
    private UILabel upgradeLevelLabel;
    private UILabel btnLabel;
    private UIButton equipButton;
    private UIButton upgradeButton;
    private UIButton closeButton;

    private bool isLeft = true;
    void Awake()
    {
        powerShow = transform.parent.Find("PowerShow").GetComponent<PowerShow>();

        equipSprite = transform.Find("Bg/EquipBg/Sprite").GetComponent<UISprite>();
        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        qualityLabel = transform.Find("Bg/QualityLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("Bg/LevelLabel/Label").GetComponent<UILabel>();
        propertyLabel = transform.Find("Bg/PropertyLabel").GetComponent<UILabel>();
        powerLabel = transform.Find("Bg/PowerLabel/PowerNumerLabel").GetComponent<UILabel>();
        descriptionLabel = transform.Find("Bg/DescriptionLabel").GetComponent<UILabel>();
        upgradeLevelLabel = transform.Find("Bg/UpgradeLevel/Label").GetComponent<UILabel>();
        btnLabel = transform.Find("Bg/EquipButton/Label").GetComponent<UILabel>();
        equipButton = transform.Find("Bg/EquipButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("Bg/UpgradeButton").GetComponent<UIButton>();
        closeButton = transform.Find("Bg/CloseButton").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed1);

        EventDelegate ed2 = new EventDelegate(this, "OnEquip");
        equipButton.onClick.Add(ed2);

        EventDelegate ed3 = new EventDelegate(this, "OnUpgrade");
        upgradeButton.onClick.Add(ed3);

        gameObject.SetActive(false);
    }

    public void Show(InventoryItem it,InventoryItemUI itUI,KnapsackRoleEquip roleEquip,bool isLeft=true)
    {
        this.it = it;
        this.itUI = itUI;
        this.isLeft = isLeft;
        this.roleEquip = roleEquip;
        if (isLeft)
        {
            Vector3 pos =transform.localPosition;
            transform.localPosition = new Vector3(-Mathf.Abs(pos.x), pos.y, pos.z);
            btnLabel.text = zhuangbei;
        }
        else
        {
            Vector3 pos = transform.localPosition;
            transform.localPosition = new Vector3(Mathf.Abs(pos.x), pos.y, pos.z);
            btnLabel.text = xiexia;
        }
        equipSprite.spriteName = it.Inventory.Icon;
        nameLabel.text = it.Inventory.Name;
        qualityLabel.text = Inventory.getStringByQualityType(it.Inventory.Quality);
        levelLabel.text = it.Inventory.Level.ToString();
        propertyLabel.text = it.Inventory.getPropertyString();
        powerLabel.text = it.Inventory.Power.ToString();
        upgradeLevelLabel.text = it.Level.ToString();
        descriptionLabel.text = it.Inventory.Description;
        gameObject.SetActive(true);
    }

    public void OnClose()
    {
        ClearObject();
        gameObject.SetActive(false);

        transform.parent.GetComponent<Knapsack>().DisableButton(); 
    }
    public void OnEquip()
    {//点击装备按钮和卸下按钮
        int startValue = PlayerInfo._instance.GetOverPower();
        if(isLeft)
        {//装备到身上
            itUI.Clear();//把格子清空
            PlayerInfo._instance.DressOn(it);
        }
        else
        {//从身上脱下
            roleEquip.Clear();//把身上的装备清空
            PlayerInfo._instance.DressOff(it);
        }
        int endValue = PlayerInfo._instance.GetOverPower();

        InventoryUI._instance.SendMessage("UpdateCount");

        powerShow.ShowPowerChange(startValue, endValue);

        OnClose();
    }

    public void OnUpgrade()
    {
        int coinNeed = (it.Level + 1) * it.Inventory.Price;
        bool isSuccess = PlayerInfo._instance.GetCoin(coinNeed);
        if(isSuccess)
        {//升级成功
            it.Level += 1;
            upgradeLevelLabel.text = it.Level.ToString();
            MessageManager._instance.ShowMessage("升级成功", 1.0f);
        }
        else
        {//升级失败
            MessageManager._instance.ShowMessage("金币不足，无法升级", 1.0f);
        }
    }

    void ClearObject()
    {
        it = null;
        itUI = null;
    }
}
