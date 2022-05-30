using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
   
/*--------------------------------------
盤に駒が吸い付き、駒の座標を取得するプログラム
--------------------------------------*/


public class SorptionScript : MonoBehaviour
{
    public GameObject GCtrl;
    GameController script;

    public string targetTag;
    bool isHolding;

    public int x;
    public int z;

    private void Start()
    {
        GCtrl = GameObject.Find("GameObject");
        script = GCtrl.GetComponent<GameController>();
    }

    // ボールが入っているかを返す
    public bool IsHolding()
    {
        return isHolding;
    }


    void OnTriggerExit(Collider other)
    {

        // タグがKOMAのオブジェクトが自分から離れた場合かつ、z,x座標の数値が0以外の場合、数値を0にする
        if (other.gameObject.tag == "KOMA")
        {
            if (script.squares[z, x] != 0)
            {
                script.squares[z, x] = script.EMPTY;
                script.S1 = false;
            }
            isHolding = false;
        }

        // タグがKOMA2、上記のプログラムと同じ
        if (other.gameObject.tag == "KOMA2")
        {
            if (script.squares[z, x] != 0)
            {
                script.squares[z, x] = script.EMPTY;
                script.S2 = false;
            }
            isHolding = false;
        }

        // 他のスクリプト
        if (script.cnt >= 5)
        {
            script.b = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // タグがKOMAのオブジェクトとぶつかっている間かつ、z,x座標の数値が0の場合、1にする
        if (other.gameObject.tag == "KOMA")
        {
            isHolding = true;
            x = (int)this.gameObject.transform.localPosition.x;
            z = (int)this.gameObject.transform.localPosition.z;

            if (script.squares[z, x] == script.EMPTY)
            {
                script.squares[z, x] = script.WHITE;
            }
        }

        // タグがKOMA2、上記のプログラムと同じ
        if (other.gameObject.tag == "KOMA2")
        {
            isHolding = true;
            x = (int)this.gameObject.transform.localPosition.x;
            z = (int)this.gameObject.transform.localPosition.z;

            if (script.squares[z, x] == script.EMPTY)
            {
                script.squares[z, x] = script.BLACK;
            }
        }

        // コライダに触れているオブジェクトのRigitbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        // タグに応じてボールに力を加える
        if (other.gameObject.tag == "KOMA")
        {

            // 中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20f, ForceMode.Acceleration);
        }

        if (other.gameObject.tag == "KOMA2")
        {

            // 中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20f, ForceMode.Acceleration);
        }
    }


}
