using UnityEngine;
using System.Collections;

public class PowerShow : MonoBehaviour 
{
    private float startValue = 0;
    private int endValue = 0;
    private bool isStart = false;
    private float speed = 1000;
    private bool isUp = true;

    private bool isTimer = false;
    private float maxTimer = 1.0f;
    private float nowTimer = 0.0f;

    private UILabel numLabel;
    private TweenAlpha tween;

    #region GetAndSet
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    #endregion

    void Awake()
    {
        numLabel = transform.Find("Label").GetComponent<UILabel>();
        tween=this.GetComponent<TweenAlpha>();

        EventDelegate ed = new EventDelegate(this, "OnTweenFinish");
        tween.onFinished.Add(ed);

        gameObject.SetActive(false);
    }

    void Update()
    {
        if(isStart)
        {
            if (isUp)
            {
                float _t = speed * Time.deltaTime;

                if (startValue + _t < endValue)
                {
                    startValue += _t; 
                }
                else
                {
                    startValue = endValue;
                    Hide();
                }
                
            }
            else
            {
                float _t = speed * Time.deltaTime;

                if (startValue - _t > endValue)
                {
                    startValue -= _t;
                }
                else
                {
                    startValue = endValue;
                    Hide();
                }

            }
            numLabel.text = ((int)startValue).ToString();
        }

        if(isTimer)
        {
            if(nowTimer>0)
            {
                nowTimer -= Time.deltaTime;
                
            }
            else
            {
                nowTimer = 0;
                isTimer = false;
                tween.PlayReverse();
            }
        }


    }

    public void ShowPowerChange(int startValue,int endValue)
    {
        gameObject.SetActive(true);
        tween.PlayForward();
        this.startValue = startValue;
        this.endValue = endValue;
        if(startValue==endValue)
        {
            speed = 0;
        }
        else
        {
            this.speed = Mathf.Abs((endValue - startValue) / 0.4f);
        }
        
        isUp = startValue<=endValue;
        isStart = true;
        if(isTimer)
        {
            nowTimer = maxTimer;
        }
    }

    public void Hide()
    {
        nowTimer = maxTimer;
        isStart = false;
        isTimer = true;
    }

    public void OnTweenFinish()
    {
        if(!isStart&&!isTimer)
        {
            gameObject.SetActive(isStart);
        }
    }
}
