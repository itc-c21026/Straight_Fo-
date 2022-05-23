using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------
 トラック(コスト5)のプログラム
---------------------------------------*/

public class TrackScript : MonoBehaviour
{

    public GameObject obj;
    GameController script;

    public GameObject aud;
    AudioScript script2;

    void Start()
    {
        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<GameController>();

        aud = GameObject.Find("Audio");
        script2 = aud.GetComponent<AudioScript>();
    }

    void Update()
    {
        // トラック(コスト5)の制御プログラム
        if (script.trackbl2 == true)
        {
            if (this.transform.position.x <= 0) script.trackbl3 = true;
            script.trackbl2 = false;
        }

        if (script.trackbl3 == true)
        {
            this.transform.position += new Vector3(0.6f, 0, 0);
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
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
            script2.audioSource.PlayOneShot(script2.sound19);
            r.velocity *= 0.9f;
            r.AddForce(direction * 100.0f, ForceMode.Impulse);
        }
    }
}
