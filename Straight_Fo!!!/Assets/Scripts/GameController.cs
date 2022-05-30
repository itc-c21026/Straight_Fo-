using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*--------------------------------------
 ゲームシステムを制御するプログラム
--------------------------------------*/

public class GameController : MonoBehaviour
{
    public GameObject obj;
    CostXNumberScript script;

    public GameObject obj2;
    CostXNumberScript1 script2;

    public GameObject aud;
    AudioScript script3;

    public bool pacmanbl2;
    public bool pacmanbl3;
    public bool trackbl2;
    public bool trackbl3;
    public bool pacmanbl2_2;
    public bool pacmanbl2_3;
    public bool trackbl2_2;
    public bool trackbl2_3;

    float a;
    float c;

    bool TrFa;

    int count = 0;

    string KOMA = "KOMA";
    public int Point;
    public int Point2;

    public Text winText;

    public int cnt;

    public float b;
    public float b2;

    public int[,] squares = new int[13, 13];

    public int EMPTY = 0;
    public int WHITE = 1;
    public int BLACK = 2;

    public string COSTst;
    public string COSTst2;

    public bool S1;
    public bool S2;
    private void Awake()
    {
        Screen.SetResolution(1280, 800, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Cost_X");
        script = obj.GetComponent<CostXNumberScript>();

        obj2 = GameObject.Find("Cost_X2");
        script2 = obj2.GetComponent<CostXNumberScript1>();

        aud = GameObject.Find("Audio");
        script3 = aud.GetComponent<AudioScript>();

        S1 = false;
        S2 = false;

        TrFa = true;
        Point = 0;
        Point2 = 0;
        Application.targetFrameRate = 30;
        InitializeArray();

        pacmanbl2 = false;
        pacmanbl3 = false;
        pacmanbl2_2 = false;
        pacmanbl2_3 = false;
        trackbl2 = false;
        trackbl3 = false;
        trackbl2_2 = false;
        trackbl2_3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        //碁石が揃っているかどうか確認する
        if (CheckStone(WHITE) || CheckStone(BLACK))
        {
            return;
        }

        CARD();
    }

    // 念のため最初は全て空にする
    void InitializeArray()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                squares[i, j] = EMPTY;
            }
        }
    }

    //5個連続で碁石が置かれているか確認する(colorに判定する色を渡す)
    private bool CheckStone(int color)
    {

        //横向き
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                //squaresの値が空のとき
                if (squares[i, j] == EMPTY || squares[i, j] != color)
                {
                    //countを初期化する
                    count = 0;
                }
                else
                {
                    //countにsquaresの値を格納する
                    count++;
                }


                //countの値が5になったとき
                if (count == 4)
                {
                    if (color == WHITE)
                    {
                        b += Time.deltaTime;
                        S1 = true;
                    }
                    else
                    {
                        b2 += Time.deltaTime;
                        S2 = true;
                    }

                }
            }
        }

        //countの値を初期化
        count = 0;

        //縦向き
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                //squaresの値が空のとき
                if (squares[j, i] == EMPTY || squares[j, i] != color)
                {
                    //countを初期化する
                    count = 0;
                }
                else
                {
                    //countにsquaresの値を格納する
                    count++;
                }

                //countの値が5になったとき
                if (count == 4)
                {
                    if (color == WHITE)
                    {
                        b += Time.deltaTime;
                        S1 = true;
                    }
                    else
                    {
                        b2 += Time.deltaTime;
                        S2 = true;
                    }
                }
            }
        }

        //countの値を初期化
        count = 0;

        //斜め(右上がり)
        for (int i = 0; i < 13; i++)
        {
            //上移動用
            int up = 0;

            for (int j = i; j < 13; j++)
            {
                //squaresの値が空のとき
                if (squares[j, up] == EMPTY || squares[j, up] != color)
                {
                    //countを初期化する
                    count = 0;                }
                else
                {
                    //countにsquaresの値を格納する
                    count++;
                }

                //countの値が5になったとき
                if (count == 4)
                {
                    if (color == WHITE)
                    {
                        b += Time.deltaTime;
                        S1 = true;
                    }
                    else
                    {
                        b2 += Time.deltaTime;
                        S2 = true;
                    }

                }
                up++;
            }
        }

        count = 0;

        for (int i = 0; i < 13; i++)
        {
            //上移動用
            int up = 0;

            for (int j = i; j < 13; j++)
            {
                //squaresの値が空のとき
                if (squares[up, j] == EMPTY || squares[up, j] != color || i == 0)
                {
                    //countを初期化する
                    count = 0;
                }
                else
                {
                    //countにsquaresの値を格納する
                    count++;
                }

                //countの値が5になったとき
                if (count == 4)
                {
                    if (color == WHITE)
                    {
                        b += Time.deltaTime;
                        S1 = true;
                    }
                    else
                    {
                        b2 += Time.deltaTime;
                        S2 = true;
                    }
                }
                up++;
            }
        }
        
        //countの値を初期化
        count = 0;

        //斜め(右下がり)
        for (int i = 0; i < 13; i++)
        {
            //下移動用
            int down = 12;

            for (int j = i; j < 13; j++)
            {
                //squaresの値が空のとき
                if (squares[j, down] == EMPTY || squares[j, down] != color)
                {
                    //countを初期化する
                    count = 0;
                }
                else
                {
                    //countにsquaresの値を格納する
                    count++;
                }

                //countの値が5になったとき
                if (count == 4)
                {

                    if (color == WHITE)
                    {
                        b += Time.deltaTime;
                        S1 = true;
                    }
                    else
                    {
                        b2 += Time.deltaTime;
                        S2 = true;
                    }

                }
                down--;
            }
        }

        count = 0;

        for (int i = 12; i > 0; i--)
        {
            //下移動用
            int down = 0;

            for (int j = i; j >= 0; j--)
            {
                //squaresの値が空のとき
                if (squares[down, j] == EMPTY || squares[down, j] != color)
                {
                    //countを初期化する
                    count = 0;
                }
                else
                {
                    //countにsquaresの値を格納する
                    count++;
                }

                //countの値が5になったとき
                if (count == 4)
                {

                    if (color == WHITE)
                    {
                        b += Time.deltaTime;
                        S1 = true;
                    }
                    else
                    {
                        b2 += Time.deltaTime;
                        S2 = true;
                    }

                }
                down++;
            }
        }
        //まだ判定がついていないとき
        return false;
    }
    
    void Des()
    {
        GameObject[] KOMAs = GameObject.FindGameObjectsWithTag("KOMA");
        foreach(GameObject Koma in KOMAs)
        {
            Destroy(Koma);
        }

        GameObject[] KOMAs2 = GameObject.FindGameObjectsWithTag("KOMA2");
        foreach (GameObject Koma in KOMAs2)
        {
            Destroy(Koma);
        }
    }

    void CARD()
    {
        if (COSTst == "Cost2")
        {
            a += Time.deltaTime;
            if (script.nowNumber < 2 && a >= 0.1f)
            {
                script.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst == "Cost2_2")
        {
            a += Time.deltaTime;
            if (script.nowNumber < 2 && a >= 0.1f)
            {
                script.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst == "Cost5")
        {
            a += Time.deltaTime;
            if (script.nowNumber < 5 && a >= 0.1f)
            {
                script.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst == "Cost3")
        {
            a += Time.deltaTime;
            if (script.nowNumber < 3 && a >= 0.1f)
            {
                script.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst == "Cost4")
        {
            a += Time.deltaTime;
            if (script.nowNumber < 4 && a >= 0.1f)
            {
                script.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        //--------------------------------------

        if (COSTst2 == "Cost2")
        {
            c += Time.deltaTime;
            if (script2.nowNumber < 2 && c >= 0.1f)
            {
                script2.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst2 == "Cost2_2")
        {
            c += Time.deltaTime;
            if (script2.nowNumber < 2 && c >= 0.1f)
            {
                script2.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst2 == "Cost5")
        {
            c += Time.deltaTime;
            if (script2.nowNumber < 5 && c >= 0.1f)
            {
                script2.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst2 == "Cost3")
        {
            c += Time.deltaTime;
            if (script2.nowNumber < 3 && c >= 0.1f)
            {
                script2.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }

        if (COSTst2 == "Cost4")
        {
            c += Time.deltaTime;
            if (script2.nowNumber < 4 && c >= 0.1f)
            {
                script2.nowNumber += 1;
                script3.audioSource.PlayOneShot(script3.sound16);
            }
        }
    }
}
