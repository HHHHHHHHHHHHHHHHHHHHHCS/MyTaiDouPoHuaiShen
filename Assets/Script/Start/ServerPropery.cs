using UnityEngine;
using System.Collections;

public class ServerPropery : MonoBehaviour 
{
    private string ip = "";
    private int no;
    private string serverName = "";
    private int maxCount = 0;
    private int nowCount = 0;



    public string Ip
    {
        get { return ip; }
        set { ip = value; }
    }
    public int No
    {
        get { return no; }
        set { no = value; }
    }
    public string ServerName
    {
        get
        {
            return serverName;
        }
        set
        {
            serverName = value;
            transform.GetChild(0).GetComponent<UILabel>().text = value;
        }
    }
    public int MaxCount
    {
        get { return maxCount; }
        set { maxCount = value; }
    }
    public int NowCount
    {
        get { return nowCount; }
        set { nowCount = value; }
    }

    public void OnPress(bool isPress)
    {
        if(!isPress)
        {//选择了当前的服务器
            transform.root.SendMessage("OnServerSelect",this.gameObject);
        }

    }
}
