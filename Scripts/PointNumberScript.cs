using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------------
 ���_(�X�R�A)��\��������v���O����
------------------------------------------*/

public class PointNumberScript : MonoBehaviour
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
        if (oldNumber != script.Point)
        {
            nowNunbers();
            oldNumber = script.Point;
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
        PointNumberCR[script.Point - 1].SetAlpha(1);
    }
}
