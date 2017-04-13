using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private float speed = 7.5f;
    private Animator anim;
    private CharacterController cc;
    void Awake()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(anim.GetCurrentAnimatorStateInfo(1).IsName("Empty State")&&(Mathf.Abs(h)>0.05f||Mathf.Abs(v)>0.05f))
        {
 
            transform.LookAt(new Vector3(-h, 0, -v)+transform.position);
            cc.SimpleMove(transform.forward * speed);
        }
        else
        {
            cc.SimpleMove(Vector3.zero);
        }
    }

}
