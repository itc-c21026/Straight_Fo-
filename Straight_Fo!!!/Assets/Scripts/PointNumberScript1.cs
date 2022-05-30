using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------------
 得点(スコア)を表示させるプログラム
------------------------------------------*/

public class PointNumberScript1 : MonoBehaviour
{
    public GameObject obj;
    public GameController script;

    public CanvasRenderer[] PointNumberCR;
    int oldNumber;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<GameController>();

        AllClear();
        oldNumber = script.Point;
        nowNunbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldNumber != script.Point2)
        {
            nowNunbers();
            oldNumber = script.Point2;
        }
    }

    void AllClear()
    {
        foreach (CanvasRenderer nowCR in PointNumberCR)
        {
            nowCR.SetAlpha(0);
        }
    }

    void nowNunbers()
    {
        //PointNumberCR[oldNumber].SetAlpha(0);
        PointNumberCR[script.Point2 - 1].SetAlpha(1);
    }
}
