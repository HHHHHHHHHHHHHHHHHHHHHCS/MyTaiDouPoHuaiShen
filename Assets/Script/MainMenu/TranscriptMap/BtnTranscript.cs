using UnityEngine;
using System.Collections;

public class BtnTranscript
{
    private int id;
    private int needLevel;
    private string transcriptName;
    private string des;



    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public int NeedLevel
    {
        get { return needLevel; }
        set { needLevel = value; }
    }
    public string TranscriptName
    {
        get { return transcriptName; }
        set { transcriptName = value; }
    }

    public string Des
    {
        get { return des; }
        set { des = value; }
    }
}
