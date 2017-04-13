using UnityEngine;
using System.Collections;

public enum SkillType
{
    Basic,
    Skill
}

public enum SkillPosType
{
    Basic,
    One,
    Two,
    Three
}

public class Skill : MonoBehaviour
{
    #region property
    private int id;
    private string skillName;
    private string icon;
    private PlayerType playerType;
    private SkillType skillType;
    private SkillPosType skillPosType;
    private int coldTime;
    private int damage;
    private int level = 1;
    
    #endregion

    #region Get Set Method
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string SkillName
    {
        get { return skillName; }
        set { skillName = value; }
    }

    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public PlayerType PlayerType
    {
        get { return playerType; }
        set { playerType = value; }
    }

    public SkillType SkillType
    {
        get { return skillType; }
        set { skillType = value; }
    }

    public SkillPosType SkillPosType
    {
        get { return skillPosType; }
        set { skillPosType = value; }
    }

    public int ColdTime
    {
        get { return coldTime; }
        set { coldTime = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    #endregion

    public void Upgrade()
    {
        Level++;
    }
}
