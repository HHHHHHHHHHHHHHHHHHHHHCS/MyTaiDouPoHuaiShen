using UnityEngine;
using System.Collections;

public class SkillButton : MonoBehaviour 
{
    public SkillPosType posType = SkillPosType.Basic;

    private PlayerAnimation playerAnimation;
    private float coldTime = 4;
    private float coldTimer = 0;
    private UISprite maskSprite;
    private UIButton btn;

    void Start()
    {
        playerAnimation = TranscriptManager._instance.Player.GetComponent<PlayerAnimation>();
        if (transform.Find("Mask")!=null)
        {
            maskSprite = transform.Find("Mask").GetComponent<UISprite>();

        }
        btn=transform.GetComponent<UIButton>();
    }

    void Update()
    {
        if (maskSprite == null)
            return;
        if(coldTimer>0)
        {
            coldTimer -= Time.deltaTime;
            maskSprite.fillAmount = coldTimer / coldTime;
        }
        if (coldTimer <= 0)
        {
            Enable();
            maskSprite.fillAmount = 0;
        }
    }


    void OnPress(bool isPress)
    {
        playerAnimation.OnAttackButtonClick(isPress, this.posType);
        if(isPress&&maskSprite!=null)
        {
            coldTimer = coldTime;
            Disable();
        }
    }

    void Disable()
    {
        transform.GetComponent<Collider>().enabled = false;
        btn.SetState(UIButton.State.Normal, true);
    }

    void Enable()
    {
        if (!transform.GetComponent<Collider>().enabled)
        {
            transform.GetComponent<Collider>().enabled = true;
        }
        
    }
}
