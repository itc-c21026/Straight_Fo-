using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------------
 龍側のカードのシャッフルやローテーション(巡回)させるプログラム
------------------------------------------*/

public class CardShuffle : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    public GameObject[] card;
    public GameObject[] card2;
    public GameObject[] prefab;
    public GameObject[] prefab2;

    public int[] tmp = { 9, 9, 9, 9, 9, 9,};
    public int[] tmp2 = { 9, 9, 9, 9, 9, 9,};

    public int[] Taiki = { 9, 9, 9 };
    public int[] Taiki2 = { 9, 9, 9 };

    public bool bl;
    public bool bl2;
    public float x;
    public float y;

    public bool bl3;
    public bool bl4;
    public float x2;
    public float y2;

    public int cms = 100;
    public int cms2 = 100;
    // Start is called before the first frame update
    void Start()
    {
        bl = false;
        bl2 = false;
        bl3 = false;
        bl4 = false;
        // 最初にカードをシャッフルさせる
        Shuffle();
        Shuffle2();
    }

    private void Update()
    {
        if (bl == true)
        {
            prefab[Taiki[0]].transform.position = new Vector3(x - 150, y, 0);
            bl2 = true;
            bl = false;
        }

        if (bl2 == true)
        {
            if (prefab[Taiki[0]].transform.position.x < x)
            {
                prefab[Taiki[0]].transform.position += new Vector3(50f, 0, 0);
            }
            else
            {
                Taiki[0] = Taiki[1];
                Taiki[1] = Taiki[2];
                Taiki[2] = cms;
                cms = 100;
                bl2 = false;
            }
        }

        if (bl3 == true)
        {
            prefab2[Taiki2[0]].transform.position = new Vector3(x2 + 150, y2, 0);
            bl4 = true;
            bl3 = false;
        }

        if (bl4 == true)
        {
            if (prefab2[Taiki2[0]].transform.position.x > x2)
            {
                prefab2[Taiki2[0]].transform.position += new Vector3(-50f, 0, 0);
            }
            else
            {
                Taiki2[0] = Taiki2[1];
                Taiki2[1] = Taiki2[2];
                Taiki2[2] = cms2;
                cms2 = 100;
                bl4 = false;
            }
        }
    }

    // 龍側のカードシャッフル関数
    void Shuffle()
    {
        Vector3 Rot;

        // y座標宣言
        int y = 340;

        // x座標宣言
        int x = -570;

        // 表に表示される3枚のプログラム
        for (int i = 6; i > 3; i--)
        {
            // ランダムで1枚を決める
            int s = UnityEngine.Random.Range(1, i);
            s -= 1;

            // 既に表に表示されているか確認
            if(s != tmp[5] && s != tmp[4] && s != tmp[3] && s != tmp[2] && s != tmp[1] && s != tmp[0])
            {
                // 決まった数字のカードを生成
                prefab[s] = Instantiate(card[s], new Vector3(x, y, 0), Quaternion.identity);

                // 生成されたカードにz回転-90を加える
                Rot = prefab[s].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, -90);
                prefab[s].gameObject.transform.localEulerAngles = Rot;
                // 生成されるカードをcanvasの子にする
                prefab[s].transform.SetParent(this.canvas.transform, false);

                // 次のカードをy座標-60,x座標-55に生成するように設定
                y -= 150;

                // 生成されたカードの数値を入れる
                tmp[s] = s;
            }
            else
            {
                i++;
            }
        }

        // カードを巡回させるために生成しておく
        for(int j = 0; j < 6; j++)
        {
            // 表に表示させるプログラムとほぼ同じ
            if (j != tmp[5] && j != tmp[4] && j != tmp[3] && j != tmp[2] && j != tmp[1] && j != tmp[0])
            {
                
                prefab[j] = Instantiate(card[j], new Vector3(-1000, y, 0), Quaternion.identity);

                Rot = prefab[j].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, -90);
                prefab[j].gameObject.transform.localEulerAngles = Rot;
                prefab[j].transform.SetParent(this.canvas.transform, false);

                y += 120;
                tmp[j] = j;
                
                // 裏のカードを待機させる
                if (Taiki[0] == 9)
                {
                    Taiki[0] = j;
                    
                }else if(Taiki[1] == 9)
                {
                    Taiki[1] = j;
                }else if(Taiki[2] == 9)
                {
                    Taiki[2] = j;
                }
            }
        }
    }

    // 鳳側のカードシャッフル関数
    // 仕組みは龍側と同じ
    void Shuffle2()
    {
        Vector3 Rot;

        // y座標宣言
        int y = -340;
        int x = 570;
        for (int i = 6; i > 3; i--)
        {
            int s = UnityEngine.Random.Range(1, i);
            s -= 1;

            if (s != tmp2[5] && s != tmp2[4] && s != tmp2[3] && s != tmp2[2] && s != tmp2[1] && s != tmp2[0])
            {
                prefab2[s] = Instantiate(card2[s], new Vector3(x, y, 0), Quaternion.identity);

                Rot = prefab2[s].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, 90);
                prefab2[s].gameObject.transform.localEulerAngles = Rot;
                prefab2[s].transform.SetParent(this.canvas.transform, false);

                y += 150;
                //x += 55;
                tmp2[s] = s;
            }
            else
            {
                i++;
            }
        }

        for (int j = 0; j < 6; j++)
        {
            // 表に表示させるプログラムとほぼ同じ
            if (j != tmp2[5] && j != tmp2[4] && j != tmp2[3] && j != tmp2[2] && j != tmp2[1] && j != tmp2[0])
            {

                prefab2[j] = Instantiate(card2[j], new Vector3(+1000, y, 0), Quaternion.identity);

                Rot = prefab2[j].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, 90);
                prefab2[j].gameObject.transform.localEulerAngles = Rot;
                prefab2[j].transform.SetParent(this.canvas.transform, false);

                y += 120;
                tmp2[j] = j;

                // 裏のカードを待機させる
                if (Taiki2[0] == 9)
                {
                    Taiki2[0] = j;
                    //Debug.Log(Taiki2[0]);

                }
                else if (Taiki2[1] == 9)
                {
                    Taiki2[1] = j;
                    //Debug.Log(Taiki2[1]);
                }
                else if (Taiki2[2] == 9)
                {
                    Taiki2[2] = j;
                    //Debug.Log(Taiki2[2]);
                }
            }
        }
    }
}
