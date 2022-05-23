using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-------------------------------------------
 龍側のコストを表示させるプログラム
-------------------------------------------*/

public class CostNumber : MonoBehaviour
{
    float b;

    public int Cost = 0;
    public Text costTextUI;

    public CostNumberImage[] numberis;

    private void Start()
    {
        Cost = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cost < 9) b += Time.deltaTime;
        if (b >= 1.25)
        {
            Cost++;
            b = 0;
        }
        string costText = Cost + "";
        costTextUI.text = costText;
        string[] getCostOne = new string[1];
        int numberKeta = costText.Length;

        for (int i = 0; i <= numberKeta; i++)
        {
            if (i < numberKeta)
            {
                getCostOne[i] = costText.Substring(costText.Length - (i + 1), 1);
                numberis[i].script.Cost = int.Parse(getCostOne[i + 1]);
            }
        }
    }
}
