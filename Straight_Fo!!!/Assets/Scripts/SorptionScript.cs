using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
   
/*--------------------------------------
�Ղɋ�z���t���A��̍��W���擾����v���O����
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

    // �{�[���������Ă��邩��Ԃ�
    public bool IsHolding()
    {
        return isHolding;
    }


    void OnTriggerExit(Collider other)
    {

        // �^�O��KOMA�̃I�u�W�F�N�g���������痣�ꂽ�ꍇ���Az,x���W�̐��l��0�ȊO�̏ꍇ�A���l��0�ɂ���
        if (other.gameObject.tag == "KOMA")
        {
            if (script.squares[z, x] != 0)
            {
                script.squares[z, x] = script.EMPTY;
                script.S1 = false;
            }
            isHolding = false;
        }

        // �^�O��KOMA2�A��L�̃v���O�����Ɠ���
        if (other.gameObject.tag == "KOMA2")
        {
            if (script.squares[z, x] != 0)
            {
                script.squares[z, x] = script.EMPTY;
                script.S2 = false;
            }
            isHolding = false;
        }

        // ���̃X�N���v�g
        if (script.cnt >= 5)
        {
            script.b = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // �^�O��KOMA�̃I�u�W�F�N�g�ƂԂ����Ă���Ԃ��Az,x���W�̐��l��0�̏ꍇ�A1�ɂ���
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

        // �^�O��KOMA2�A��L�̃v���O�����Ɠ���
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

        // �R���C�_�ɐG��Ă���I�u�W�F�N�g��Rigitbody�R���|�[�l���g���擾
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // �{�[�����ǂ̕����ɂ��邩���v�Z
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        // �^�O�ɉ����ă{�[���ɗ͂�������
        if (other.gameObject.tag == "KOMA")
        {

            // ���S�n�_�Ń{�[�����~�߂邽�ߑ��x������������
            r.velocity *= 0.9f;
            r.AddForce(direction * -20f, ForceMode.Acceleration);
        }

        if (other.gameObject.tag == "KOMA2")
        {

            // ���S�n�_�Ń{�[�����~�߂邽�ߑ��x������������
            r.velocity *= 0.9f;
            r.AddForce(direction * -20f, ForceMode.Acceleration);
        }
    }


}
