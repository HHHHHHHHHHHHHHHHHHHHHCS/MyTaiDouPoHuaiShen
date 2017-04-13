using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour 
{
    private Renderer[] renderArray;
    private NcCurveAnimation[] curveAnimArray;
    private GameObject effectOffset;

    void Start()
    {
        renderArray = transform.GetComponentsInChildren<Renderer>();
        curveAnimArray = transform.GetComponentsInChildren<NcCurveAnimation>();
        if (transform.Find("EffectOffset")!=null)
        {
            effectOffset = transform.Find("EffectOffset").gameObject;
        }
        
    }

    /*void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Show();
        }
    }*/

    public void Show()
    {
        if(effectOffset!=null)
        {
            effectOffset.SetActive(false);
            effectOffset.SetActive(true);
        }
        else
        {
            foreach(Renderer _render in renderArray)
            {
                _render.enabled = true;
            }
            foreach (NcCurveAnimation _anim in curveAnimArray)
            {
                _anim.ResetAnimation();
            }
        }
    }

}
