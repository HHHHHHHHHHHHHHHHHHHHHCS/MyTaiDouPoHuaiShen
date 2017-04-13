using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillData
{
    private static bool isFirst = true;
    private static Dictionary<int, Skill> skillDataDict = new Dictionary<int, Skill>();

    public static Dictionary<int, Skill> SkillDataDict
    {
        get 
        { 
            if(isFirst)
            {
                AwakeData();
            }
            return skillDataDict; 
        }
    }

    static bool AwakeData()
    {
        if (isFirst)
        {
            isFirst = false;

            #region StartSkillData
            Skill newSkill;

            newSkill = new Skill();
            newSkill.Id = 1001;
            newSkill.SkillName = "浮生万刃";
            newSkill.Icon = "icon_zhu";
            newSkill.PlayerType = PlayerType.Warrior;
            newSkill.SkillType = SkillType.Basic;
            newSkill.SkillPosType = SkillPosType.Basic;
            newSkill.ColdTime = 0;
            newSkill.Damage = 30;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 1002;
            newSkill.SkillName = "永恒零度";
            newSkill.Icon = "icon_up";
            newSkill.PlayerType = PlayerType.Warrior;
            newSkill.SkillType = SkillType.Skill;
            newSkill.SkillPosType = SkillPosType.One;
            newSkill.ColdTime = 5;
            newSkill.Damage = 30;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 1003;
            newSkill.SkillName = "半月斩";
            newSkill.Icon = "iocn_ho";
            newSkill.PlayerType = PlayerType.Warrior;
            newSkill.SkillType = SkillType.Skill;
            newSkill.SkillPosType = SkillPosType.Two;
            newSkill.ColdTime = 8;
            newSkill.Damage = 40;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 1004;
            newSkill.SkillName = "咫尺天涯";
            newSkill.Icon = "iocn_yi";
            newSkill.PlayerType = PlayerType.Warrior;
            newSkill.SkillType = SkillType.Skill;
            newSkill.SkillPosType = SkillPosType.Three;
            newSkill.ColdTime = 10;
            newSkill.Damage = 50;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 2001;
            newSkill.SkillName = "雷动九天";
            newSkill.Icon = "icon_zhu";
            newSkill.PlayerType = PlayerType.FemaleAssassin;
            newSkill.SkillType = SkillType.Basic;
            newSkill.SkillPosType = SkillPosType.Basic;
            newSkill.ColdTime = 0;
            newSkill.Damage = 30;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 2002;
            newSkill.SkillName = "炽修罗";
            newSkill.Icon = "icon_li";
            newSkill.PlayerType = PlayerType.FemaleAssassin;
            newSkill.SkillType = SkillType.Skill;
            newSkill.SkillPosType = SkillPosType.One;
            newSkill.ColdTime = 5;
            newSkill.Damage = 35;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 2003;
            newSkill.SkillName = "不动明王";
            newSkill.Icon = "iocn_fo";
            newSkill.PlayerType = PlayerType.FemaleAssassin;
            newSkill.SkillType = SkillType.Skill;
            newSkill.SkillPosType = SkillPosType.Two;
            newSkill.ColdTime = 8;
            newSkill.Damage = 40;
            skillDataDict.Add(newSkill.Id, newSkill);

            newSkill = new Skill();
            newSkill.Id = 2004;
            newSkill.SkillName = "唯我独尊";
            newSkill.Icon = "iocn_ho";
            newSkill.PlayerType = PlayerType.FemaleAssassin;
            newSkill.SkillType = SkillType.Skill;
            newSkill.SkillPosType = SkillPosType.Three;
            newSkill.ColdTime = 13;
            newSkill.Damage = 50;
            skillDataDict.Add(newSkill.Id, newSkill);
            #endregion
            return true;
        }
        return false;
    }
}
