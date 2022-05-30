using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------
 高速玉(コスト2)のプログラム
---------------------------------------*/

public class KosokuKOMAscript : MonoBehaviour
{
    bool col;

    private void Start()
    {
        col = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // コライダに触れているオブジェクトのRigitbodyコンポーネントを取得
        Rigidbody r = collision.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかを計算
        Vector3 direction = collision.gameObject.transform.position - transform.position;
        direction.Normalize();

        // ぶつかったオブジェクトのタグがKOMAだった場合、そのオブジェクトに反発を与える
        if (collision.gameObject.tag == "KOMA" || collision.gameObject.tag == "KOMA2")
        {
            if (col == true)
            {
                r.velocity *= 0.9f;
                r.AddForce(direction * 20.0f, ForceMode.Impulse);
                col = false;
            }
        }
    }
}
