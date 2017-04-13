using UnityEngine;
using System.Collections;

public class InventoryStart : MonoBehaviour 
{
    public GameObject inventoryItemPrefab;

    private static int maxNum = 32;
    private int hang = 4;
    private float startx = -122;
    private float starty = 142;
    private float xpos = 60;
    private float ypos = -60;

    public static int getMaxNum()
    {
        return maxNum;
    }

    void Awake()
    {
        StartInventory();
    }

    void StartInventory()
    {
        DestoryInventory();
        float nowx = startx;
        float nowy = starty;

        for(int i = 0;i<maxNum/hang;i++)
        {//处理能被整除的个数
            for(int j=0;j<hang;j++)
            {
                GameObject newGo = NGUITools.AddChild(gameObject, inventoryItemPrefab);
                newGo.transform.localPosition = new Vector3(nowx, nowy, 0f);
                newGo.name = "inventoryItem" + i + j;
                nowx += xpos;
            }
            nowx = startx;
            nowy += ypos;
        }
        for(int i=0;i<maxNum%hang;i++)
        {//处理不能被整除的个数
            GameObject newGo = NGUITools.AddChild(gameObject, inventoryItemPrefab);
            newGo.transform.localPosition = new Vector3(nowx, nowy, 0f);
            newGo.name = "inventoryItem" + maxNum / hang + i;
            nowx += xpos;
        }
    }

    void DestoryInventory()
    {
        foreach (Transform ts in transform)
        {
            Destroy(ts.gameObject);
        }
    }
}
