using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*---------------------------------
 �P���̃R�X�g�����X��\��������v���O����
---------------------------------*/

public class CostXNumberScript1: MonoBehaviour
{
    public CanvasRenderer[] CostXNumberCR;
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
        if (oldNumber != nowNumber)
        {
            nowNunbers();
            oldNumber = nowNumber;
        }
    }

    public void AllClear()
    {
        foreach (CanvasRenderer nowCR in CostXNumberCR)
        {
            nowCR.SetAlpha(0);
        }
    }

    void nowNunbers()
    {
        //NumberCR[oldNumber].SetAlpha(0);
        CostXNumberCR[nowNumber - 1].SetAlpha(1);
    }
}
