using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------
 アプリを終了させるプログラム
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
