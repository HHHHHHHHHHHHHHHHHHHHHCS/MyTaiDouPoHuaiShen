using UnityEngine;
using System.Collections;

public class SkillItemUI : MonoBehaviour 
{
    public SkillPosType skillPosType;
    private Skill skill;
    private UISprite sprite;

    private UISprite Sprite
    {
        get
        {
            if(sprite==null)
            {
                sprite = transform.GetComponent<UISprite>();
            }
            return sprite;
        }
    }

    void Start()
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        this.skill = SkillManager._instance.GetSkillByPosition(skillPosType);
        Sprite.spriteName = skill.Icon;
        
    }

    void OnClick()
    {
        
        transform.parent.parent.GetComponent<SkillUI>().OnSkillCick(skill);
    }

}
