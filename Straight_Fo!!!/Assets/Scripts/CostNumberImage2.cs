using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*----------------------------------------
 鳳側のコストを表示させるプログラム
----------------------------------------*/

public class CostNumberImage2 : MonoBehaviour
{
    public GameObject Cst;
    public CostNumber2 script;

    public CanvasRenderer[] NumberCRs;
    int _oldNumber;

    // Start is called before the first frame update
    void Start()
    {
        Cst = GameObject.Find("gageM2");
        script = Cst.GetComponent<CostNumber2>();

        AllClear();
        _oldNumber = script.Cost;
        nowNunbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (_oldNumber != script.Cost)
        {
            nowNunbers();
            _oldNumber = script.Cost;
        }
    }

    public void AllClear()
    {
        foreach (CanvasRenderer nowCR in NumberCRs)
        {
            nowCR.SetAlpha(0);
        }
    }

    public void Set1()
    {
        for (int i = 0; i <= script.Cost - 1; i++)
        {
            NumberCRs[i].SetAlpha(1);
        }
    }

    void nowNunbers()
    {
        //NumberCRs[_oldNumber].SetAlpha(0);
        NumberCRs[script.Cost - 1].SetAlpha(1);
    }
}
