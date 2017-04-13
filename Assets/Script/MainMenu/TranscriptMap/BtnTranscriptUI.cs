using UnityEngine;
using System.Collections;

public class BtnTranscriptUI : MonoBehaviour 
{
    private BtnTranscript btnTranscript;

    public BtnTranscript BtnTranscript
    {
        get { return btnTranscript; }
        set { btnTranscript = value; }
    }

    void OnClick()
    {

        transform.parent.parent.GetComponent<TranscriptMapUI>().OnBtnTranscriptClick(btnTranscript);
    }
}
