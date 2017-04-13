using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour 
{
    public static Combo _instance;
    public float comboTime = 2;//连击时间
    private int comboCount = 0;//连击数
    private float timer = 0;
    private UILabel numberLabel;
    private bool isBig = false;

    void Awake()
    {
        _instance = this;
        gameObject.SetActive(false);
        numberLabel = transform.Find("NumberLabel").GetComponent<UILabel>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            comboCount = 0; 
            gameObject.SetActive(false);
        }
        if(isBig&&(timer<=comboTime-1))
        {
            transform.localScale = Vector3.one;
            isBig = false;
        }
    }

    public void ComboPlus()
    {//增加连击
        gameObject.SetActive(true);
        timer = comboTime;
        comboCount++;
        numberLabel.text = comboCount.ToString();
        iTween.ScaleTo(gameObject, new Vector3(1.5f,1.5f,1.5f), 0.1f);
        isBig = true;
        iTween.ShakePosition(gameObject, new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
    }




}
