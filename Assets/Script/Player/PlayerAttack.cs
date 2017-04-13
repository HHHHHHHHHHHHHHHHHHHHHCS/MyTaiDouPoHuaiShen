using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AttackRanage
{
    Forward,
    Around
}

public class PlayerAttack : MonoBehaviour 
{
    public PlayerEffect[] effectArray;

    private int hp = 1000;

    private Dictionary<string, PlayerEffect> effectDict = new Dictionary<string, PlayerEffect>();

    private float distanceAttackForward = 5.0f;
    private float distanceAttackAround = 5.0f;
    private float attackAngle = 180.0f;
    private int[] damageArray = new int[] { 20, 30, 30, 30 };
    private Animator anim;
    private GameObject hudTextGameObject;
    private HUDText hudText;

    void Start()
    {
        anim = GetComponent<Animator>();
        Transform damageShowPoint = transform.Find("DamageShowPoint");
        hudTextGameObject = HpBarManager._instance.GetHudText(damageShowPoint.gameObject);
        hudText = hudTextGameObject.GetComponent<HUDText>();
        PlayerEffect[] peArray = transform.GetComponentsInChildren<PlayerEffect>();
        foreach(PlayerEffect pe in peArray)
        {
            effectDict.Add(pe.gameObject.name, pe);
        }

        foreach (PlayerEffect pe in effectArray)
        {
            effectDict.Add(pe.gameObject.name, pe);
        }
    }

    /// <summary>
    /// 0 normal skill1 skill2 skill3
    /// 1 effect name
    /// 2 sound name
    /// 3 move forward
    /// 4 jump height
    /// </summary>
    /// <param name="args"></param>
    void Attack(string args)
    {
        string[] proArray = args.Split(',');
        //1 play effect
        string effectName = proArray[1];
        ShowPlayerEffect(effectName);
        //2 play sound
        string soundName = proArray[2];
        SoundManager._instance.Play(soundName); 
        //3 move forward
        float moveForward = float.Parse(proArray[3]);
        if(moveForward>0.1f)
        {
            iTween.MoveBy(this.gameObject, Vector3.forward * moveForward, 0.3f);
        }
        //0 DPS
        string posType = proArray[0];
        if (posType == "normal")
        {
            ArrayList array = GetEnemyInAttackRanage(AttackRanage.Forward);
            foreach(GameObject go in array)
            {  
                Enemy _enemy = go.GetComponent<Enemy>();
                if (_enemy!=null)
                {
                    _enemy.TakeDamage(damageArray[0], int.Parse(proArray[3]), int.Parse(proArray[4]));//TODO:        
                }
            }
        }
    }
    /// <summary>
    /// 0 normal skill1 skill2 skill3
    /// 1 move forward
    /// 2 jump height
    /// </summary>
    /// <param name="args"></param>
    void SkillAttack(string args)
    {
        string[] proArray = args.Split(',');
        //0 DPS
        string posType = proArray[0];
        if (posType == "skill1")
        {
            ArrayList array = GetEnemyInAttackRanage(AttackRanage.Around);
            foreach (GameObject go in array)
            {
                Enemy _enemy = go.GetComponent<Enemy>();
                if (_enemy != null)
                {
                    _enemy.TakeDamage(damageArray[1], int.Parse(proArray[1]), int.Parse(proArray[2]));
                }
                
            }
        }
        else if (posType == "skill2")
        {
            ArrayList array = GetEnemyInAttackRanage(AttackRanage.Around);
            foreach (GameObject go in array)
            {
                Enemy _enemy = go.GetComponent<Enemy>();
                if (_enemy != null)
                {
                    _enemy.TakeDamage(damageArray[2], int.Parse(proArray[1]), int.Parse(proArray[2]));
                }
            }
        }
        else if (posType == "skill3")
        {
            ArrayList array = GetEnemyInAttackRanage(AttackRanage.Forward);
            foreach (GameObject go in array)
            {
                Enemy _enemy = go.GetComponent<Enemy>();
                if (_enemy != null)
                {
                    _enemy.TakeDamage(damageArray[3], int.Parse(proArray[1]), int.Parse(proArray[2]));
                }
            }
        }
    }

    void PlaySound(string soundName)
    {
        SoundManager._instance.Play(soundName); 
    }


    void ShowPlayerEffect(string effectName)
    {
        PlayerEffect pe;
        if(effectDict.TryGetValue(effectName, out pe))
        {
            pe.Show();
        }
    }



    void ShowEffectDevilHand()
    {
        string effectName = "DevilHandMobile";
        PlayerEffect pe;
        effectDict.TryGetValue(effectName, out pe);
        ArrayList array = GetEnemyInAttackRanage(AttackRanage.Around);
        foreach (GameObject go in array)
        {
            RaycastHit hit;
            bool isHit = Physics.Raycast(go.transform.position + Vector3.up, Vector3.down, out hit, 10.0f, LayerMask.GetMask("Ground"));
            if (isHit)
            {
                GameObject newGo = (GameObject)GameObject.Instantiate(pe.gameObject, hit.point, Quaternion.identity);
            }
        }
    }
    void ShowEffectToTarget(string effectName)
    {
        PlayerEffect pe;
        effectDict.TryGetValue(effectName, out pe);
        ArrayList array = GetEnemyInAttackRanage(AttackRanage.Around);
        foreach (GameObject go in array)
        {
            RaycastHit hit;
            bool isHit = Physics.Raycast(go.transform.position + Vector3.up, Vector3.down, out hit, 10.0f, LayerMask.GetMask("Ground"));
            if (isHit)
            {
                GameObject newGo = (GameObject)GameObject.Instantiate(pe.gameObject, hit.point, Quaternion.identity);
            }
        }
    }

    void ShowEffectSelfToTarget(string effectName)
    {
        PlayerEffect pe;
        effectDict.TryGetValue(effectName, out pe);
        ArrayList array = GetEnemyInAttackRanage(AttackRanage.Around);
        foreach (GameObject go in array)
        {
            GameObject newGo = (GameObject)GameObject.Instantiate(pe.gameObject,transform.position+2*Vector3.up,Quaternion.identity);
            newGo.GetComponent<EffectSettings>().Target = go;
        }
    }

    //得到在攻击范围之内的敌人
    ArrayList GetEnemyInAttackRanage(AttackRanage attackRanage)
    {
        ArrayList arrayList = new ArrayList();
        if(attackRanage==AttackRanage.Forward)
        {
            foreach( GameObject go in TranscriptManager._instance.EnemyList)
            {
                Vector3 pos = go.transform.position-TranscriptManager._instance.Player.transform.position;

                if(pos.magnitude<distanceAttackForward)
                {
                    Vector3 forward = TranscriptManager._instance.Player.transform.forward;
                    float rot = Vector2.Angle(new Vector2(pos.x, pos.z), new Vector2(forward.x, forward.z));                 

                    if (rot >= attackAngle / -2 && rot <= attackAngle / 2)
                    {
                        arrayList.Add(go);
                    }
                }
            }
        }
        else if(attackRanage==AttackRanage.Around)
        {
            foreach (GameObject go in TranscriptManager._instance.EnemyList)
            {
                float distance = Vector3.Distance(go.transform.position, TranscriptManager._instance.Player.transform.position);
                if (distance < distanceAttackAround)
                {
                    arrayList.Add(go);
                }
            }
        }
        return arrayList;
    }

    public void TakeDamage(int damage)
    {
        if (hp <= 0)
            return;
        hp -= damage;
        //播放受到攻击动画
        if(hp*0.15f<=damage)
        {
            anim.SetTrigger("TakeDamage");
        }
        //显示血量的减少
        hudText.Add("-" + damage, Color.red, 0.3f);
        //屏幕上血红的特效显示
        BloodScreen.Instance.Show();
    }
}
