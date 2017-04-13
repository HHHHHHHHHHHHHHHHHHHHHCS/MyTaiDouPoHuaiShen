using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public GameObject damageEffectPrefab;
    public int maxHp = 200;
    public float speed = 2;
    public float attackRate = 2;//攻击速率，表示多少秒攻击一次
    public float attackDistance = 3;
    public float downSpeed = 1;
    public int damage = 10;

    private int hp=0;
    private float distance = 0;
    private float attackTimer = 0;
    private Animation anim;
    private Transform bloodPoint;
    private GameObject hpBarGameObject;
    private UISlider hpBarSlider;
    private GameObject hudTextGameObject;
    private HUDText hudText;

    private CharacterController cc;


    void Start()
    {
        anim = transform.GetComponent<Animation>();
        cc = GetComponent<CharacterController>();
        bloodPoint = transform.Find("BloodPoint").transform;
        InvokeRepeating("CalcDistance", 0,0.1f);
        Transform hpBarPoint = transform.Find("HpBarPoint");
        hpBarGameObject = HpBarManager._instance.GetHpBar(hpBarPoint.gameObject);
        Transform hudTextPoint = transform.Find("HudTextPoint");
        hudTextGameObject = HpBarManager._instance.GetHudText(hudTextPoint.gameObject);
        hudText = hudTextGameObject.GetComponent<HUDText>();
        hpBarSlider = hpBarGameObject.transform.Find("Bg").GetComponent<UISlider>();
        hp = maxHp;

        TranscriptManager._instance.Add(this.gameObject);
        this.gameObject.transform.parent = TranscriptManager._instance.transform;
    }

    void Update()
    {

        if(hp>0)
        {



            if (distance <= attackDistance)
            {
                if (attackTimer <= 0)
                {//进行攻击
                    Transform player = TranscriptManager._instance.Player.transform;
                    Vector3 targetPos = player.position;
                    targetPos.y = transform.position.y;
                    transform.LookAt(targetPos);
                    anim.Play("attack01");
                    attackTimer = attackRate;
                }
                else if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                if (!anim.IsPlaying("attack01"))
                {
                    anim.CrossFade("idle");
                }
            }
            else
            {
                anim.Play("walk");
                Move();
            }
        }
        else if(hp<=0)
        {//移到地下
            transform.Translate(-transform.up * downSpeed*Time.deltaTime);
        }

    }

    void Attack()
    {
        Transform player = TranscriptManager._instance.Player.transform; 
        distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackDistance)
        {
            player.GetComponent<PlayerAttack>().TakeDamage(damage);
        }

    }

    void Move()
    {
        Transform player = TranscriptManager._instance.Player.transform;
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        cc.SimpleMove(transform.forward * speed);
    }

    void CalcDistance()
    {
        Transform player = TranscriptManager._instance.Player.transform;
        distance = Vector3.Distance(player.position, transform.position);
    }

    /// <summary>
    /// 受到伤害调用，受到多少伤害，浮空和后退
    /// </summary>
    public void TakeDamage(int damage, int move, int height)
    {
        //受伤
        if(hp<=0)
        {
            return;
        }

        hp -= damage;
        Combo._instance.ComboPlus();
        hpBarSlider.value = (float)hp / maxHp;
        hudText.Add("-" + damage, Color.red, 0.2f);
        //受到攻击动画
        anim.Play("takedamage");

        //受伤声音
        SoundManager._instance.Play("Hurt");
        //浮空和后退
        Vector3 rot = Vector3.Normalize(TranscriptManager._instance.Player.transform.position - transform.position);
        Vector3 up = transform.up;
        iTween.MoveBy(this.gameObject,move*rot+up*height,0.3f);


        //出血特效
        GameObject go = (GameObject)GameObject.Instantiate(damageEffectPrefab, bloodPoint.position, Quaternion.identity);
        go.transform.LookAt(TranscriptManager._instance.Player.transform.position);


        //死亡
        if (hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        CancelInvoke("CalcDistance");
        this.GetComponent<CharacterController>().enabled = false;
        Destroy(hpBarGameObject);
        Destroy(hudTextGameObject, 0.5f);
        TranscriptManager._instance.Remove(gameObject);
        Destroy(gameObject, 4.0f);
        int random = Random.Range(0, 10);
        if(random<=7)
        {
            //第一种死亡方式是播放死亡动画
            anim.Play("die");
        }
        else
        {
            //第二种死亡方式是使用破碎效果
            GetComponentInChildren<MeshExploder>().Explode();
            this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }

    }
}
