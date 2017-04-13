using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossBullet : MonoBehaviour 
{
    public float moveSpeed = 3;
    public float Damage
    {
        get;
        set;
    }
    private float repeatRate = 0.5f;
    private List<GameObject> playerList = new List<GameObject>();
    private float force = 2f;

    void Start()
    {
        InvokeRepeating("Attack", 0, repeatRate);
    }

	void Update () 
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}


    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            if(playerList.IndexOf(col.gameObject)==-1)
            {
                playerList.Add(col.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            if (playerList.IndexOf(col.gameObject) != -1)
            {
                playerList.Remove(col.gameObject);
            }
        }
    }

    void Attack()
    {
        foreach(GameObject player in playerList)
        {
            player.GetComponent<PlayerAttack>().TakeDamage((int)(Damage*repeatRate));
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.Move(transform.forward * force*repeatRate);
        }
    }
}
