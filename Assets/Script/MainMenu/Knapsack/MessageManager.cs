using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour 
{
    public static MessageManager _instance;
    private UILabel messageLabel;
    private TweenAlpha tween;
    private bool isSetActive = true;
    private int count = 0;
    void Awake()
    {
        _instance = this;
        messageLabel = transform.Find("Label").GetComponent<UILabel>();
        tween = transform.GetComponent<TweenAlpha>();

        EventDelegate ed = new EventDelegate(this, "OnTweenFinished");
        tween.onFinished.Add(ed);

        isSetActive = false;
        gameObject.SetActive(false);
    }

    public void ShowMessage(string message,float time=1)
    {
        gameObject.SetActive(true);
        StartCoroutine(Show(message, time));
    }

    IEnumerator Show(string message, float time=1)
    {
        tween.PlayForward();
        messageLabel.text = message;
        isSetActive = true;
        count++;
        yield return new WaitForSeconds(time);
        count--;
        if(count==0)
        {
            isSetActive = false;
            tween.PlayReverse();
        }
    }

    public void OnTweenFinished()
    {
        gameObject.SetActive(isSetActive);
    }
}
