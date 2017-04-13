using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerInfo
{
    public string ip = "";
    public int no;
    public string name = "";
    public int maxCount = 0;
    public int nowCount = 0;
}

public class ServerData
{

    private static List<ServerInfo> serverData = setServerData();

    public static List<ServerInfo> getServerData()
    {
        return serverData;
    }

    private static List<ServerInfo> setServerData()
    {
        List<ServerInfo> newServerData = new List<ServerInfo>();
        ServerInfo newServerInfo;
        int n=0;

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "心";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "疼";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "我";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "贵";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);
        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "心";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "疼";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "我";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "贵";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);
        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "心";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "疼";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "我";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "贵";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);
        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "心";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "疼";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "我";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "贵";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);
        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "心";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "疼";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "我";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);

        newServerInfo = new ServerInfo();
        newServerInfo.ip = "127.0.0.1:1433";
        newServerInfo.no = ++n;
        newServerInfo.name = "贵";
        newServerInfo.maxCount = 100;
        newServerInfo.nowCount = Random.Range(0, 100);
        newServerData.Add(newServerInfo);
        return newServerData;
    }

}
