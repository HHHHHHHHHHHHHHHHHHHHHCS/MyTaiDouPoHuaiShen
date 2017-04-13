using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TranscriptDataManager : MonoBehaviour 
{
    private List<BtnTranscriptUI> btnTranscript1 = new List<BtnTranscriptUI>();
    private List<BtnTranscriptUI> btnTranscript2 = new List<BtnTranscriptUI>();
    private List<BtnTranscriptUI> btnTranscript3 = new List<BtnTranscriptUI>();

    void Awake()
    {
        AddListAndData(btnTranscript1, 1001, 2000);
        AddListAndData(btnTranscript2, 2001, 3000);
        AddListAndData(btnTranscript3, 3001, 4000);
    }

    void AddListAndData(List<BtnTranscriptUI> list, int start, int end)
    {
        Transform newTs;
        BtnTranscriptUI newTranscriptUI = null;
        BtnTranscript newBtnTranscript = null;
        for (int i = start; i < end; i++)
        {
            newTs = transform.Find("BtnTranscript/BtnTranscript_" + i);
            if (newTs != null)
            {
                newTranscriptUI = newTs.GetComponent<BtnTranscriptUI>();
                TranscriptData.BtnTranscriptDataDict.TryGetValue(i,out newBtnTranscript);
                newTranscriptUI.BtnTranscript = newBtnTranscript;
                list.Add(newTranscriptUI);
            }
            else
            {
                break;
            }
        }
    }

}
