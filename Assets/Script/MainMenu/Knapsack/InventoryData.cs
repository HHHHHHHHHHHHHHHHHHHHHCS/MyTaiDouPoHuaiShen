using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryData
{
    private const string defaultSpriteName = "bg_道具";
    static bool isFirst = true;
    private static Dictionary<int, Inventory> inventoryDataDict = new Dictionary<int, Inventory>();

    public static string DefaultSpriteName
    {
        get { return defaultSpriteName; }
    }

    public static Dictionary<int, Inventory> InventoryDataDict
    {
        get 
        {
            if (isFirst)
            {
                AwakeData();
            }
            return inventoryDataDict; 
        }
    }

    static bool AwakeData()
    {
        if(isFirst)
        {
            isFirst = false;

            #region StartEquipData
            Inventory newInventory;

            newInventory = new Inventory();
            newInventory.Id = 10001;
            newInventory.Name = "小型手镯";
            newInventory.Icon = "男性手镯 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Bracelet;
            newInventory.Price = 123;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 2;
            newInventory.Hp = 3;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "这个是一个手镯可以增加你的威力";
            inventoryDataDict.Add(newInventory.Id,newInventory);


            newInventory = new Inventory();
            newInventory.Id = 10002;
            newInventory.Name = "白色翅膀";
            newInventory.Icon = "男性翅膀 (1)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Wing;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 3;
            newInventory.Hp = 4;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "这是一个非常神奇的翅膀";
            inventoryDataDict.Add(newInventory.Id, newInventory);

            newInventory = new Inventory();
            newInventory.Id = 10003;
            newInventory.Name = "装逼魔戒";
            newInventory.Icon = "男性戒指 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Ring;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 4;
            newInventory.Hp = 3;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "除了装逼，一无是处！";
            inventoryDataDict.Add(newInventory.Id, newInventory);


            newInventory = new Inventory();
            newInventory.Id = 10004;
            newInventory.Name = "振奋铠甲";
            newInventory.Icon = "男性盔甲 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Cloth;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 0;
            newInventory.Hp = 8;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "让你Xing奋的铠甲";
            inventoryDataDict.Add(newInventory.Id, newInventory);

            newInventory = new Inventory();
            newInventory.Id = 10005;
            newInventory.Name = "防爆头盔";
            newInventory.Icon = "男性头盔 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Helm;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 2;
            newInventory.Hp = 5;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "防爆头防爆菊的头盔";
            inventoryDataDict.Add(newInventory.Id, newInventory);


            newInventory = new Inventory();
            newInventory.Id = 10006;
            newInventory.Name = "辣鸡武器";
            newInventory.Icon = "男性武器 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Weapon;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 7;
            newInventory.Hp = 0;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "超辣超享受";
            inventoryDataDict.Add(newInventory.Id, newInventory);


            newInventory = new Inventory();
            newInventory.Id = 10007;
            newInventory.Name = "挂机项链";
            newInventory.Icon = "男性项链 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Necklace;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 5;
            newInventory.Hp = 2;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "有了它就可以挂机划水了";
            inventoryDataDict.Add(newInventory.Id, newInventory);

            newInventory = new Inventory();
            newInventory.Id = 10008;
            newInventory.Name = "蜗牛靴子";
            newInventory.Icon = "男性靴子 (2)";
            newInventory.InventoryType = InventoryType.Equip;
            newInventory.EquipType = EquipType.Shoes;
            newInventory.Price = 233;
            newInventory.StartLevel = 1;
            newInventory.Quality = QualityType.Common;
            newInventory.Damage = 1;
            newInventory.Hp = 6;
            newInventory.Power = GetPowerByNum(newInventory.Hp, newInventory.Damage);
            newInventory.Description = "蜗牛穿了都说好";
            inventoryDataDict.Add(newInventory.Id, newInventory);

            #endregion
            #region StartDrugData
            newInventory = new Inventory();
            newInventory.Id = 11001;
            newInventory.Name = "小体力丹";
            newInventory.Icon = "小体力丹";
            newInventory.InventoryType = InventoryType.Drug;
            newInventory.Quality = QualityType.Common;
            newInventory.Price = 10;
            newInventory.PlayerInfoType = PlayerInfoType.Energy;
            newInventory.ApplyValue = 10;
            newInventory.Description = "打怪升级都靠它，恢复10点生命值";
            inventoryDataDict.Add(newInventory.Id, newInventory);

            newInventory = new Inventory();
            newInventory.Id = 11002;
            newInventory.Name = "大体力丹";
            newInventory.Icon = "大体力丹";
            newInventory.InventoryType = InventoryType.Drug;
            newInventory.Quality = QualityType.Common;
            newInventory.Level = 5;
            newInventory.Price = 20;
            newInventory.PlayerInfoType = PlayerInfoType.Energy;
            newInventory.ApplyValue = 20;
            newInventory.Description = "打怪升级单挑BOSS都靠它，恢复20点生命值";
            inventoryDataDict.Add(newInventory.Id, newInventory);
            #endregion
            #region StartUseItem
            newInventory = new Inventory();
            newInventory.Id = 16001;
            newInventory.Name = "黄金宝箱";
            newInventory.Icon = "黄金宝箱";
            newInventory.InventoryType = InventoryType.Rubbish;
            newInventory.Price = 10;
            newInventory.Description = "可以卖50大洋哦";
            inventoryDataDict.Add(newInventory.Id, newInventory);
            
            #endregion
            return true;
        }
        return false;
    }

    public static bool AddInventoryItemData(Inventory newInventory)
    {
        int id = newInventory.Id;
        if(InventoryDataDict.ContainsKey(id))
        {
            return false;
        }
        else
        {
            InventoryDataDict.Add(id,newInventory);
            return true;
        }
    }

    public static bool RemoveInventoryItemData(Inventory newInventory)
    {
        int id = newInventory.Id;
        if (InventoryDataDict.ContainsKey(id))
        {
            InventoryDataDict.Remove(id);
            return true;
        }
        else
        {
            return false;

        }
    }

    public static int GetPowerByNum(int hp,int damage)
    {
        return hp + damage*2;
    }

    public static int GetUpgradeLevel(int power,int level)
    {
        if(level<=1)
        {
            return power;
        }
        return (int)(power * (1 + (level - 1) / 10f));
    }
}
