using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*------------------------------------
 鳳側のコスト消費のXを表示させるプログラム
------------------------------------*/

public class CostXNumber1 : MonoBehaviour
{
    public GameObject obj;
    CostXNumberScript script;

    public Text CostXTextUI;

    public CostXNumberScript1[] numberis;

    private void Start()
    {
        obj = GameObject.Find("Cost_X2");
        script = obj.GetComponent<CostXNumberScript>();
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        string costxText = script.nowNumber + "";
        CostXTextUI.text = costxText;
        string[] getCostXOne = new string[1];
        int numberKeta = costxText.Length;

        for (int i = 0; i <= numberKeta; i++)
        {
            if (i < numberKeta)
            {
                getCostXOne[i] = costxText.Substring(costxText.Length - (i + 1), 1);
                numberis[i].nowNumber = int.Parse(getCostXOne[i + 1]);
            }
        }
    }
}
