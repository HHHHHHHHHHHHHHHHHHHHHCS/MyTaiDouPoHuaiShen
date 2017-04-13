using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour 
{

    private Animator anim;
    private CharacterController cc;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cc.velocity.magnitude > 0.05f)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

    }


    public void OnAttackButtonClick(bool isPress,SkillPosType skillPosType)
    {
        if (isPress && skillPosType == SkillPosType.Basic)
        {
            anim.SetTrigger("Attack");
        }
        else if (skillPosType == SkillPosType.One)
        {
            anim.SetBool("Skill1", isPress);
        }
        else if (skillPosType == SkillPosType.Two)
        {
            anim.SetBool("Skill2", isPress);
        }
        else if (skillPosType == SkillPosType.Three)
        {
            anim.SetBool("Skill3", isPress);
        }

    }
}
