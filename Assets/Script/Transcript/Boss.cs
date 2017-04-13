using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public float viewAngle = 60;
    public float smoothing = 1;
    public float attackDistance = 4;
    public float moveSpeed = 2;
    public float timeInterval = 1;
    public float[] attackArray;
    public GameObject bossBulletPrefab;

    private float timer = 0;
    private Transform player;
    private bool isAttack = false;
    private int attackIndex = 0;
    private Animation anim;
    private CharacterController cc;
    private GameObject attack01GameObject;
    private GameObject attack02GameObject;
    private Transform attack03Pos;
    void Awake()
    {
        anim = GetComponent<Animation>();
        cc = GetComponent<CharacterController>();
        attack01GameObject = transform.Find("attack01").gameObject;
        attack02GameObject = transform.Find("attack02").gameObject;
        attack03Pos = transform.Find("attack03Pos");
    }

    void Start()
    {
        player = TranscriptManager._instance.Player.transform;
    }

    void Update()
    {
        if (isAttack)
        {
            BackToStand();
        }
        else
        {
            Vector3 playerPos = player.position;
            playerPos.y = transform.position.y;
            float angle = Vector3.Angle(playerPos - transform.position, transform.forward);//保证夹角不受到Y轴影响
            if (timer <= timeInterval)
            {
                timer += Time.deltaTime;
            }
            if (angle <= viewAngle / 2)
            {
                //在攻击视野之内
                float distance = Vector3.Distance(playerPos, transform.position);

                if (distance <= attackDistance)
                {
                    //小于等于攻击距离，攻击
                    cc.SimpleMove(Vector3.zero);
                    if (timer >= timeInterval)
                    {//攻击间隔是不是好了
                        timer = 0;
                        Attack();
                    }
                    else
                    {
                        anim.Play("stand");
                    }
                }
                else
                {
                    //大于距离，追赶
                    anim.CrossFade("run");
                    cc.SimpleMove(transform.forward * moveSpeed);
                }
            }
            else
            {
                //在攻击视野之外，进行转向
                anim.CrossFade("walk");
                Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothing * Time.deltaTime);
            }
        }
    }


    void Attack()
    {
        isAttack = true;
        attackIndex++;
        if (attackIndex == 4)
        {
            attackIndex = 1;
        }
        anim.CrossFade("attack0" + attackIndex);
        //if(attackIndex==1)
        //{
        //    anim.CrossFade("attack01");
        //}
        //else if (attackIndex == 2)
        //{
        //    anim.CrossFade("attack02");
        //}
        //else if(attackIndex == 3)
        //{
        //    anim.CrossFade("attack03");
        //}
    }

    void BackToStand()
    {
        if (!(anim.IsPlaying("attack01") || anim.IsPlaying("attack02") || anim.IsPlaying("attack03")))
        {
            isAttack = false;
        }  
    }

    void PlayAttack01Effect()
    {
        attack01GameObject.SetActive(true);

        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;
        float angle = Vector3.Angle(playerPos - transform.position, transform.forward);//保证夹角不受到Y轴影响
        if (angle <= 180f / 2)
        {
            //在攻击视野之内
            float distance = Vector3.Distance(playerPos, transform.position);

            if (distance <= attackDistance)
            {
                player.GetComponent<PlayerAttack>().TakeDamage((int)attackArray[0]);
            }
        }
    }

    void PlayAttack02Effect()
    {
        attack02GameObject.SetActive(true);

        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;
        float angle = Vector3.Angle(playerPos - transform.position, transform.forward);//保证夹角不受到Y轴影响
        if (angle <= 90f / 2)
        {
            //在攻击视野之内
            float distance = Vector3.Distance(playerPos, transform.position);

            if (distance <= attackDistance)
            {
                player.GetComponent<PlayerAttack>().TakeDamage((int)attackArray[1]);
            }
        }
    }

    void PlayAttack03Effect()
    {
        GameObject go =  (GameObject)GameObject.Instantiate(bossBulletPrefab, attack03Pos.position, attack03Pos.rotation);
        go.GetComponent<BossBullet>().Damage = attackArray[2];
    }
}
