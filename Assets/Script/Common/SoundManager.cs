using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour 
{
    public static SoundManager _instance;
    public AudioClip[] audioClipArray;
    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
    private AudioSource audioSource;
    private bool isQuiet = false;

    // Use this for initialization
	void Awake () 
    {
        _instance = this;
        audioSource = transform.GetComponent<AudioSource>();

	}
	
    void Start()
    {
        foreach(AudioClip ac in audioClipArray)
        {
            audioDict.Add(ac.name, ac);
        }
        
    }

	// Update is called once per frame
	void Update () {
	
	}


    public void Play(string audioName)
    {
        if (isQuiet)
            return;
        AudioClip ac;
        if(audioDict.TryGetValue(audioName, out ac))
        {
            //AudioSource.PlayClipAtPoint(ac, Vector3.zero);
            audioSource.PlayOneShot(ac);
        }
    }

    public void Play(string audioName,AudioSource _audioSource)
    {
        if (isQuiet)
            return;
        AudioClip ac;
        if (audioDict.TryGetValue(audioName, out ac))
        {
            //AudioSource.PlayClipAtPoint(ac,Vector3.zero);
            _audioSource.PlayOneShot(ac);
        }
        
    }
}
