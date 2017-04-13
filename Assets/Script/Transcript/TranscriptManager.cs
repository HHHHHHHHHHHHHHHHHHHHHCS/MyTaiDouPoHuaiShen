using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TranscriptManager : MonoBehaviour 
{
    public static TranscriptManager _instance;

    private List<GameObject> enemyList = new List<GameObject>();

    private GameObject player;

    public List<GameObject> EnemyList
    {
        get
        {
            return enemyList;
        }
    }

    public GameObject Player
    {
        get
        {
            if(player==null)
            {
                
                player = GameObject.FindGameObjectWithTag("Player").gameObject;
            } 
            return player;
        }
    }

    void Awake()
    {
        _instance = this;


        /*Transform enemys = GameObject.Find("EnemyManager").transform;
        foreach(Transform ts in enemys)
        {
            enemyList.Add(ts.gameObject);
        }*/
    }

    public void Remove(GameObject go)
    {
        enemyList.Remove(go);
    }

    public void Add(GameObject go)
    {
        if(EnemyList.IndexOf(go)==-1)
        {
            enemyList.Add(go);
        }
        
    }

}
