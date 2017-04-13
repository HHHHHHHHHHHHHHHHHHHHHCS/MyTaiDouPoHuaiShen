using UnityEngine;
using System.Collections;
public enum PlayerInfoType
{
    Name,
    HeadPortrait,
    Level,
    Exp,
    MaxExp,
    Diamond,
    Coin,
    Energy,
    Toughen,
    Hp,
    Damage,
    Power, 
    Equip,
    All
}

public enum PlayerType
{
    Warrior,
    FemaleAssassin
}
public class PlayerInfo : MonoBehaviour
{
    #region Info
    //姓名
    //头像
    //等级
    //经验数
    //最大经验数
    //钻石数
    //金币数
    //体力数
    //历练数
    //生命
    //伤害
    //战斗力
    //角色类型
    #endregion

    #region property
    private string _name = "NoName";
    private string _headPortrait = "";
    private int _level = 0;
    private int _exp = 0;
    private int _maxExp = 0;
    private int _diamond = 0;
    private int _coin = 0;
    private int _energy = 0;
    private int _toughen = 0;
    private int _hp = 0;
    private int _damage = 0;
    private int _power = 0;
    private PlayerType _playerType = PlayerType.Warrior;

    /*private int _helmID = 0;
    private int _clothID = 0;
    private int _weaponID = 0;
    private int _shoesID = 0;
    private int _necklaceID = 0;
    private int _braceletID = 0;
    private int _ringID = 0;
    private int _wingID = 0;*/

    private InventoryItem _helmInventoryItem;
    private InventoryItem _clothInventoryItem;
    private InventoryItem _weaponInventoryItem;
    private InventoryItem _shoesInventoryItem;
    private InventoryItem _necklaceInventoryItem;
    private InventoryItem _braceletInventoryItem;
    private InventoryItem _ringInventoryItem;
    private InventoryItem _wingInventoryItem;
    
    
    #endregion

    #region get set methd
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string HeadPortrait
    {
        get { return _headPortrait; }
        set { _headPortrait = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }

    public int MaxExp
    {
        get { return _maxExp; }
        set { _maxExp = value; }
    }

    public int Diamond
    {
        get { return _diamond; }
        set { _diamond = value; }
    }

    public int Coin
    {
        get { return _coin; }
        set { _coin = value; }
    }

    public int Energy
    {
        get { return _energy; }
        set { _energy = value; }
    }

    public int Toughen
    {
        get { return _toughen; }
        set { _toughen = value; }
    }
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }

    public PlayerType PlayerType
    {
        get { return _playerType; }
        set { _playerType = value; }
    }

    /*public int HelmID
    {
        get { return _helmID; }
        set { _helmID = value; }
    }
    public int ClothID
    {
        get { return _clothID; }
        set { _clothID = value; }
    }
    public int WeaponID
    {
        get { return _weaponID; }
        set { _weaponID = value; }
    }
    public int ShoesID
    {
        get { return _shoesID; }
        set { _shoesID = value; }
    }
    public int NecklaceID
    {
        get { return _necklaceID; }
        set { _necklaceID = value; }
    }
    public int BraceletID
    {
        get { return _braceletID; }
        set { _braceletID = value; }
    }
    public int RingID
    {
        get { return _ringID; }
        set { _ringID = value; }
    }

    public int WingID
    {
        get { return _wingID; }
        set { _wingID = value; }
    }*/


    public InventoryItem HelmInventoryItem
    {
        get { return _helmInventoryItem; }
        set { _helmInventoryItem = value; }
    }


    public InventoryItem ClothInventoryItem
    {
        get { return _clothInventoryItem; }
        set { _clothInventoryItem = value; }
    }


    public InventoryItem WeaponInventoryItem
    {
        get { return _weaponInventoryItem; }
        set { _weaponInventoryItem = value; }
    }


    public InventoryItem ShoesInventoryItem
    {
        get { return _shoesInventoryItem; }
        set { _shoesInventoryItem = value; }
    }


    public InventoryItem NecklaceInventoryItem
    {
        get { return _necklaceInventoryItem; }
        set { _necklaceInventoryItem = value; }
    }


    public InventoryItem BraceletInventoryItem
    {
        get { return _braceletInventoryItem; }
        set { _braceletInventoryItem = value; }
    }


    public InventoryItem RingInventoryItem
    {
        get { return _ringInventoryItem; }
        set { _ringInventoryItem = value; }
    }


    public InventoryItem WingInventoryItem
    {
        get { return _wingInventoryItem; }
        set { _wingInventoryItem = value; }
    }
    #endregion

    #region Timer
    private float energyTimer = 0;//体力计时器
    private float toughenTimer = 0;//历练计时器

    public float EnergyTimer
    {
        get { return energyTimer; }
        set { energyTimer = value; }
    }
    public float ToughenTimer
    {
        get { return toughenTimer; }
        set { toughenTimer = value; }
    }
    public float EnergyAllTime
    {
        get { return ((99 - Energy) * 60 + (60 - EnergyTimer)); }
    }
    public float ToughenAllTime
    {
        get { return ((49 - Toughen) * 60 + (60 - ToughenTimer)); }
    }

    

    #endregion

    public static PlayerInfo _instance;

    public delegate void OnPlayerInfoChange(PlayerInfoType playerInfoType);//委托playerInfo被改变的时候
    public event OnPlayerInfoChange OnPlayerInfoChangeEvent = null;//委托事件

    void Awake()
    {
        _instance = this;   
    }

    void Start()
    {
        PlayerInfoInit();
        //InitEquip();
        OnPlayerInfoChangeEvent(PlayerInfoType.All);
    }

    void PlayerInfoInit()
    {
        this.Name = "我贵";
        this.HeadPortrait = "头像底板男性";
        this.Level = 1;
        this.Power = 0;
        this.Exp = 0;
        this.MaxExp = GameController.GetMaxExpByLeverl(this.Level);
        this.Diamond = 0;
        this.Coin = 10000;
        this.Energy = 100;
        this.Toughen = 50;

        this.Hp = 20 * this.Level;
        this.Damage = 10 * this.Level;
        this.Power = InventoryData.GetPowerByNum(this.Hp, this.Damage);

        /*this.BraceletID = 10001;
        this.WingID = 10002;
        this.RingID = 10003;
        this.ClothID = 10004;
        this.HelmID = 10005;
        this.WeaponID = 10006;
        this.NecklaceID = 10007;
        this.ShoesID = 10008;*/

    }

    /*void InitEquip()
    {
        PutOnEquip(BraceletID);
        PutOnEquip(WingID);
        PutOnEquip(RingID);
        PutOnEquip(ClothID);
        PutOnEquip(HelmID);
        PutOnEquip(WeaponID);
        PutOnEquip(NecklaceID);
        PutOnEquip(ShoesID);
    }*/

    void Update()
    {
        EnergyAndToughenTimer();
    }

    void EnergyAndToughenTimer()
    {//体力和精力的计时器
        if (this.Energy < 100)
        {
            this.EnergyTimer += Time.deltaTime;
            if (this.EnergyTimer >= 60)
            {
                this.EnergyTimer -= 60;
                this.Energy++;
                OnPlayerInfoChangeEvent(PlayerInfoType.Energy);
            }
        }
        else
        {
            this.EnergyTimer = 0;
        }

        if (this.Toughen < 50)
        {
            this.ToughenTimer += Time.deltaTime;
            if (this.ToughenTimer >= 60)
            {
                this.ToughenTimer -= 60;
                this.Toughen++;
                OnPlayerInfoChangeEvent(PlayerInfoType.Toughen);
            }
        }
        else
        {
            this.ToughenTimer = 0;
        }


    }

    public void ChangeNewName(string newName)
    {
        this.Name = newName;
        OnPlayerInfoChangeEvent(PlayerInfoType.Name);
    }
    public void DressOn(InventoryItem it)
    {
        it.IsDressed = true;
        bool isDressed = false;
        InventoryItem inventoryItemDressed = null;
        switch(it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
            {
                if(BraceletInventoryItem!=null)
                {
                    isDressed=true;
                    inventoryItemDressed = BraceletInventoryItem;
                }
                BraceletInventoryItem = it;
                break;
            }
            case EquipType.Cloth:
            {
                if (ClothInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = ClothInventoryItem;
                }
                ClothInventoryItem = it;
                break;
            }
            case EquipType.Helm:
            {
                if (HelmInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = HelmInventoryItem;
                }
                HelmInventoryItem = it;
                break;
            }
            case EquipType.Necklace:
            {
                if (NecklaceInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = NecklaceInventoryItem;
                }
                NecklaceInventoryItem = it;
                break;
            }
            case EquipType.Ring:
            {
                if (RingInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = RingInventoryItem;
                }
                RingInventoryItem = it;
                break;
            }
            case EquipType.Shoes:
            {
                if (ShoesInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = ShoesInventoryItem;
                }
                ShoesInventoryItem = it;
                break;
            }
            case EquipType.Weapon:
            {
                if (WeaponInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = WeaponInventoryItem;
                }
                WeaponInventoryItem = it;
                break;
            }
            case EquipType.Wing:
            {
                if (WingInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = WingInventoryItem;
                }
                WingInventoryItem = it;
                break;
            }
        }

        //首先检测有没有穿上相同类型的装备
        //有
        if(isDressed)
        {//把已经存在的他脱掉 放到背包
            inventoryItemDressed.IsDressed = false;
            InventoryUI._instance.AddInventoryItem(inventoryItemDressed);
        }
        OnPlayerInfoChangeEvent(PlayerInfoType.Equip);
        //没有
        //直接穿上
    }

    public void DressOff(InventoryItem it) 
    {//装备脱下
        switch (it.Inventory.EquipType)
        {
            case EquipType.Bracelet:
                {
                    if (BraceletInventoryItem != null)
                    {
                        BraceletInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Cloth:
                {
                    if (ClothInventoryItem != null)
                    {
                        ClothInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Helm:
                {
                    if (HelmInventoryItem != null)
                    {
                        HelmInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Necklace:
                {
                    if (NecklaceInventoryItem != null)
                    {
                        NecklaceInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Ring:
                {
                    if (RingInventoryItem != null)
                    {
                        RingInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Shoes:
                {
                    if (ShoesInventoryItem != null)
                    {
                        ShoesInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Weapon:
                {
                    if (WeaponInventoryItem != null)
                    {
                        WeaponInventoryItem = null;
                    }
                    break;
                }
            case EquipType.Wing:
                {
                    if (WingInventoryItem != null)
                    {
                        WeaponInventoryItem = null;
                    }
                    break;
                }
        }

        it.IsDressed = false;
        InventoryUI._instance.AddInventoryItem(it);
    }

    public void InventoryUse(InventoryItem it,int count)
    {
        //使用效果
        //TODO
        //处理物品使用后是否还存在
        ChangeInventoryCount(it, count);
    }

    public void ChangeInventoryCount(InventoryItem it,int count)
    {
        if (it.Count >= count)
        {
            it.Count -= count;
            if (it.Count == 0)
            {
                InventoryManager._instance.InventoryItemList.Remove(it);
            }
        }
    }

    public int GetOverPower()
    {
        int power = this.Power;

        if(HelmInventoryItem!=null)
        {
            power += InventoryData.GetUpgradeLevel(HelmInventoryItem.Inventory.Power, HelmInventoryItem.Level);
        }
        if (ClothInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(ClothInventoryItem.Inventory.Power, ClothInventoryItem.Level);
        }
        if (WeaponInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(WeaponInventoryItem.Inventory.Power, WeaponInventoryItem.Level);
        }
        if (ShoesInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(ShoesInventoryItem.Inventory.Power, ShoesInventoryItem.Level);
        }
        if (NecklaceInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(NecklaceInventoryItem.Inventory.Power, NecklaceInventoryItem.Level);
        }
        if (BraceletInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(BraceletInventoryItem.Inventory.Power, BraceletInventoryItem.Level);
        }
        if (RingInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(RingInventoryItem.Inventory.Power, RingInventoryItem.Level);
        }
        if (WingInventoryItem != null)
        {
            power += InventoryData.GetUpgradeLevel(WingInventoryItem.Inventory.Power, WingInventoryItem.Level);
        }

        return power;
    }

    public bool GetCoin(int count)
    {
        if(Coin>=count)
        {
            Coin -= count;
            OnPlayerInfoChangeEvent(PlayerInfoType.Coin);
            return true;
        }
        return false;
    }
    public void AddCoin(int count)
    {
        this.Coin += count;
        OnPlayerInfoChangeEvent(PlayerInfoType.Coin);
    }

    void PutOnEquip(int id)
    {//穿上装备
        if (id == 0)
        {
            return;
        }
        Inventory newInventory = null;
        InventoryData.InventoryDataDict.TryGetValue(id, out newInventory);
        this.Hp += newInventory.Hp;
        this.Damage += newInventory.Damage;
        this.Power += InventoryData.GetPowerByNum(this.Hp, this.Damage);
    }
    void PutOffEquip(int id)
    {//脱下装备
        if (id == 0)
        {
            return;
        }
        Inventory newInventory = null;
        InventoryData.InventoryDataDict.TryGetValue(id, out newInventory);
        this.Hp -= newInventory.Hp;
        this.Damage -= newInventory.Damage;
        this.Power -= InventoryData.GetPowerByNum(this.Hp, this.Damage);
    }
}
