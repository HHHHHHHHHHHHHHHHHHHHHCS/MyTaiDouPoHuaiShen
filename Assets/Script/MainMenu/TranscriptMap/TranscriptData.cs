using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TranscriptData  
{
    static bool btnIsFirst = true;
    private static Dictionary<int, BtnTranscript> btnTranscriptDataDict = new Dictionary<int, BtnTranscript>();

    public static Dictionary<int, BtnTranscript> BtnTranscriptDataDict
    {
        get
        {
            if (btnIsFirst)
            {
                AwakeBtnData();
            }
            return btnTranscriptDataDict;
        }
    }

    static bool AwakeBtnData()
    {
        if (btnIsFirst)
        {
            btnIsFirst = false;
            BtnTranscript newScript;
            #region 1001-2000Data
            newScript = new BtnTranscript();
            newScript.Id = 1001;
            newScript.NeedLevel = 1;
            newScript.TranscriptName = "1001";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 1002;
            newScript.NeedLevel = 1;
            newScript.TranscriptName = "1002";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 1003;
            newScript.NeedLevel = 2;
            newScript.TranscriptName = "1003";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 1004;
            newScript.NeedLevel = 3;
            newScript.TranscriptName = "1004";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 1005;
            newScript.NeedLevel = 4;
            newScript.TranscriptName = "1005";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 1006;
            newScript.NeedLevel = 5;
            newScript.TranscriptName = "1006";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 1007;
            newScript.NeedLevel = 6;
            newScript.TranscriptName = "1007";
            newScript.Des = "这里阴森，森，森！你看吓得我都口吃了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);
            #endregion
            #region 2001-3000Data
            newScript = new BtnTranscript();
            newScript.Id = 2001;
            newScript.NeedLevel = 2;
            newScript.TranscriptName = "2001";
            newScript.Des = "这里有好多菜包和财宝！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);

            newScript = new BtnTranscript();
            newScript.Id = 2002;
            newScript.NeedLevel = 4;
            newScript.TranscriptName = "2002";
            newScript.Des = "这里有好多菜包和财宝！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);
            #endregion
            #region 3001-4000Data
            newScript = new BtnTranscript();
            newScript.Id = 3001;
            newScript.NeedLevel = 4;
            newScript.TranscriptName = "3001";
            newScript.Des = "别以为打败了我，你就通关了！";
            btnTranscriptDataDict.Add(newScript.Id, newScript);


            #endregion
            return true;
        }
        return false;
    }

}
