using UnityEngine;
using System.Collections;

public class FollowTargetBip : MonoBehaviour 
{
    private Vector3 offest;
    private GameObject player;
    private Transform bip;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        bip = player.transform.Find("Bip01");
        offest = transform.position - bip.position;
        
    }

    void Update()
    {
        transform.position = bip.position + offest;
    }
}
