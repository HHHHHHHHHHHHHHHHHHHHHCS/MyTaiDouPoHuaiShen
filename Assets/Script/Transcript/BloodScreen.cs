using UnityEngine;
using System.Collections;

public class BloodScreen : MonoBehaviour {

    private static BloodScreen _instance;


    public static BloodScreen Instance
    {
        get
        {
            return _instance;
        }
    }

    private UISprite sprite;
    private TweenAlpha tween;

	void Awake()
    {
        _instance = this;
        sprite = GetComponent<UISprite>();
        tween = GetComponent<TweenAlpha>();
    }

    public void Show()
    {
        sprite.alpha = 1;
        tween.ResetToBeginning();
        tween.PlayForward();
    }

}
