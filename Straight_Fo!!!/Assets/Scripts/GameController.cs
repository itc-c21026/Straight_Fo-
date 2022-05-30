using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*--------------------------------------
 �Q�[���V�X�e���𐧌䂷��v���O����
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

        //��΂������Ă��邩�ǂ����m�F����
        if (CheckStone(WHITE) || CheckStone(BLACK))
        {
            return;
        }

        CARD();
    }

    // �O�̂��ߍŏ��͑S�ċ�ɂ���
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

    //5�A���Ō�΂��u����Ă��邩�m�F����(color�ɔ��肷��F��n��)
    private bool CheckStone(int color)
    {

        //������
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                //squares�̒l����̂Ƃ�
                if (squares[i, j] == EMPTY || squares[i, j] != color)
                {
                    //count������������
                    count = 0;
                }
                else
                {
                    //count��squares�̒l���i�[����
                    count++;
                }


                //count�̒l��5�ɂȂ����Ƃ�
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

        //count�̒l��������
        count = 0;

        //�c����
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                //squares�̒l����̂Ƃ�
                if (squares[j, i] == EMPTY || squares[j, i] != color)
                {
                    //count������������
                    count = 0;
                }
                else
                {
                    //count��squares�̒l���i�[����
                    count++;
                }

                //count�̒l��5�ɂȂ����Ƃ�
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

        //count�̒l��������
        count = 0;

        //�΂�(�E�オ��)
        for (int i = 0; i < 13; i++)
        {
            //��ړ��p
            int up = 0;

            for (int j = i; j < 13; j++)
            {
                //squares�̒l����̂Ƃ�
                if (squares[j, up] == EMPTY || squares[j, up] != color)
                {
                    //count������������
                    count = 0;                }
                else
                {
                    //count��squares�̒l���i�[����
                    count++;
                }

                //count�̒l��5�ɂȂ����Ƃ�
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
            //��ړ��p
            int up = 0;

            for (int j = i; j < 13; j++)
            {
                //squares�̒l����̂Ƃ�
                if (squares[up, j] == EMPTY || squares[up, j] != color || i == 0)
                {
                    //count������������
                    count = 0;
                }
                else
                {
                    //count��squares�̒l���i�[����
                    count++;
                }

                //count�̒l��5�ɂȂ����Ƃ�
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
        
        //count�̒l��������
        count = 0;

        //�΂�(�E������)
        for (int i = 0; i < 13; i++)
        {
            //���ړ��p
            int down = 12;

            for (int j = i; j < 13; j++)
            {
                //squares�̒l����̂Ƃ�
                if (squares[j, down] == EMPTY || squares[j, down] != color)
                {
                    //count������������
                    count = 0;
                }
                else
                {
                    //count��squares�̒l���i�[����
                    count++;
                }

                //count�̒l��5�ɂȂ����Ƃ�
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
            //���ړ��p
            int down = 0;

            for (int j = i; j >= 0; j--)
            {
                //squares�̒l����̂Ƃ�
                if (squares[down, j] == EMPTY || squares[down, j] != color)
                {
                    //count������������
                    count = 0;
                }
                else
                {
                    //count��squares�̒l���i�[����
                    count++;
                }

                //count�̒l��5�ɂȂ����Ƃ�
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
        //�܂����肪���Ă��Ȃ��Ƃ�
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
