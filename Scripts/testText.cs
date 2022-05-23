using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-------------------------------
 デバッグ用プログラム
-------------------------------*/

public class testText : MonoBehaviour
{
    [SerializeField]
    Ball Input;

    // テスト用
    [SerializeField]
    private Text _testText;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // 30FPSに設定
    }

    // Update is called once per frame
    void Update()
    {
        // 文字表示処理
        _testText.text = "Flick:" + Input.GetNowFlick().ToString();
        _testText.text += "\nSwipe:" + Input.GetNowSwipe().ToString();
        _testText.text += "\nRange:" + Input.GetSwipeRange();
    }
}
