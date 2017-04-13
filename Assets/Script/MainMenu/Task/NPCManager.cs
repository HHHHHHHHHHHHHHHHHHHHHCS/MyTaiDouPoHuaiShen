using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour 
{
    public static NPCManager _instance;
    private Dictionary<int, GameObject> npcDict = new Dictionary<int,GameObject>();
    private GameObject transcriptGo;

    public GameObject GetTranscriptGo()
    {
        return transcriptGo;
    }

    void Awake()
    {
        _instance = this;
        Init();
    }

    void Init()
    {
        transcriptGo = transform.Find("Transcript").gameObject;
        int key=0;
        foreach (Transform ts in transform)
        {
            key=0;
            if(int.TryParse(ts.name.Substring(0,4),out key))
            {
                npcDict.Add(key,ts.gameObject);  
            }
             
        }
    }

    public GameObject GetNpcById(int id)
    {
        GameObject go = null;
        npcDict.TryGetValue(id, out go);
        return go;
    }

}
