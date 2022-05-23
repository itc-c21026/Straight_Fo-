using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*-------------------------------
 時間を表示させるプログラム
 ※このプログラムは使用されていない
-------------------------------*/

public class TimeScript : MonoBehaviour
{
    public GameObject[] ST;

    public int testTime;
    float b = 0;

    public Text TimeTextUI;

    public NumberImage[] numberis;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 30;
        testTime = 180;
    }

    // Update is called once per frame
    void Update()
    {
        b += Time.deltaTime;
        if (b >= 1)
        {
            testTime--;
            b = 0;
        }

        string TimeText = testTime + "";
        TimeTextUI.text = TimeText;

        string[] getTimeOne = new string[3];
        int numberKeta = TimeText.Length;

        for (int i = 0; i <= numberKeta; i++)
        {
            if (i < numberKeta)
            {
                getTimeOne[i] = TimeText.Substring(TimeText.Length - (i + 1), 1);
                numberis[i].nowNumber = int.Parse(getTimeOne[i]);
            }
        }

        if (testTime < 100)
        {
            Destroy(ST[0]);
        }

        if (testTime < 10)
        {
            Destroy(ST[1]);
        }

        if (testTime == 0)
        {
            b -= 100;
        }
    }
}