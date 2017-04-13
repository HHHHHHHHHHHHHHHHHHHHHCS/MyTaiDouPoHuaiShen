using UnityEngine;
using System.Collections;

public class FollowTargetPlayer : MonoBehaviour 
{
    public float smoothing = 4;
    private Vector3 offest;
    private GameObject player;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        offest = transform.position - player.transform.position;
        
    }

    void FixedUpdate()
    {
        //transform.position = player.transform.position + offest;
        Vector3 targetPos = player.transform.position + offest;
        transform.position=Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
    }
}
