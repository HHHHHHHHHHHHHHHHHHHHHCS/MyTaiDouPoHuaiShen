using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour 
{
    public static SkillManager _instance;
    private List<Skill> skillList = new List<Skill>();
    void Awake()
    {
        _instance = this;

        foreach(KeyValuePair<int,Skill> keyValue in SkillData.SkillDataDict)
        {
            skillList.Add(keyValue.Value);
        }
        InitSkill();
    }

    public Skill GetSkillByPosition (SkillPosType skillPosType)
    {
        PlayerInfo info = PlayerInfo._instance;
        foreach (Skill skill in skillList)
        {
            if(skill.PlayerType==info.PlayerType&&skill.SkillPosType==skillPosType)
            {
                return skill;
            }
        }
        return null;
    }

    public int GetNumberByPosition(SkillPosType skillPosType)
    {
        int t=-1;
        switch(skillPosType)
        {
            case SkillPosType.Basic:
            {
                t = 0;
                break;
            }
            case SkillPosType.One:
            {
                t = 1;
                break;
            }
            case SkillPosType.Two:
            {
                t = 2;
                break;
            }
           case SkillPosType.Three:
            {
                t = 3;
                break;
            }
        }
        return t;
    }

    public void InitSkill()
    {

    }
}
