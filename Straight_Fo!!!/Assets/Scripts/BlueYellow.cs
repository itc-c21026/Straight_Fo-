using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------
 �J�[�h��͂�ł���ԁA������ʂ������ł���͈͂�\��
-----------------------------------------------------*/

public class BlueYellow : MonoBehaviour
{
    public bool Blue;
    public bool Yellow;
    public Image imgB;
    public Image imgY;

    private void Start()
    {
        Blue = false;
        Yellow = false;

        imgB.enabled = false;
        imgY.enabled = false;
    }

    private void Update()
    {
        if (Blue == true)
        {
            imgB.enabled = true;
        }else if (Blue == false)
        {
            imgB.enabled = false;
        }
        
        if(Yellow == true)
        {
            imgY.enabled = true;
        }else if (Yellow == false)
        {
            imgY.enabled = false;
        }
    }
}
