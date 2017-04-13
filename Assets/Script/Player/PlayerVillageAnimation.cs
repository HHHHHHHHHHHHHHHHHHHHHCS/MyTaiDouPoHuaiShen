using UnityEngine;
using System.Collections;

public class PlayerVillageAnimation : MonoBehaviour 
{
    private Animator anim;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        if(rigidbody.velocity.magnitude>0.05f)
        {
            anim.SetBool("move", true);
            anim.Play("run");
        }
        else
        {
            anim.SetBool("move", false);
            anim.Play("idle");
        }

    }
}
