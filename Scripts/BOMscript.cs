using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------
 爆弾玉(コスト4)のプログラム
---------------------------------------*/

public class BOMscript : MonoBehaviour
{
    GameObject effect;
    GameObject effect2;
    public GameObject obj;
    Ball script;

    public GameObject aud;
    AudioScript script2;

    bool ef;
    public bool BOOM;
    float b;
    float d;
    float e;

    float a = 0.2f;

    bool c = true;

    private void Start()
    {
        e = 0.5f;
        ef = true;

        obj = GameObject.Find("GameObject");
        script = obj.GetComponent<Ball>();
        aud = GameObject.Find("Audio");
        script2 = aud.GetComponent<AudioScript>();

        BOOM = false;

        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        if (script.bom == true)
        {
            BOOM = true;
        }

        if (BOOM == true)
        {
            b += Time.deltaTime;
        }

        if (script.bom2 == true)
        {
            d += Time.deltaTime;
            if (d >= e)
            {
                script2.audioSource.PlayOneShot(script2.sound10);
                e /= 1.25f;
                d = 0;
            }
        }

        if (b >= 3 && b < 4)
        {
            script.bom2 = false;
            if (c == true)
            {
                script2.audioSource.PlayOneShot(script2.sound5);
                c = false;
            }
            if (ef == true)
            {
                effect = GameObject.Find("Bom_Ef_Prfab");
                Instantiate(effect, this.transform.position, Quaternion.identity);
                //Destroy(effect);
                ef = false;
            }
        }

        if (b >= 4)
        {
            effect2 = GameObject.Find("Bom_Ef_Prfab(Clone)");
            Destroy(effect2);
            BOOM = false;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // コライダに触れているオブジェクトのRigitbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        if (other.gameObject.tag == "KOMA" || other.gameObject.tag == "KOMA2")
        {
            if (b >= 3 && b < 4)
            {
                // KOMAを反発する
                r.velocity *= 0.9f;
                r.AddForce(direction * 200f, ForceMode.Acceleration);
            }
        }
    }
}
