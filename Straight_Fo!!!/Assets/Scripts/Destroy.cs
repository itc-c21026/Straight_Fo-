using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------
 オブジェクトを削除するプログラム
------------------------------------*/

public class Destroy : MonoBehaviour
{
    public GameObject obj;
    CardMoveScript script;
    GameController script2;

    private void Start()
    {
        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<CardMoveScript>();
        script2 = obj.GetComponent<GameController>();
    }

    // タグがKOMAとぶつかった場合、そのオブジェクトが削除される
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KOMA" || other.gameObject.tag == "KOMA2")
        {
            Destroy(other.gameObject);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        // タグがTRACKのオブジェクトとぶつかった場合、そのオブジェクトが消える
        // script...は他のプログラム
        if (collision.gameObject.tag == "TRACK")
        {
            Destroy(collision.gameObject);
            script2.trackbl2 = false;
            script2.trackbl3 = false;
        }

        // タグがTRACK2、上記と同じプログラム
        if (collision.gameObject.tag == "TRACK2")
        {
            Destroy(collision.gameObject);
            script2.trackbl2_2 = false;
            script2.trackbl2_3 = false;
        }

        // タグがPACMAN、上記と同じプログラム
        if (collision.gameObject.tag == "PACMAN")
        {
            Destroy(collision.gameObject);
            script2.pacmanbl2 = false;
            script2.pacmanbl3 = false;
        }

        // タグがPACMAN2、上記と同じプログラム
        if (collision.gameObject.tag == "PACMAN2")
        {
            Destroy(collision.gameObject);
            script2.pacmanbl2_2 = false;
            script2.pacmanbl2_3 = false;
        }

        // タグがKOMA・KOMA2、BOM、上記と同じプログラム
        if (collision.gameObject.tag == "KOMA" || collision.gameObject.tag == "KOMA2" || collision.gameObject.tag == "BOM")
        {
            Destroy(collision.gameObject);
        }
    }
}
