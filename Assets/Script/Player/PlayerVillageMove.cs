using UnityEngine;
using System.Collections;

public class PlayerVillageMove : MonoBehaviour 
{
    private float speed = 35;
    private Rigidbody myRigibody;
    private NavMeshAgent agent;

    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
    }

    private Rigidbody getRigidbody()
    {
        if (this.myRigibody == null)
        {
            this.myRigibody = GetComponent<Rigidbody>();
        }
        return this.myRigibody;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vec = getRigidbody().velocity;


        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            getRigidbody().velocity = new Vector3(-h * speed, vec.y, -v * speed);
            transform.LookAt(new Vector3(-h, 0, -v) + transform.position);
        }
        else if(agent.enabled==false)
        {
            getRigidbody().velocity = Vector3.zero;
        }

        /*if (agent.enabled)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity);
        }*/
    }
}
