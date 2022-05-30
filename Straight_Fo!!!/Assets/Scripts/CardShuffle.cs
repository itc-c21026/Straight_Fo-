using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------------
 �����̃J�[�h�̃V���b�t���⃍�[�e�[�V����(����)������v���O����
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
        // �ŏ��ɃJ�[�h���V���b�t��������
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

    // �����̃J�[�h�V���b�t���֐�
    void Shuffle()
    {
        Vector3 Rot;

        // y���W�錾
        int y = 340;

        // x���W�錾
        int x = -570;

        // �\�ɕ\�������3���̃v���O����
        for (int i = 6; i > 3; i--)
        {
            // �����_����1�������߂�
            int s = UnityEngine.Random.Range(1, i);
            s -= 1;

            // ���ɕ\�ɕ\������Ă��邩�m�F
            if(s != tmp[5] && s != tmp[4] && s != tmp[3] && s != tmp[2] && s != tmp[1] && s != tmp[0])
            {
                // ���܂��������̃J�[�h�𐶐�
                prefab[s] = Instantiate(card[s], new Vector3(x, y, 0), Quaternion.identity);

                // �������ꂽ�J�[�h��z��]-90��������
                Rot = prefab[s].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, -90);
                prefab[s].gameObject.transform.localEulerAngles = Rot;
                // ���������J�[�h��canvas�̎q�ɂ���
                prefab[s].transform.SetParent(this.canvas.transform, false);

                // ���̃J�[�h��y���W-60,x���W-55�ɐ�������悤�ɐݒ�
                y -= 150;

                // �������ꂽ�J�[�h�̐��l������
                tmp[s] = s;
            }
            else
            {
                i++;
            }
        }

        // �J�[�h�����񂳂��邽�߂ɐ������Ă���
        for(int j = 0; j < 6; j++)
        {
            // �\�ɕ\��������v���O�����Ƃقړ���
            if (j != tmp[5] && j != tmp[4] && j != tmp[3] && j != tmp[2] && j != tmp[1] && j != tmp[0])
            {
                
                prefab[j] = Instantiate(card[j], new Vector3(-1000, y, 0), Quaternion.identity);

                Rot = prefab[j].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, -90);
                prefab[j].gameObject.transform.localEulerAngles = Rot;
                prefab[j].transform.SetParent(this.canvas.transform, false);

                y += 120;
                tmp[j] = j;
                
                // ���̃J�[�h��ҋ@������
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

    // �P���̃J�[�h�V���b�t���֐�
    // �d�g�݂͗����Ɠ���
    void Shuffle2()
    {
        Vector3 Rot;

        // y���W�錾
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
            // �\�ɕ\��������v���O�����Ƃقړ���
            if (j != tmp2[5] && j != tmp2[4] && j != tmp2[3] && j != tmp2[2] && j != tmp2[1] && j != tmp2[0])
            {

                prefab2[j] = Instantiate(card2[j], new Vector3(+1000, y, 0), Quaternion.identity);

                Rot = prefab2[j].gameObject.transform.localEulerAngles;
                Rot = new Vector3(0, 0, 90);
                prefab2[j].gameObject.transform.localEulerAngles = Rot;
                prefab2[j].transform.SetParent(this.canvas.transform, false);

                y += 120;
                tmp2[j] = j;

                // ���̃J�[�h��ҋ@������
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
