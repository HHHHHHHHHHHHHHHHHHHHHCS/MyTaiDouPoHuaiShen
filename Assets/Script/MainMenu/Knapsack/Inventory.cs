using UnityEngine;
using System.Collections;

public enum InventoryType
{
    Equip,//10001-10999
    Drug,//11001-11999
    UseItem,//12001-12999
    Material,//13001-13999
    Task,//14001-14999
    Other,//15001-15999
    Rubbish//16001-16999
}

public enum EquipType
{
    Helm,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing
}

public enum QualityType
{
    Rubbish,//垃圾
    Common,//普通
    Senior,//高级
    Rare,//稀有
    Epic,//史诗
    Legend,//传说
    Ancient,//远古
    Pyx//圣器
}

public class Inventory
{
    #region property
    private int id;//ID
    private string name;//名称
    private string icon;//在图集中的名称
    private InventoryType inventoryType;//物品类型
    private EquipType equipType;//装备类型
    private int level = 1;//使用等级
    private int price = 0;//价格
    private int startLevel = 1;//初始星级
    private QualityType quality;//品质
    private int damage = 0;//伤害
    private int hp = 0;//生命
    private int power = 0;//战斗力
    private PlayerInfoType playerInfoType;//作用类型，表示作用在那个属性之上
    private int applyValue;//作用值
    private string description;//描述
    #endregion


    #region GetAndSetMethod
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public InventoryType InventoryType
    {
        get { return inventoryType; }
        set { inventoryType = value; }
    }
    public EquipType EquipType
    {
        get { return equipType; }
        set { equipType = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    public int StartLevel
    {
        get { return startLevel; }
        set { startLevel = value; }
    }
    public QualityType Quality
    {
        get { return quality; }
        set { quality = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }
    }
    public PlayerInfoType PlayerInfoType
    {
        get { return playerInfoType; }
        set { playerInfoType = value; }
    }
    public int ApplyValue
    {
        get { return applyValue; }
        set { applyValue = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    #endregion

    public static string getStringByQualityType(QualityType qt)
    {
        string result = "";
        switch(qt)
        {
            case QualityType.Rubbish:
            {
                result = "品质：垃圾";
                break;
            }
            case QualityType.Common:
            {
                result = "品质：普通";
                break;
            }
            case QualityType.Senior:
            {
                result = "品质：高级";
                break;
            }
            case QualityType.Rare:
            {
                result = "品质：稀有";
                break;
            }
            case QualityType.Epic:
            {
                result = "品质：史诗";
                break;
            }
            case QualityType.Legend:
            {
                result = "品质：传说";
                break;
            }
            case QualityType.Ancient:
            {
                result = "品质：远古";
                break;
            }
            case QualityType.Pyx:
            {
                result = "品质：圣器";
                break;
            }
            default:
            {
                result = "品质：无";
                break;
            }
        }
        return result;
    }

    public string getPropertyString()
    {
        string result = "";
        if (this.InventoryType == InventoryType.Equip)
        {
            result += "伤害：" + this.Damage.ToString();
            result += "\n生命：" + this.Hp.ToString();
        }
        else if (this.InventoryType == InventoryType.Drug)
        {
            result += "恢复生命：" + this.ApplyValue;
        }
        return result;
    }
}
