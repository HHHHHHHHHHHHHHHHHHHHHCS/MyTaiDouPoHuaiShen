using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StartMenuController : MonoBehaviour 
{
    public static StartMenuController _instance;//实例化

    public TweenScale startPanelTween;//开始界面动画
    public TweenScale loginPanelTween;//登录界面动画
    public TweenScale registerPanelTween;//注册界面动画
    public TweenScale serverPanelTween;//服务器选择界面动画
    public TweenPosition startPanelTweenPos;//开始界面位位置
    public TweenPosition characterSelectTweenPos;//角色选择界面位置
    public TweenPosition characterChangeTweenPos;//角色创建界面位置
    private GameObject nowTweenGameObject;//当前的界面的游戏物体


    public UIGrid serverListGrid;//服务器格子
    public GameObject serverItemRed;//服务器爆满的Prefab
    public GameObject serverItemGreen;//服务器流畅的Prefab

    public UILabel lab_btn_server;//开始界面的服务器Label

    public GameObject selectServerPos;//服务器界面的选择服务器的位置，用于产生服务器Prefab

    public UIInput input_login_username;//输入的用户名
    public UIInput input_login_password;//输入的密码

    public UIInput input_register_username;//输入的注册用户名
    public UIInput input_register_password;//输入的注册密码
    public UIInput input_register_repassword;//输入的注册确认密码

    public UILabel label_username;//开始界面的用户名

    public GameObject[] characterArray;//创建英雄的列表
    public GameObject[] characterSelectedArray;//选择英雄的列表
    private GameObject characterSelected;//当前选择的英雄

    public UIInput input_characterName;//创建新的英雄的名字
    public UILabel label_character_name;//英雄的名字
    public UILabel label_character_lv;//英雄的等级
    public GameObject characterPos;//选择英雄的位置

    private static string txt_username;//用户名
    private static string txt_password;//用户密码
    private static ServerPropery sp_selected;//选择的服务器

    private bool haveInitServerList = false;//服务器列表是否初始化过

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        nowTweenGameObject = startPanelTween.gameObject;
        InitServerList();//初始化服务器列表

    }

    public void OnUsernameClick()
    {//1、输入帐号登录
        startPanelTween.PlayForward();
        StartCoroutine(HidePanel(startPanelTween.gameObject));
        nowTweenGameObject = loginPanelTween.gameObject;
        loginPanelTween.gameObject.SetActive(true);
        loginPanelTween.PlayForward();
    }

    public void OnServerClick()
    {//1、选择服务器
        startPanelTween.PlayForward();
        StartCoroutine(HidePanel(startPanelTween.gameObject));
        nowTweenGameObject = serverPanelTween.gameObject;
        serverPanelTween.gameObject.SetActive(true);
        serverPanelTween.PlayForward();

    }

    public void OnEnterGameClick()
    {//1、连接服务器，验证用户名和服务器
        //TODO
        //2、进入游戏选择界面
        startPanelTweenPos.PlayForward();
        HidePanel(startPanelTweenPos.gameObject);
        nowTweenGameObject = characterSelectTweenPos.gameObject;
        characterSelectTweenPos.gameObject.SetActive(true);
        characterSelectTweenPos.PlayForward();
    }

    public void OnLoginClick()
    {//把用户名和密码存储起来
        Txt_Username = input_login_username.value;
        Txt_Username = input_login_password.value;
        //返回开始界面
        loginPanelTween.PlayReverse();
        StartCoroutine(HidePanel(loginPanelTween.gameObject));
        nowTweenGameObject = startPanelTween.gameObject;
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse(); 
        //修改开始界面账户名
        label_username.text = Txt_Username;
    }

    public void OnRegisterShowClick()
    {//隐藏当前面板,显示注册面板
        loginPanelTween.PlayReverse();
        StartCoroutine(HidePanel(loginPanelTween.gameObject));
        nowTweenGameObject = registerPanelTween.gameObject;
        registerPanelTween.gameObject.SetActive(true);
        registerPanelTween.PlayForward(); 

    }

    public void OnLoginCloseClick()
    {//返回开始界面
        loginPanelTween.PlayReverse();
        StartCoroutine(HidePanel(loginPanelTween.gameObject));
        nowTweenGameObject = startPanelTween.gameObject;
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse(); 
    }

    public void OnRegisterCloseClick()
    {//返回登录界面
        registerPanelTween.PlayReverse();
        StartCoroutine(HidePanel(registerPanelTween.gameObject));
        nowTweenGameObject = loginPanelTween.gameObject;
        loginPanelTween.gameObject.SetActive(true);
        loginPanelTween.PlayForward(); 
    }

    public void OnRegisterCanelClick()
    {//返回登录界面
        OnRegisterCloseClick();
    }

    public void OnRegisterAndLoginClick()
    {//1、本地校验，密码是否相同
        //TODO
        //2、服务器校验，用户名是否存在
        Txt_Username = input_register_username.value;
        Txt_Password = input_register_password.value;
        //3、注册成功，保存用户名和密码，返回登入界面

        Txt_Username = input_register_username.value;
        Txt_Password = input_register_password.value;

        registerPanelTween.PlayReverse();
        StartCoroutine(HidePanel(registerPanelTween.gameObject));
        nowTweenGameObject = startPanelTween.gameObject;
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse();

        label_username.text = Txt_Username;
    }

    public void InitServerList()
    {//初始化服务器列表
        if (haveInitServerList) 
        {
            return;
        }
        else
        {
            //1、连接服务器，取得服务器列表信息
            //TODO
            //2、根据上面的信息，添加服务器列表
            ServerInfo newServerInfo;
            List<ServerInfo> newServerList = ServerData.getServerData();
            for (int i = 0; i < newServerList.Count; i++)
            {
                newServerInfo = newServerList[i];
                string ip = newServerInfo.ip;
                int no = newServerInfo.no;
                string serverName = no.ToString() + "区 " + newServerInfo.name;
                int maxCount = newServerInfo.maxCount;
                int nowCount = newServerInfo.nowCount;
                GameObject go = null;
                if(nowCount<=maxCount*0.6)
                {//流畅
                    go = NGUITools.AddChild(serverListGrid.gameObject, serverItemGreen);
                }
                else if (nowCount<=(maxCount-1))
                {//火爆
                    go = NGUITools.AddChild(serverListGrid.gameObject, serverItemRed);
                }
                else
                {//超负荷
                    go = NGUITools.AddChild(serverListGrid.gameObject, serverItemRed);
                    serverName = serverName + " (满)";
                }
                ServerPropery sp = go.GetComponent<ServerPropery>();

                sp.Ip = ip;
                sp.No=no;
                sp.ServerName = serverName;
                sp.MaxCount = maxCount;
                sp.NowCount = nowCount;

                serverListGrid.AddChild(go.transform);
            }
            //初始化startMenu和server的选择服务器
            Sp_selected = serverListGrid.GetChild(0).GetComponent<ServerPropery>();
            lab_btn_server.text = Sp_selected.ServerName;
            GameObject newGo = NGUITools.AddChild(selectServerPos, serverListGrid.GetChild(0).gameObject);
            ServerPropery newSp = newGo.GetComponent<ServerPropery>();
            newSp = Sp_selected;
            haveInitServerList = true;
        }
    }

    public void OnServerSelect(GameObject serverGo)
    {
        if (serverGo.GetComponent<ServerPropery>() != selectServerPos.transform.GetChild(0).GetComponent<ServerPropery>())
        {
            Sp_selected = serverGo.GetComponent<ServerPropery>();
            if (selectServerPos.transform.childCount != 0)
            {//如果有服务器被选择了，删除原有的 添加新的 
                CleanChild(selectServerPos.transform);
            }

            GameObject newGo = NGUITools.AddChild(selectServerPos, serverGo);//添加被选择的服务器
            ServerPropery newSp = newGo.GetComponent<ServerPropery>();
            lab_btn_server.text = Sp_selected.ServerName;
        }


        //返回开始界面
        serverPanelTween.PlayReverse();
        StartCoroutine(HidePanel(serverPanelTween.gameObject));
        nowTweenGameObject = startPanelTween.gameObject;
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse(); 
    }

    public void OnCharacterChangeClick()
    {
        //返回角色改变界面
        characterSelectTweenPos.PlayReverse();
        StartCoroutine(HidePanel(characterSelectTweenPos.gameObject));
        nowTweenGameObject = characterChangeTweenPos.gameObject;
        characterChangeTweenPos.gameObject.SetActive(true);
        characterChangeTweenPos.PlayForward();

        OnCharacterCilcik(characterArray[0]);
    }

    public void OnCharacterSelectClick()
    {//返回进入游戏界面
        characterChangeTweenPos.PlayReverse();
        StartCoroutine(HidePanel(characterChangeTweenPos.gameObject));
        nowTweenGameObject = characterSelectTweenPos.gameObject;
        characterSelectTweenPos.gameObject.SetActive(true);
        characterSelectTweenPos.PlayForward();
    }

    public void OnCharacterSureClick()
    {//更改名字和模型并且返回进入游戏界面
        int index = -1;
        //名字如果为空
        //TODO
        //名字不为空，进行注册登录
        label_character_name.text = input_characterName.value;
        label_character_lv.text = "LV.1";

        CleanChild(characterPos.transform);

        if(characterSelected!=null)
        {
            index = getCharacterSelectIndex(characterSelected);
        }
        

        if(index!=-1)
        {
            GameObject go = NGUITools.AddChild(characterPos, characterSelectedArray[index]);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
        }
        

        OnCharacterSelectClick();
    }

    public void CleanChild(Transform father)
    {
        foreach(Transform child in father)
        {
            Destroy(child.gameObject);
        }

    }

    public int getCharacterSelectIndex(GameObject go)
    {
        int index = -1;
        for(int i=0;i<characterArray.Length;i++)
        {
            if(go==characterArray[i])
            {
                index = i;
                break;
            }
        }
        return index;
    }


    public void OnCharacterCilcik(GameObject go)
    {//角色被选择缩放

        if(characterSelected == null)
        {
            iTween.ScaleTo(go, new Vector3(1.5f, 1.5f, 1.5f), 0.4f);
            characterSelected = go;
        }
        else if (characterSelected != go)
        {
            iTween.ScaleTo(characterSelected, new Vector3(1.0f, 1.0f, 1.0f), 0.4f);
            iTween.ScaleTo(go, new Vector3(1.5f, 1.5f, 1.5f), 0.4f);
            characterSelected = go;
        }
        
    }

    IEnumerator HidePanel(GameObject go)
    {
        yield return new WaitForSeconds(0.4f);
        if (nowTweenGameObject != go)
        {
            go.SetActive(false);
        }
        /*startPanelTween.gameObject.SetActive(false);
        loginPanelTween.gameObject.SetActive(false);
        registerPanelTween.gameObject.SetActive(false);
        serverPanelTween.gameObject.SetActive(false);
        nowTweenGameObject.gameObject.SetActive(true);*/
    }

    public static string Txt_Username
    {
        get { return StartMenuController.txt_username; }
        set { StartMenuController.txt_username = value; }
    }

    public static string Txt_Password
    {
        get { return StartMenuController.txt_password; }
        set { StartMenuController.txt_password = value; }
    }

    public static ServerPropery Sp_selected
    {
        get { return StartMenuController.sp_selected; }
        set { StartMenuController.sp_selected = value; }
    }
}
