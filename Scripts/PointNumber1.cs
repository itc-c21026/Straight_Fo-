using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*---------------------------------------
 得点(スコア)を表示させるプログラム
---------------------------------------*/

public class PointNumber1 : MonoBehaviour
{
    public GameObject obj;
    GameController script;

    public Text pointTextUI;

    public PointNumberScript1[] numberis;

    private void Start()
    {
        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<GameController>();
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        string pointText = script.Point2 + "";
        pointTextUI.text = pointText;
        string[] getPointOne = new string[1];
        int numberKeta = pointText.Length;

        for (int i = 0; i <= numberKeta; i++)
        {
            if (i < numberKeta)
            {
                getPointOne[i] = pointText.Substring(pointText.Length - (i + 1), 1);
                numberis[i].script.Point = int.Parse(getPointOne[i + 1]);
            }
        }
    }
}
