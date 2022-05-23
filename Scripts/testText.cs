using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-------------------------------
 �f�o�b�O�p�v���O����
-------------------------------*/

public class testText : MonoBehaviour
{
    [SerializeField]
    Ball Input;

    // �e�X�g�p
    [SerializeField]
    private Text _testText;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // 30FPS�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
        // �����\������
        _testText.text = "Flick:" + Input.GetNowFlick().ToString();
        _testText.text += "\nSwipe:" + Input.GetNowSwipe().ToString();
        _testText.text += "\nRange:" + Input.GetSwipeRange();
    }
}
