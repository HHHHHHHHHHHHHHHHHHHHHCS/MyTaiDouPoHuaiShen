using UnityEngine;
using System.Collections;

public class KnapsackRole : MonoBehaviour 
{
    private KnapsackRoleEquip helmEquip;
    private KnapsackRoleEquip clothEquip;
    private KnapsackRoleEquip weaponEquip;
    private KnapsackRoleEquip shoesEquip;
    private KnapsackRoleEquip necklackEquip;
    private KnapsackRoleEquip braceletEquip;
    private KnapsackRoleEquip ringEquip;
    private KnapsackRoleEquip wingEquip;

    private UISprite helmSprite;
    private UISprite clothSprite;
    private UISprite weaponSprite;
    private UISprite shoesSprite;
    private UISprite necklackSprite;
    private UISprite braceletSprite;
    private UISprite ringSprite;
    private UISprite wingSprite;

    private UILabel hpLabel;
    private UILabel damageLabel;
    private UILabel expLabel;
    private UISlider expSlider;


	void Awake () 
    {
        Transform father = transform;

        helmEquip = father.Find("HelmSprite").GetComponent<KnapsackRoleEquip>();
        clothEquip = father.Find("ClothSprite").GetComponent<KnapsackRoleEquip>();
        weaponEquip = father.Find("WeaponSprite").GetComponent<KnapsackRoleEquip>();
        shoesEquip = father.Find("ShoesSprite").GetComponent<KnapsackRoleEquip>();
        necklackEquip = father.Find("NecklaceSprite").GetComponent<KnapsackRoleEquip>();
        braceletEquip = father.Find("BraceletSprite").GetComponent<KnapsackRoleEquip>();
        ringEquip = father.Find("RingSprite").GetComponent<KnapsackRoleEquip>();
        wingEquip = father.Find("WingSprite").GetComponent<KnapsackRoleEquip>();

        helmSprite = father.Find("HelmSprite").GetComponent<UISprite>();
        clothSprite = father.Find("ClothSprite").GetComponent<UISprite>();
        weaponSprite = father.Find("WeaponSprite").GetComponent<UISprite>();
        shoesSprite = father.Find("ShoesSprite").GetComponent<UISprite>();
        necklackSprite = father.Find("NecklaceSprite").GetComponent<UISprite>();
        braceletSprite = father.Find("BraceletSprite").GetComponent<UISprite>();
        ringSprite = father.Find("RingSprite").GetComponent<UISprite>();
        wingSprite = father.Find("WingSprite").GetComponent<UISprite>();

        hpLabel = father.Find("HpBg/Label").GetComponent<UILabel>();
        damageLabel = father.Find("DamageBg/Label").GetComponent<UILabel>();
        expLabel=father.Find("ExpSlider/Label").GetComponent<UILabel>();
        expSlider = father.Find("ExpSlider").GetComponent<UISlider>();

        PlayerInfo._instance.OnPlayerInfoChangeEvent += this.OnPlayerInfoChange;
    }

    void OnDestory()
    {
        PlayerInfo._instance.OnPlayerInfoChangeEvent -= this.OnPlayerInfoChange;
    }

    void OnPlayerInfoChange(PlayerInfoType playerInfoType)
    {
        if(playerInfoType==PlayerInfoType.All||playerInfoType==PlayerInfoType.Hp
            ||playerInfoType==PlayerInfoType.Damage||playerInfoType==PlayerInfoType.Exp
            ||playerInfoType == PlayerInfoType.Equip)
        {
            UpdateShow();
        }
    }
	

	void UpdateShow () 
    {
        PlayerInfo info = PlayerInfo._instance;
 
        /*helmEquip.SetId(info.HelmID);
        clothEquip.SetId(info.ClothID);
        weaponEquip.SetId(info.WeaponID);
        shoesEquip.SetId(info.ShoesID);
        necklackEquip.SetId(info.NecklaceID);
        braceletEquip.SetId(info.BraceletID);
        ringEquip.SetId(info.RingID);
        wingEquip.SetId(info.WingID);*/

        helmEquip.SetInventoryItem(info.HelmInventoryItem);
        clothEquip.SetInventoryItem(info.ClothInventoryItem);
        weaponEquip.SetInventoryItem(info.WeaponInventoryItem);
        shoesEquip.SetInventoryItem(info.ShoesInventoryItem);
        necklackEquip.SetInventoryItem(info.NecklaceInventoryItem);
        braceletEquip.SetInventoryItem(info.BraceletInventoryItem);
        ringEquip.SetInventoryItem(info.RingInventoryItem);
        wingEquip.SetInventoryItem(info.WingInventoryItem);

        hpLabel.text = info.Hp.ToString();
        damageLabel.text = info.Damage.ToString();
        expSlider.value = (float)info.Exp / GameController.GetMaxExpByLeverl(info.Level);
        expLabel.text = info.Exp + "/" + GameController.GetMaxExpByLeverl(info.Level);
	}
}
