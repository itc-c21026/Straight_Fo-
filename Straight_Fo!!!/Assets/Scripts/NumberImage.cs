using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------
 ”š‚ğ•\¦‚³‚¹‚éƒvƒƒOƒ‰ƒ€
------------------------------------*/

public class NumberImage : MonoBehaviour
{
    public CanvasRenderer[] NumberCR;
    public int nowNumber;
    int oldNumber;

    // Start is called before the first frame update
    void Start()
    {
        AllClear();
        oldNumber = nowNumber;
        nowNunbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldNumber != nowNumber && nowNumber < 10 && nowNumber >= 0)
        {
            nowNunbers();
            oldNumber = nowNumber;
        }

        if (nowNumber >= 10 || nowNumber <= -1)
        {
            AllClear();
        }
    }

    void AllClear()
    {
        foreach (CanvasRenderer nowCR in NumberCR)
        {
            nowCR.SetAlpha(0);
        }
    }

    void nowNunbers()
    {
        NumberCR[oldNumber].SetAlpha(0);
        NumberCR[nowNumber].SetAlpha(1);
    }
}
