using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public static int GetMaxExpByLeverl(int level)
    {//根据经验获取等级，等差数列
        return (int)((level) * (100f + (100f + 10f * (level - 1f))) / 2);
    }
}
