using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------
 �A�v�����I��������v���O����
--------------------------------------*/

public class AppEnd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KOMA")
        {
            UnityEngine.Application.Quit();
        }
    }
}
